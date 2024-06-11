using AutoMapper;
using HotelGame.Business.Abstract;
using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Core.Utilities.Result.Concrete;
using HotelGame.DataAccess.Abstract;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.PlayerHotels;
using HotelGame.Entities.DTOs.RoomMaterial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.Business.Concrete
{
    public class RMTelevisionManager : IRMTelevisionService
    {
        #region Injection

        private readonly IRMTelevisionDal _rMTelevisionDal;
        private readonly IMapper _mapper;
        private readonly IPlayerHotelService _playerHotelService;

        public RMTelevisionManager(IRMTelevisionDal rMTelevisionDal, IMapper mapper, IPlayerHotelService playerHotelService)
        {
            _rMTelevisionDal = rMTelevisionDal;
            _mapper = mapper;
            _playerHotelService = playerHotelService;
        }

        #endregion

        public async Task<IResult> AddAsync(RMTelevisionAddDto rMTelevisionAddDto)
        {
            var rMTelevision = _mapper.Map<RMTelevision>(rMTelevisionAddDto);
            await _rMTelevisionDal.AddAsync(rMTelevision);
            await _rMTelevisionDal.SaveAsync();
            return new SuccessResult("Eklendi");
        }

        public async Task<IResult> DeleteAsync(int Id)
        {
            var rMTelevision = await _rMTelevisionDal.GetAsync(rm => rm.Id == Id);
            if (rMTelevision != null)
            {
                await _rMTelevisionDal.DeleteAsync(rMTelevision);
                await _rMTelevisionDal.SaveAsync();
                return new SuccessResult("Silindi");
            }
            else
            {
                return new ErrorResult("Bulunamadı");
            }
        }

        public async Task<IDataResult<List<RMTelevision>>> GetAllAsync()
        {
            var rMTelevisions = await _rMTelevisionDal.GetAllAsync();
            if (rMTelevisions != null)
            {
                return new SuccessDataResult<List<RMTelevision>>(rMTelevisions, "Getirildi");
            }
            else
            {
                return new ErrorDataResult<List<RMTelevision>>(null, "Bulunamadı");
            }
        }

        public async Task<IDataResult<RMTelevision>> GetByIdAsync(int Id)
        {
            var rMTelevision = await _rMTelevisionDal.GetAsync(rm => rm.Id == Id);
            if (rMTelevision != null)
            {
                return new SuccessDataResult<RMTelevision>(rMTelevision, "Getirildi");
            }
            else
            {
                return new ErrorDataResult<RMTelevision>(null, "Bulunamdı");
            }
        }

        public async Task<IDataResult<RMTelevision>> GetByLevelAsync(int level)
        {
            var rmTelevision = await _rMTelevisionDal.GetAsync(x=> x.Level == level);

            if (rmTelevision != null)
            {
                return new SuccessDataResult<RMTelevision>(rmTelevision);
            }
            else
            {
                return new ErrorDataResult<RMTelevision>(null, "Hata");
            }
        }

        public async Task<IResult> UpdateAsync(RMTelevisionUpdateDto rMTelevisionUpdateDto)
        {
            var oldRMTelevision = await _rMTelevisionDal.GetAsync(rm => rm.Id == rMTelevisionUpdateDto.Id);
            if (oldRMTelevision != null)
            {
                var mappedRMTelevision = _mapper.Map<RMTelevisionUpdateDto, RMTelevision>(rMTelevisionUpdateDto, oldRMTelevision);
                var newRMTelevision = await _rMTelevisionDal.UpdateAsync(mappedRMTelevision);
                await _rMTelevisionDal.SaveAsync();
                return new SuccessDataResult<RMTelevision>(newRMTelevision, "Gübcellendi");
            }
            else
            {
                return new ErrorDataResult<RMTelevision>(null, "Bulunamadı");
            }
        }


        public int GetMaksimumLevel()
        {
            var maksimumLevel = _rMTelevisionDal.GetMaksimumLevel();
            return maksimumLevel;
        }

        public async Task<IDataResult<int>> UpdateUperLevelAsync(int Id, int PlayerHotelId)
        {
            var oldTelevision = await GetByIdAsync(Id);
            if (oldTelevision.Data != null)
            {
                var upperTelevisionLevel = oldTelevision.Data.Level + 1;
                var maksimumLevel = GetMaksimumLevel();
                if (upperTelevisionLevel<= maksimumLevel)
                {
                    var upperTelevision = GetByLevelAsync(upperTelevisionLevel);
                    var PlayerHotelInformation = _playerHotelService.GetByIdAsync(PlayerHotelId);
                    if (PlayerHotelInformation.Result.Data.HotelMoney >= upperTelevision.Result.Data.Price)
                    {
                        var money = PlayerHotelInformation.Result.Data.HotelMoney - upperTelevision.Result.Data.Price;
                        var QualityPoint = PlayerHotelInformation.Result.Data.HotelQuality + upperTelevision.Result.Data.QualityPoint;
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
                        var checkUpperLevelTelevision = await GetByLevelAsync(upperTelevisionLevel);
                        if (checkUpperLevelTelevision.Data != null)
                        {
                            var upperLevelTelevisionId = checkUpperLevelTelevision.Data.Id;
                            return new SuccessDataResult<int>(upperLevelTelevisionId, "Başarılı");
                        }
                    }
                }
            }  
            return new ErrorDataResult<int>("En Yüksek Seviye Televizyona Sahipsin");
        }
    }
}
