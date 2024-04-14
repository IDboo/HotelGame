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
    public class RMCarpetManager : IRMCarpetService
    {
        #region Injection

        private readonly IRMCarpetDal _rMCarpetDal;
        private readonly IMapper _mapper;

        public RMCarpetManager(IRMCarpetDal rMCarpetDal, IMapper mapper)
        {
            _rMCarpetDal = rMCarpetDal;
            _mapper = mapper;
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

        public async Task<IResult> UpdateAsync(RMCarpetUpdateDto rMCarpetUpdateDto)
        {
            var oldRMCarpet = await _rMCarpetDal.GetAsync(rm => rm.Id == rMCarpetUpdateDto.Id);
            if (oldRMCarpet != null)
            {
                var mappedRMCarpet = _mapper.Map<RMCarpetUpdateDto, RMCarpet>(rMCarpetUpdateDto, oldRMCarpet);
                var newRMCarpet = await _rMCarpetDal.UpdateAsync(mappedRMCarpet);
                await _rMCarpetDal.SaveAsync();
                return new SuccessDataResult<RMCarpet>(newRMCarpet, "Gübcellendi");
            }
            else
            {
                return new ErrorDataResult<RMCarpet>(null, "Bulunamadı");
            }
        }


    }
}
