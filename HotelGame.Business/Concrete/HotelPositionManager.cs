using AutoMapper;
using HotelGame.Business.Abstract;
using HotelGame.Business.Constans;
using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Core.Utilities.Result.Concrete;
using HotelGame.DataAccess.Abstract;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.HotelPositions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelGame.Business.Concrete
{
    public class HotelPositionManager : IHotelPositionService
    {
        private readonly IHotelPositionDal _hotelPositionDal;
        private readonly IMapper _mapper;

        public HotelPositionManager(IHotelPositionDal hotelPositionDal, IMapper mapper)
        {
            _hotelPositionDal = hotelPositionDal;
            _mapper = mapper;
        }

        public async Task<IResult> AddAsync(HotelPositionAddDto hotelPositionAddDto)
        {
            var hotelPosition = _mapper.Map<HotelPosition>(hotelPositionAddDto);
            await _hotelPositionDal.AddAsync(hotelPosition);
            await _hotelPositionDal.SaveAsync();
            return new SuccessResult(Messages.HotelPositionAdded);
        }

        public async Task<IResult> DeleteAsync(int Id)
        {
            var hotelPosition = await _hotelPositionDal.GetAsync(h => h.Id == Id);
            if (hotelPosition != null)
            {
                await _hotelPositionDal.DeleteAsync(hotelPosition);
                await _hotelPositionDal.SaveAsync();
                return new SuccessResult(Messages.HotelPositionDeleted);
            }
            else
            {
                return new ErrorResult(Messages.HotelPositionNotFound);
            }
        }

        public async Task<IDataResult<List<HotelPosition>>> GetAllAsync()
        {
            var hotelPositions = await _hotelPositionDal.GetAllAsync();
            if (hotelPositions != null)
            {
                return new SuccessDataResult<List<HotelPosition>>(hotelPositions, Messages.HotelPositionListed);
            }
            else
            {
                return new ErrorDataResult<List<HotelPosition>>(null, Messages.HotelPositionNotFound);
            }
        }

        public async Task<IDataResult<HotelPosition>> GetByIdAsync(int Id)
        {
            var hotelPosition = await _hotelPositionDal.GetAsync(h => h.Id == Id);
            if (hotelPosition != null)
            {
                return new SuccessDataResult<HotelPosition>(hotelPosition, Messages.HotelPositionGeted);
            }
            else
            {
                return new ErrorDataResult<HotelPosition>(null, Messages.HotelPositionNotFound);
            }
        }

        public async Task<IResult> UpdateAsync(HotelPositionUpdateDto hotelPositionUpdateDto)
        {
            var oldHotelPosition = await _hotelPositionDal.GetAsync(h => h.Id == hotelPositionUpdateDto.Id);
            if (oldHotelPosition != null)
            {
                var mappedHotelPosition = _mapper.Map<HotelPositionUpdateDto, HotelPosition>(hotelPositionUpdateDto , oldHotelPosition);
                var updatedHotelPosition = await _hotelPositionDal.UpdateAsync(mappedHotelPosition);
                await _hotelPositionDal.SaveAsync();
                return new SuccessDataResult<HotelPosition>(updatedHotelPosition, Messages.HotelPositionUpdated);
            }
            else
            {
                return new ErrorDataResult<HotelPosition>(null, Messages.HotelPositionNotFound);
            }
        }
    }
}
