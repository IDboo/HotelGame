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
    public class RMBedManager : IRMBedService
    {
        #region Injection

        private readonly IRMBedDal _rMBedDal;
        private readonly IMapper _mapper;

        public RMBedManager(IRMBedDal rMBedDal, IMapper mapper)
        {
            _rMBedDal = rMBedDal;
            _mapper = mapper;
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

        public async Task<IResult> UpdateAsync(RMBedUpdateDto rMBedUpdateDto)
        {
            var oldRMBed = await _rMBedDal.GetAsync(rm => rm.Id == rMBedUpdateDto.Id);
            if (oldRMBed != null)
            {
                var mappedRMBed = _mapper.Map<RMBedUpdateDto, RMBed>(rMBedUpdateDto, oldRMBed);
                var newRMBed = await _rMBedDal.UpdateAsync(mappedRMBed);
                await _rMBedDal.SaveAsync();
                return new SuccessDataResult<RMBed>(newRMBed, "Gübcellendi");
            }
            else
            {
                return new ErrorDataResult<RMBed>(null, "Bulunamadı");
            }
        }


    }
}
