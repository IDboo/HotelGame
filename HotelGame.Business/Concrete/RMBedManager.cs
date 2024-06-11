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
    public class RMBedManager : IRMBedService
    {
        #region Injection

        private readonly IRMBedDal _rMBedDal;
        private readonly IMapper _mapper;
        private readonly IPlayerHotelService _playerHotelService;

        public RMBedManager(IRMBedDal rMBedDal, IMapper mapper, IPlayerHotelService playerHotelService)
        {
            _rMBedDal = rMBedDal;
            _mapper = mapper;
            _playerHotelService = playerHotelService;
        }

        #endregion

        public async Task<IResult> AddAsync(RMBedAddDto rMBedAddDto)
        {
            var rMBed = _mapper.Map<RMBed>(rMBedAddDto);
            await _rMBedDal.AddAsync(rMBed);
            await _rMBedDal.SaveAsync();
            return new SuccessResult("Eklendi");
        }

        public async Task<IResult> DeleteAsync(int Id)
        {
            var rMBed = await _rMBedDal.GetAsync(rm => rm.Id == Id);
            if (rMBed != null)
            {
                await _rMBedDal.DeleteAsync(rMBed);
                await _rMBedDal.SaveAsync();
                return new SuccessResult("Silindi");
            }
            else
            {
                return new ErrorResult("Bulunamadı");
            }
        }

        public async Task<IDataResult<List<RMBed>>> GetAllAsync()
        {
            var rMBeds = await _rMBedDal.GetAllAsync();
            if (rMBeds != null)
            {
                return new SuccessDataResult<List<RMBed>>(rMBeds, "Getirildi");
            }
            else
            {
                return new ErrorDataResult<List<RMBed>>(null, "Bulunamadı");
            }
        }

        public async Task<IDataResult<RMBed>> GetByIdAsync(int Id)
        {
            var rMBed = await _rMBedDal.GetAsync(rm => rm.Id == Id);
            if (rMBed != null)
            {
                return new SuccessDataResult<RMBed>(rMBed, "Getirildi");
            }
            else
            {
                return new ErrorDataResult<RMBed>(null, "Bulunamdı");
            }
        }

        public async Task<IDataResult<RMBed>> GetByLevelAsync(int level)
        {
            var rMBed = await _rMBedDal.GetAsync(x => x.Level == level);
            if (rMBed != null)
            {
                return new SuccessDataResult<RMBed>(rMBed);
            }
            else
            {
                return new ErrorDataResult<RMBed>(null, "Hata");
            }
        }

        public async Task<IResult> UpdateAsync(RMBedUpdateDto rMBedUpdateDto)
        {
            var oldRMBed = await _rMBedDal.GetAsync(rm => rm.Id == rMBedUpdateDto.Id);
            if (oldRMBed != null)
            {
                var mappedRMBed = _mapper.Map<RMBedUpdateDto, RMBed>(rMBedUpdateDto, oldRMBed);
                var newRMBed = await _rMBedDal.UpdateAsync(mappedRMBed);
                await _rMBedDal.SaveAsync();
                return new SuccessDataResult<RMBed>(newRMBed, "Güncellendi");
            }
            else
            {
                return new ErrorDataResult<RMBed>(null, "Bulunamadı");
            }
        }

        public int GetMaksimumLevel()
        {
            var maksimumLevel = _rMBedDal.GetMaksimumLevel();
            return maksimumLevel;
        }

        public async Task<IDataResult<int>> UpdateUperLevelAsync(int Id, int PlayerHotelId)
        {
            var oldBed = await GetByIdAsync(Id);
            if (oldBed.Data != null)
            {
                var upperBedLevel = oldBed.Data.Level + 1;
                var maksimumLevel = GetMaksimumLevel();
                if (upperBedLevel <= maksimumLevel)
                {
                    var upperBed = GetByLevelAsync(upperBedLevel);
                    var PlayerHotelInformation = _playerHotelService.GetByIdAsync(PlayerHotelId);
                    if (PlayerHotelInformation.Result.Data.HotelMoney >= upperBed.Result.Data.Price)
                    {
                        var money = PlayerHotelInformation.Result.Data.HotelMoney - upperBed.Result.Data.Price;
                        var QualityPoint = PlayerHotelInformation.Result.Data.HotelQuality + upperBed.Result.Data.QualityPoint;
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
                        var checkUpperLevelBed = await GetByLevelAsync(upperBedLevel);
                        if (checkUpperLevelBed.Data != null)
                        {
                            var upperLevelBedId = checkUpperLevelBed.Data.Id;
                            return new SuccessDataResult<int>(upperLevelBedId, "Başarılı");
                        }
                    }
                }
            }
            return new ErrorDataResult<int>("En Yüksek Seviye Televizyona Sahipsin");
        }
    }
}
