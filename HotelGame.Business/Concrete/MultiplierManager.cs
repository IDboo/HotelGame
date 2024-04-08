using AutoMapper;
using HotelGame.Business.Abstract;
using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Core.Utilities.Result.Concrete;
using HotelGame.DataAccess.Abstract;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.HotelTypes;
using HotelGame.Entities.DTOs.Multipliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.Business.Concrete
{
    public class MultiplierManager : IMultiplierService
    {

        private readonly IMultiplierDal _multiplierDal;
        private readonly IMapper _mapper;

        public MultiplierManager(IMultiplierDal multiplierDal, IMapper mapper)
        {
            _multiplierDal = multiplierDal;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<Multiplier>>> GetAllAsync()
        {
            var multiplier = await _multiplierDal.GetAllAsync();
            if (multiplier != null)
            {
                return new SuccessDataResult<List<Multiplier>>(multiplier);
            }
            else
            {
                return new ErrorDataResult<List<Multiplier>>(null, "Hata");
            }
        }

        public async Task<IDataResult<Multiplier>> GetByIdAsync(int Id)
        {
            var multiplier = await _multiplierDal.GetAsync(x => x.Id == Id);
            if (multiplier != null)
            {
                return new SuccessDataResult<Multiplier>(multiplier);
            }
            else
            {
                return new ErrorDataResult<Multiplier>(null, "Eror");
            }
        }

        public async Task<IResult> UpdateAsync(MultiplierUpdateDto multiplierUpdateDto)
        {
            var oldMultiplier = await _multiplierDal.GetAsync(x => x.Id == multiplierUpdateDto.Id);
            if (oldMultiplier != null)
            {
                var multiplier = _mapper.Map<MultiplierUpdateDto, Multiplier>(multiplierUpdateDto, oldMultiplier);
                var updatedMultiplier = await _multiplierDal.UpdateAsync(multiplier);
                await _multiplierDal.SaveAsync();
                return new SuccessDataResult<Multiplier>(updatedMultiplier);
            }
            return new ErrorDataResult<Multiplier>("Hata");
        }
    }
}
