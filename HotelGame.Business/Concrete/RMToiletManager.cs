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
    public class RMToiletManager : IRMToiletService
    {
        #region Injection

        private readonly IRMToiletDal _rMToiletDal;
        private readonly IMapper _mapper;
        private readonly IPlayerHotelService _playerHotelService;

        public RMToiletManager(IRMToiletDal rMToiletDal, IMapper mapper, IPlayerHotelService playerHotelService)
        {
            _rMToiletDal = rMToiletDal;
            _mapper = mapper;
            _playerHotelService = playerHotelService;
        }

        #endregion

        public async Task<IResult> AddAsync(RMToiletAddDto rMToiletAddDto)
        {
            var rMToilet = _mapper.Map<RMToilet>(rMToiletAddDto);
            await _rMToiletDal.AddAsync(rMToilet);
            await _rMToiletDal.SaveAsync();
            return new SuccessResult("Eklendi");
        }

        public async Task<IResult> DeleteAsync(int Id)
        {
            var rMToilet = await _rMToiletDal.GetAsync(rm => rm.Id == Id);
            if (rMToilet != null)
            {
                await _rMToiletDal.DeleteAsync(rMToilet);
                await _rMToiletDal.SaveAsync();
                return new SuccessResult("Silindi");
            }
            else
            {
                return new ErrorResult("Bulunamadı");
            }
        }

        public async Task<IDataResult<List<RMToilet>>> GetAllAsync()
        {
            var rMToilets = await _rMToiletDal.GetAllAsync();
            if (rMToilets != null)
            {
                return new SuccessDataResult<List<RMToilet>>(rMToilets, "Getirildi");
            }
            else
            {
                return new ErrorDataResult<List<RMToilet>>(null, "Bulunamadı");
            }
        }

        public async Task<IDataResult<RMToilet>> GetByIdAsync(int Id)
        {
            var rMToilet = await _rMToiletDal.GetAsync(rm => rm.Id == Id);
            if (rMToilet != null)
            {
                return new SuccessDataResult<RMToilet>(rMToilet, "Getirildi");
            }
            else
            {
                return new ErrorDataResult<RMToilet>(null, "Bulunamdı");
            }
        }

        public async Task<IDataResult<RMToilet>> GetByLevelAsync(int level)
        {
            var rMToilet = await _rMToiletDal.GetAsync(x => x.Level == level);
            if (rMToilet != null)
            {
                return new SuccessDataResult<RMToilet>(rMToilet);
            }
            else
            {
                return new ErrorDataResult<RMToilet>(null, "Hata");
            }
        }

        public async Task<IResult> UpdateAsync(RMToiletUpdateDto rMToiletUpdateDto)
        {
            var oldRMToilet = await _rMToiletDal.GetAsync(rm => rm.Id == rMToiletUpdateDto.Id);
            if (oldRMToilet != null)
            {
                var mappedRMToilet = _mapper.Map<RMToiletUpdateDto, RMToilet>(rMToiletUpdateDto, oldRMToilet);
                var newRMToilet = await _rMToiletDal.UpdateAsync(mappedRMToilet);
                await _rMToiletDal.SaveAsync();
                return new SuccessDataResult<RMToilet>(newRMToilet, "Güncellendi");
            }
            else
            {
                return new ErrorDataResult<RMToilet>(null, "Bulunamadı");
            }
        }

        public int GetMaksimumLevel()
        {
            var maksimumLevel = _rMToiletDal.GetMaksimumLevel();
            return maksimumLevel;
        }

        public async Task<IDataResult<int>> UpdateUperLevelAsync(int Id, int PlayerHotelId)
        {
            var oldToilet = await GetByIdAsync(Id);
            if (oldToilet.Data != null)
            {
                var upperToiletLevel = oldToilet.Data.Level + 1;
                var maksimumLevel = GetMaksimumLevel();
                if (upperToiletLevel <= maksimumLevel)
                {
                    var upperToilet = GetByLevelAsync(upperToiletLevel);
                    var PlayerHotelInformation = _playerHotelService.GetByIdAsync(PlayerHotelId);
                    if (PlayerHotelInformation.Result.Data.HotelMoney >= upperToilet.Result.Data.Price)
                    {
                        var money = PlayerHotelInformation.Result.Data.HotelMoney - upperToilet.Result.Data.Price;
                        var QualityPoint = PlayerHotelInformation.Result.Data.HotelQuality + upperToilet.Result.Data.QualityPoint;
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
                        var checkUpperLevelToilet = await GetByLevelAsync(upperToiletLevel);
                        if (checkUpperLevelToilet.Data != null)
                        {
                            var upperLevelToiletId = checkUpperLevelToilet.Data.Id;
                            return new SuccessDataResult<int>(upperLevelToiletId, "Başarılı");
                        }
                    }
                }
            }
            return new ErrorDataResult<int>("En Yüksek Seviye Televizyona Sahipsin");
        }
    }
}
