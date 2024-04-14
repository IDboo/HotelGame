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
    public class RMTelevisionManager : IRMTelevisionService
    {
        #region Injection

        private readonly IRMTelevisionDal _rMTelevisionDal;
        private readonly IMapper _mapper;

        public RMTelevisionManager(IRMTelevisionDal rMTelevisionDal, IMapper mapper)
        {
            _rMTelevisionDal = rMTelevisionDal;
            _mapper = mapper;
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


    }
}
