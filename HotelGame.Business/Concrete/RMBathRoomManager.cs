using AutoMapper;
using HotelGame.Business.Abstract;
using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Core.Utilities.Result.Concrete;
using HotelGame.DataAccess.Abstract;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.RoomMaterial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.Business.Concrete
{
    public class RMBathRoomManager : IRMBathRoomService
    {
        #region Injection

        private readonly IRMBathRoomDal _rMBathRoomDal;
        private readonly IMapper _mapper;

        public RMBathRoomManager(IRMBathRoomDal rMBathRoomDal, IMapper mapper)
        {
            _rMBathRoomDal = rMBathRoomDal;
            _mapper = mapper;
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

        public async Task<IResult> UpdateAsync(RMBathRoomUpdateDto rMBathRoomUpdateDto)
        {
            var oldRMBathRoom = await _rMBathRoomDal.GetAsync(rm => rm.Id == rMBathRoomUpdateDto.Id);
            if (oldRMBathRoom != null)
            {
                var mappedRMBathRoom = _mapper.Map<RMBathRoomUpdateDto, RMBathRoom>(rMBathRoomUpdateDto, oldRMBathRoom);
                var newRMBathRoom = await _rMBathRoomDal.UpdateAsync(mappedRMBathRoom);
                await _rMBathRoomDal.SaveAsync();
                return new SuccessDataResult<RMBathRoom>(newRMBathRoom, "Gübcellendi");
            }
            else
            {
                return new ErrorDataResult<RMBathRoom>(null, "Bulunamadı");
            }
        }


    }
}
