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
    public class RMAirConditionManager : IRMAirConditionService
    {
        #region Injection

        private readonly IRMAirConditionDal _rMAirConditionDal;
        private readonly IMapper _mapper;
        private readonly IPlayerHotelService _playerHotelService;

        public RMAirConditionManager(IRMAirConditionDal rMAirConditionDal, IMapper mapper, IPlayerHotelService playerHotelService)
        {
            _rMAirConditionDal = rMAirConditionDal;
            _mapper = mapper;
            _playerHotelService = playerHotelService;
        }

        #endregion

        public async Task<IResult> AddAsync(RMAirConditionAddDto rMAirConditionAddDto)
        {
            var rMAirCondition = _mapper.Map<RMAirCondition>(rMAirConditionAddDto);
            await _rMAirConditionDal.AddAsync(rMAirCondition);
            await _rMAirConditionDal.SaveAsync();
            return new SuccessResult("Eklendi");
        }

        public async Task<IResult> DeleteAsync(int Id)
        {
            var rMAirCondition = await _rMAirConditionDal.GetAsync(rm => rm.Id == Id);
            if (rMAirCondition != null)
            {
                await _rMAirConditionDal.DeleteAsync(rMAirCondition);
                await _rMAirConditionDal.SaveAsync();
                return new SuccessResult("Silindi");
            }
            else
            {
                return new ErrorResult("Bulunamadı");
            }
        }

        public async Task<IDataResult<List<RMAirCondition>>> GetAllAsync()
        {
            var rMAirConditions = await _rMAirConditionDal.GetAllAsync();
            if (rMAirConditions != null)
            {
                return new SuccessDataResult<List<RMAirCondition>>(rMAirConditions, "Getirildi");
            }
            else
            {
                return new ErrorDataResult<List<RMAirCondition>>(null, "Bulunamadı");
            }
        }

        public async Task<IDataResult<RMAirCondition>> GetByIdAsync(int Id)
        {
            var rMAirCondition = await _rMAirConditionDal.GetAsync(rm => rm.Id == Id);
            if (rMAirCondition != null)
            {
                return new SuccessDataResult<RMAirCondition>(rMAirCondition, "Getirildi");
            }
            else
            {
                return new ErrorDataResult<RMAirCondition>(null, "Bulunamdı");
            }
        }

        public async Task<IDataResult<RMAirCondition>> GetByLevelAsync(int level)
        {
            var rMAirCondition = await _rMAirConditionDal.GetAsync(x => x.Level == level);
            if (rMAirCondition != null)
            {
                return new SuccessDataResult<RMAirCondition>(rMAirCondition);
            }
            else
            {
                return new ErrorDataResult<RMAirCondition>(null, "Hata");
            }
        }

        public async Task<IResult> UpdateAsync(RMAirConditionUpdateDto rMAirConditionUpdateDto)
        {
            var oldRMAirCondition = await _rMAirConditionDal.GetAsync(rm => rm.Id == rMAirConditionUpdateDto.Id);
            if (oldRMAirCondition != null)
            {
                var mappedRMAirCondition = _mapper.Map<RMAirConditionUpdateDto, RMAirCondition>(rMAirConditionUpdateDto, oldRMAirCondition);
                var newRMAirCondition = await _rMAirConditionDal.UpdateAsync(mappedRMAirCondition);
                await _rMAirConditionDal.SaveAsync();
                return new SuccessDataResult<RMAirCondition>(newRMAirCondition, "Güncellendi");
            }
            else
            {
                return new ErrorDataResult<RMAirCondition>(null, "Bulunamadı");
            }
        }

        public int GetMaksimumLevel()
        {
            var maksimumLevel = _rMAirConditionDal.GetMaksimumLevel();
            return maksimumLevel;
        }

        public async Task<IDataResult<int>> UpdateUperLevelAsync(int Id, int PlayerHotelId)
        {
            var oldAirCondition = await GetByIdAsync(Id);
            if (oldAirCondition.Data != null)
            {
                var upperAirConditionLevel = oldAirCondition.Data.Level + 1;
                var maksimumLevel = GetMaksimumLevel();
                if (upperAirConditionLevel <= maksimumLevel)
                {
                    var upperAirCondition = GetByLevelAsync(upperAirConditionLevel);
                    var PlayerHotelInformation = _playerHotelService.GetByIdAsync(PlayerHotelId);
                    if (PlayerHotelInformation.Result.Data.HotelMoney >= upperAirCondition.Result.Data.Price)
                    {
                        var money = PlayerHotelInformation.Result.Data.HotelMoney - upperAirCondition.Result.Data.Price;
                        var QualityPoint = PlayerHotelInformation.Result.Data.HotelQuality + upperAirCondition.Result.Data.QualityPoint;
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
                        var checkUpperLevelAirCondition = await GetByLevelAsync(upperAirConditionLevel);
                        if (checkUpperLevelAirCondition.Data != null)
                        {
                            var upperLevelAirConditionId = checkUpperLevelAirCondition.Data.Id;
                            return new SuccessDataResult<int>(upperLevelAirConditionId, "Başarılı");
                        }
                    }
                }
            }
            return new ErrorDataResult<int>("En Yüksek Seviye Televizyona Sahipsin");
        }
    }
}
