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
    public class RMBathRoomManager : IRMBathRoomService
    {
        #region Injection

        private readonly IRMBathRoomDal _rMBathRoomDal;
        private readonly IMapper _mapper;
        private readonly IPlayerHotelService _playerHotelService;

        public RMBathRoomManager(IRMBathRoomDal rMBathRoomDal, IMapper mapper, IPlayerHotelService playerHotelService)
        {
            _rMBathRoomDal = rMBathRoomDal;
            _mapper = mapper;
            _playerHotelService = playerHotelService;
        }

        #endregion

        public async Task<IResult> AddAsync(RMBathRoomAddDto rMBathRoomAddDto)
        {
            var rMBathRoom = _mapper.Map<RMBathRoom>(rMBathRoomAddDto);
            await _rMBathRoomDal.AddAsync(rMBathRoom);
            await _rMBathRoomDal.SaveAsync();
            return new SuccessResult("Eklendi");
        }

        public async Task<IResult> DeleteAsync(int Id)
        {
            var rMBathRoom = await _rMBathRoomDal.GetAsync(rm => rm.Id == Id);
            if (rMBathRoom != null)
            {
                await _rMBathRoomDal.DeleteAsync(rMBathRoom);
                await _rMBathRoomDal.SaveAsync();
                return new SuccessResult("Silindi");
            }
            else
            {
                return new ErrorResult("Bulunamadı");
            }
        }

        public async Task<IDataResult<List<RMBathRoom>>> GetAllAsync()
        {
            var rMBathRooms = await _rMBathRoomDal.GetAllAsync();
            if (rMBathRooms != null)
            {
                return new SuccessDataResult<List<RMBathRoom>>(rMBathRooms, "Getirildi");
            }
            else
            {
                return new ErrorDataResult<List<RMBathRoom>>(null, "Bulunamadı");
            }
        }

        public async Task<IDataResult<RMBathRoom>> GetByIdAsync(int Id)
        {
            var rMBathRoom = await _rMBathRoomDal.GetAsync(rm => rm.Id == Id);
            if (rMBathRoom != null)
            {
                return new SuccessDataResult<RMBathRoom>(rMBathRoom, "Getirildi");
            }
            else
            {
                return new ErrorDataResult<RMBathRoom>(null, "Bulunamdı");
            }
        }

        public async Task<IDataResult<RMBathRoom>> GetByLevelAsync(int level)
        {
            var rMBathRoom = await _rMBathRoomDal.GetAsync(x => x.Level == level);
            if (rMBathRoom != null)
            {
                return new SuccessDataResult<RMBathRoom>(rMBathRoom);
            }
            else
            {
                return new ErrorDataResult<RMBathRoom>(null, "Hata");
            }
        }

        public async Task<IResult> UpdateAsync(RMBathRoomUpdateDto rMBathRoomUpdateDto)
        {
            var oldRMBathRoom = await _rMBathRoomDal.GetAsync(rm => rm.Id == rMBathRoomUpdateDto.Id);
            if (oldRMBathRoom != null)
            {
                var mappedRMBathRoom = _mapper.Map<RMBathRoomUpdateDto, RMBathRoom>(rMBathRoomUpdateDto, oldRMBathRoom);
                var newRMBathRoom = await _rMBathRoomDal.UpdateAsync(mappedRMBathRoom);
                await _rMBathRoomDal.SaveAsync();
                return new SuccessDataResult<RMBathRoom>(newRMBathRoom, "Güncellendi");
            }
            else
            {
                return new ErrorDataResult<RMBathRoom>(null, "Bulunamadı");
            }
        }

        public int GetMaksimumLevel()
        {
            var maksimumLevel = _rMBathRoomDal.GetMaksimumLevel();
            return maksimumLevel;
        }
        public async Task<IDataResult<int>> UpdateUperLevelAsync(int Id, int PlayerHotelId)
        {
            var oldBathRoom = await GetByIdAsync(Id);
            if (oldBathRoom.Data != null)
            {
                var upperBathRoomLevel = oldBathRoom.Data.Level + 1;
                var maksimumLevel = GetMaksimumLevel();
                if (upperBathRoomLevel <= maksimumLevel)
                {
                    var upperBathRoom = GetByLevelAsync(upperBathRoomLevel);
                    var PlayerHotelInformation = _playerHotelService.GetByIdAsync(PlayerHotelId);
                    if (PlayerHotelInformation.Result.Data.HotelMoney >= upperBathRoom.Result.Data.Price)
                    {
                        var money = PlayerHotelInformation.Result.Data.HotelMoney - upperBathRoom.Result.Data.Price;
                        var QualityPoint = PlayerHotelInformation.Result.Data.HotelQuality + upperBathRoom.Result.Data.QualityPoint;
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
                        var checkUpperLevelBathRoom = await GetByLevelAsync(upperBathRoomLevel);
                        if (checkUpperLevelBathRoom.Data != null)
                        {
                            var upperLevelBathRoomId = checkUpperLevelBathRoom.Data.Id;
                            return new SuccessDataResult<int>(upperLevelBathRoomId, "Başarılı");
                        }
                    }
                }
            }
            return new ErrorDataResult<int>("En Yüksek Seviye Televizyona Sahipsin");
        }
    }
}
