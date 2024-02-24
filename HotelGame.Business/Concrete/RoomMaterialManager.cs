using AutoMapper;
using HotelGame.Business.Abstract;
using HotelGame.Business.Constans;
using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Core.Utilities.Result.Concrete;
using HotelGame.DataAccess.Abstract;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.RoomMaterials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.Business.Concrete
{
    public class RoomMaterialManager : IRoomMaterialService
    {
        #region Injection

        private readonly IRoomMaterialDal _roomMaterialDal;
        private readonly IMapper _mapper;

        public RoomMaterialManager(IRoomMaterialDal roomMaterialDal, IMapper mapper)
        {
            _roomMaterialDal = roomMaterialDal;
            _mapper = mapper;
        }

        #endregion

        public async Task<IResult> AddAsync(RoomMaterialAddDto roomMaterialAddDto)
        {
            var roomMaterial = _mapper.Map<RoomMaterial>(roomMaterialAddDto);
            await _roomMaterialDal.AddAsync(roomMaterial);
            await _roomMaterialDal.SaveAsync();
            return new SuccessResult(Messages.RoomMaterialAdded);
        }

        public async Task<IResult> DeleteAsync(int Id)
        {
            var roomMaterial = await _roomMaterialDal.GetAsync(rm => rm.Id == Id);
            if (roomMaterial != null)
            {
                await _roomMaterialDal.DeleteAsync(roomMaterial);
                await _roomMaterialDal.SaveAsync();
                return new SuccessResult(Messages.RoomMaterialDeleted);
            }
            else
            {
                return new ErrorResult(Messages.RoomMaterialNotFound);
            }
        }

        public async Task<IDataResult<List<RoomMaterial>>> GetAllAsync()
        {
            var roomMaterials = await _roomMaterialDal.GetAllAsync();
            if (roomMaterials != null)
            {
                return new SuccessDataResult<List<RoomMaterial>>(roomMaterials, Messages.RoomMaterialListed);
            }
            else
            {
                return new ErrorDataResult<List<RoomMaterial>>(null, Messages.RoomMaterialNotFound);
            }
        }

        public async Task<IDataResult<RoomMaterial>> GetByIdAsync(int Id)
        {
            var roomMaterial = await _roomMaterialDal.GetAsync(rm => rm.Id == Id);
            if (roomMaterial != null)
            {
                return new SuccessDataResult<RoomMaterial>(roomMaterial, Messages.RoomMaterialGeted);
            }
            else
            {
                return new ErrorDataResult<RoomMaterial>(null, Messages.RoomMaterialNotFound);
            }
        }

        public async Task<IResult> UpdateAsync(RoomMaterialUpdateDto roomMaterialUpdateDto)
        {
            var oldRoomMaterial = await _roomMaterialDal.GetAsync(rm => rm.Id == roomMaterialUpdateDto.Id);
            if (oldRoomMaterial != null)
            {
                var mappedRoomMaterial = _mapper.Map<RoomMaterialUpdateDto, RoomMaterial>(roomMaterialUpdateDto, oldRoomMaterial);
                var newRoomMaterial = await _roomMaterialDal.UpdateAsync(mappedRoomMaterial);
                await _roomMaterialDal.SaveAsync();
                return new SuccessDataResult<RoomMaterial>(newRoomMaterial, Messages.RoomMaterialUpdated);
            }
            else
            {
                return new ErrorDataResult<RoomMaterial>(null, Messages.RoomMaterialNotFound);
            }
        }
    }
}
