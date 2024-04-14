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
    public class RMAirConditionManager : IRMAirConditionService
    {
        #region Injection

        private readonly IRMAirConditionDal _rMAirConditionDal;
        private readonly IMapper _mapper;

        public RMAirConditionManager(IRMAirConditionDal rMAirConditionDal, IMapper mapper)
        {
            _rMAirConditionDal = rMAirConditionDal;
            _mapper = mapper;
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

        public async Task<IResult> UpdateAsync(RMAirConditionUpdateDto rMAirConditionUpdateDto)
        {
            var oldRMAirCondition = await _rMAirConditionDal.GetAsync(rm => rm.Id == rMAirConditionUpdateDto.Id);
            if (oldRMAirCondition != null)
            {
                var mappedRMAirCondition = _mapper.Map<RMAirConditionUpdateDto, RMAirCondition>(rMAirConditionUpdateDto, oldRMAirCondition);
                var newRMAirCondition = await _rMAirConditionDal.UpdateAsync(mappedRMAirCondition);
                await _rMAirConditionDal.SaveAsync();
                return new SuccessDataResult<RMAirCondition>(newRMAirCondition, "Gübcellendi");
            }
            else
            {
                return new ErrorDataResult<RMAirCondition>(null, "Bulunamadı");
            }
        }


    }
}
