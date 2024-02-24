using AutoMapper;
using HotelGame.Business.Abstract;
using HotelGame.Business.Constans;
using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Core.Utilities.Result.Concrete;
using HotelGame.DataAccess.Abstract;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.HotelTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.Business.Concrete
{
    public class HotelTypeManager : IHotelTypeService
    {
        #region Injection

        private readonly IHotelTypeDal _hotelTypeDal;
        private readonly IMapper _mapper;

        public HotelTypeManager(IHotelTypeDal hotelTypeDal, IMapper mapper)
        {
            _hotelTypeDal = hotelTypeDal;
            _mapper = mapper;
        }

        #endregion




        public async Task<IResult> AddAsync(HotelTypeAddDto hotelTypeAddDto)
        {
            var hotelType = _mapper.Map<HotelType>(hotelTypeAddDto);
            await _hotelTypeDal.AddAsync(hotelType);
            await _hotelTypeDal.SaveAsync();
            return new SuccessResult(Messages.HotelTypeAdded);

        }

        public async Task<IResult> DeleteAsync(int Id)
        {
            var hotelType = await _hotelTypeDal.GetAsync(h => h.Id == Id);
            if (hotelType != null) 
            {
                await _hotelTypeDal.DeleteAsync(hotelType);
                await _hotelTypeDal.SaveAsync();
                return new SuccessResult(Messages.HotelTypeDeleted);
            }
            else
            {
                return new ErrorResult(Messages.HotelTypeNotFound);
            }
        }

        public async Task<IDataResult<List<HotelType>>> GetAllAsync()
        {
            var hotelTypes = await _hotelTypeDal.GetAllAsync();
            if (hotelTypes != null)
            {
                return new SuccessDataResult<List<HotelType>>(hotelTypes , Messages.HotelTypeListed);
            }
            else
            {
                return new ErrorDataResult<List<HotelType>>(null , Messages.HotelTypeNotFound);
            }
        }

        public async Task<IDataResult<HotelType>> GetByIdAsync(int Id)
        {
            var hotelType = await _hotelTypeDal.GetAsync(h => h.Id == Id);
            if (hotelType != null) 
            {
                return new SuccessDataResult<HotelType>(hotelType, Messages.HotelTypeGeted);
            }
            else
            {
                return new ErrorDataResult<HotelType>(null , Messages.HotelTypeNotFound);
            }
        }

        public async Task<IResult> UpdateAsync(HotelTypeUpdateDto hotelTypeUpdateDto)
        {
            var oldHotelType = await _hotelTypeDal.GetAsync(h => h.Id == hotelTypeUpdateDto.Id);
            if (oldHotelType != null)
            {
                var mappedHotelType = _mapper.Map<HotelTypeUpdateDto, HotelType>(hotelTypeUpdateDto , oldHotelType);
                var newHotelType =  await _hotelTypeDal.UpdateAsync(mappedHotelType);
                await _hotelTypeDal.SaveAsync();
                return new SuccessDataResult<HotelType>(newHotelType , Messages.HotelTypeUpdated);
            }
            else
            {
                return new ErrorDataResult<HotelType>(null, Messages.HotelTypeNotFound);
            }
        }
    }
}
