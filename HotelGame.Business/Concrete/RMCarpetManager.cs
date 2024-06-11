using AutoMapper;
using HotelGame.Business.Abstract;
using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Core.Utilities.Result.Concrete;
using HotelGame.DataAccess.Abstract;
using HotelGame.DataAccess.Concrete.EntityFramework.Repositories;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.PlayerHotels;
using HotelGame.Entities.DTOs.RoomMaterial;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelGame.Business.Concrete
{
    public class RMCarpetManager : IRMCarpetService
    {
        #region Injection

        private readonly IRMCarpetDal _rMCarpetDal;
        private readonly IMapper _mapper;
        private readonly IPlayerHotelService _playerHotelService;

        public RMCarpetManager(IRMCarpetDal rMCarpetDal, IMapper mapper, IPlayerHotelService playerHotelService)
        {
            _rMCarpetDal = rMCarpetDal;
            _mapper = mapper;
            _playerHotelService = playerHotelService;
        }

        #endregion

        public async Task<IResult> AddAsync(RMCarpetAddDto rMCarpetAddDto)
        {
            var rMCarpet = _mapper.Map<RMCarpet>(rMCarpetAddDto);
            await _rMCarpetDal.AddAsync(rMCarpet);
            await _rMCarpetDal.SaveAsync();
            return new SuccessResult("Eklendi");
        }

        public async Task<IResult> DeleteAsync(int Id)
        {
            var rMCarpet = await _rMCarpetDal.GetAsync(rm => rm.Id == Id);
            if (rMCarpet != null)
            {
                await _rMCarpetDal.DeleteAsync(rMCarpet);
                await _rMCarpetDal.SaveAsync();
                return new SuccessResult("Silindi");
            }
            else
            {
                return new ErrorResult("Bulunamadı");
            }
        }

        public async Task<IDataResult<List<RMCarpet>>> GetAllAsync()
        {
            var rMCarpets = await _rMCarpetDal.GetAllAsync();
            if (rMCarpets != null)
            {
                return new SuccessDataResult<List<RMCarpet>>(rMCarpets, "Getirildi");
            }
            else
            {
                return new ErrorDataResult<List<RMCarpet>>(null, "Bulunamadı");
            }
        }

        public async Task<IDataResult<RMCarpet>> GetByIdAsync(int Id)
        {
            var rMCarpet = await _rMCarpetDal.GetAsync(rm => rm.Id == Id);
            if (rMCarpet != null)
            {
                return new SuccessDataResult<RMCarpet>(rMCarpet, "Getirildi");
            }
            else
            {
                return new ErrorDataResult<RMCarpet>(null, "Bulunamdı");
            }
        }

        public async Task<IDataResult<RMCarpet>> GetByLevelAsync(int level)
        {
            var rMCarpet = await _rMCarpetDal.GetAsync(x => x.Level == level);
            if (rMCarpet != null)
            {
                return new SuccessDataResult<RMCarpet>(rMCarpet);
            }
            else
            {
                return new ErrorDataResult<RMCarpet>(null, "Hata");
            }
        }

        public async Task<IResult> UpdateAsync(RMCarpetUpdateDto rMCarpetUpdateDto)
        {
            var oldRMCarpet = await _rMCarpetDal.GetAsync(rm => rm.Id == rMCarpetUpdateDto.Id);
            if (oldRMCarpet != null)
            {
                var mappedRMCarpet = _mapper.Map<RMCarpetUpdateDto, RMCarpet>(rMCarpetUpdateDto, oldRMCarpet);
                var newRMCarpet = await _rMCarpetDal.UpdateAsync(mappedRMCarpet);
                await _rMCarpetDal.SaveAsync();
                return new SuccessDataResult<RMCarpet>(newRMCarpet, "Güncellendi");
            }
            else
            {
                return new ErrorDataResult<RMCarpet>(null, "Bulunamadı");
            }
        }

        public int GetMaksimumLevel()
        {
            var maksimumLevel = _rMCarpetDal.GetMaksimumLevel();
            return maksimumLevel;
        }

        public async Task<IDataResult<int>> UpdateUperLevelAsync(int Id, int PlayerHotelId)
        {
            var oldCarpet = await GetByIdAsync(Id);
            if (oldCarpet.Data != null)
            {
                var upperCarpetLevel = oldCarpet.Data.Level + 1;
                var maksimumLevel = GetMaksimumLevel();
                if (upperCarpetLevel <= maksimumLevel)
                {
                    var upperCarpet = GetByLevelAsync(upperCarpetLevel);
                    var PlayerHotelInformation = _playerHotelService.GetByIdAsync(PlayerHotelId);
                    if (PlayerHotelInformation.Result.Data.HotelMoney >= upperCarpet.Result.Data.Price)
                    {
                        var money = PlayerHotelInformation.Result.Data.HotelMoney - upperCarpet.Result.Data.Price;
                        var QualityPoint = PlayerHotelInformation.Result.Data.HotelQuality + upperCarpet.Result.Data.QualityPoint;
                        var updatePlayerHotel = _playerHotelService.UpdateAsync(new PlayerHotelUpdateDto
                        {
                            Id = PlayerHotelId,
                            HotelMoney = money,
                            HotelLevel = PlayerHotelInformation.Result.Data.HotelLevel,
                            HotelName = PlayerHotelInformation.Result.Data.HotelName,
                            HotelQuality = QualityPoint,
                            HotelTypeId = PlayerHotelInformation.Result.Data.HotelTypeId,
                            CustomerCommentPointAvarage = PlayerHotelInformation.Result.Data.CustomerCommentPointAvarage,
                            UserId = PlayerHotelInformation.Result.Data.UserId
                        });
                        var checkUpperLevelCarpet = await GetByLevelAsync(upperCarpetLevel);
                        if (checkUpperLevelCarpet.Data != null)
                        {
                            var upperLevelCarpetId = checkUpperLevelCarpet.Data.Id;
                            return new SuccessDataResult<int>(upperLevelCarpetId, "Başarılı");
                        }
                    }
                }
            }
            return new ErrorDataResult<int>("En Yüksek Seviye Televizyona Sahipsin");
        }
    }
}
