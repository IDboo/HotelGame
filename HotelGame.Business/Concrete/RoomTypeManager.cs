using AutoMapper;
using HotelGame.Business.Abstract;
using HotelGame.Business.Constans;
using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Core.Utilities.Result.Concrete;
using HotelGame.DataAccess.Abstract;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.RoomTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelGame.Business.Concrete
{
    public class RoomTypeManager : IRoomTypeService
    {
        #region Injection

        private readonly IRoomTypeDal _roomTypeDal;
        private readonly IMapper _mapper;

        public RoomTypeManager(IRoomTypeDal roomTypeDal, IMapper mapper)
        {
            _roomTypeDal = roomTypeDal;
            _mapper = mapper;
        }

        #endregion

        public async Task<IResult> AddAsync(RoomTypeAddDto roomTypeAddDto)
        {
            var roomType = _mapper.Map<RoomType>(roomTypeAddDto);
            await _roomTypeDal.AddAsync(roomType);
            await _roomTypeDal.SaveAsync();
            return new SuccessResult(Messages.RoomTypeAdded);
        }

        public async Task<IResult> DeleteAsync(int Id)
        {
            var roomType = await _roomTypeDal.GetAsync(rt => rt.Id == Id);
            if (roomType != null)
            {
                await _roomTypeDal.DeleteAsync(roomType);
                await _roomTypeDal.SaveAsync();
                return new SuccessResult(Messages.RoomTypeDeleted);
            }
            else
            {
                return new ErrorResult(Messages.RoomTypeNotFound);
            }
        }

        public async Task<IDataResult<List<RoomType>>> GetAllAsync()
        {
            var roomTypes = await _roomTypeDal.GetAllAsync();
            if (roomTypes != null)
            {
                return new SuccessDataResult<List<RoomType>>(roomTypes, Messages.RoomTypeListed);
            }
            else
            {
                return new ErrorDataResult<List<RoomType>>(null, Messages.RoomTypeNotFound);
            }
        }

        public async Task<IDataResult<RoomType>> GetByIdAsync(int Id)
        {
            var roomType = await _roomTypeDal.GetAsync(rt => rt.Id == Id);
            if (roomType != null)
            {
                return new SuccessDataResult<RoomType>(roomType, Messages.RoomTypeGeted);
            }
            else
            {
                return new ErrorDataResult<RoomType>(null, Messages.RoomTypeNotFound);
            }
        }

        public async Task<IResult> UpdateAsync(RoomTypeUpdateDto roomTypeUpdateDto)
        {
            var oldRoomType = await _roomTypeDal.GetAsync(rt => rt.Id == roomTypeUpdateDto.Id);
            if (oldRoomType != null)
            {
                var mappedRoomType = _mapper.Map<RoomTypeUpdateDto, RoomType>(roomTypeUpdateDto, oldRoomType);
                var newRoomType = await _roomTypeDal.UpdateAsync(mappedRoomType);
                await _roomTypeDal.SaveAsync();
                return new SuccessDataResult<RoomType>(newRoomType, Messages.RoomTypeUpdated);
            }
            else
            {
                return new ErrorDataResult<RoomType>(null, Messages.RoomTypeNotFound);
            }
        }
    }
}
