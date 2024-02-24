using AutoMapper;
using HotelGame.Business.Abstract;
using HotelGame.Business.Constans;
using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Core.Utilities.Result.Concrete;
using HotelGame.DataAccess.Abstract;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.Business.Concrete
{
    public class BookingManager : IBookingService
    {
        #region Injection

        private readonly IBookingDal _bookingDal;
        private readonly IMapper _mapper;

        public BookingManager(IBookingDal bookingDal, IMapper mapper)
        {
            _bookingDal = bookingDal;
            _mapper = mapper;
        }

        #endregion

        public async Task<IResult> AddAsync(BookingAddDto bookingAddDto)
        {
            var booking = _mapper.Map<Booking>(bookingAddDto);
            await _bookingDal.AddAsync(booking);
            await _bookingDal.SaveAsync();
            return new SuccessResult(Messages.BookingAdded);
        }

        public async Task<IResult> DeleteAsync(int Id)
        {
            var booking = await _bookingDal.GetAsync(b => b.Id == Id);
            if (booking != null)
            {
                await _bookingDal.DeleteAsync(booking);
                await _bookingDal.SaveAsync();
                return new SuccessResult(Messages.BookingDeleted);
            }
            else
            {
                return new ErrorResult(Messages.BookingNotFound);
            }
        }

        public async Task<IDataResult<List<Booking>>> GetAllAsync()
        {
            var bookings = await _bookingDal.GetAllAsync();
            if (bookings != null)
            {
                return new SuccessDataResult<List<Booking>>(bookings, Messages.BookingListed);
            }
            else
            {
                return new ErrorDataResult<List<Booking>>(null, Messages.BookingNotFound);
            }
        }

        public async Task<IDataResult<Booking>> GetByIdAsync(int Id)
        {
            var booking = await _bookingDal.GetAsync(b => b.Id == Id);
            if (booking != null)
            {
                return new SuccessDataResult<Booking>(booking, Messages.BookingGeted);
            }
            else
            {
                return new ErrorDataResult<Booking>(null, Messages.BookingNotFound);
            }
        }

        public async Task<IResult> UpdateAsync(BookingUpdateDto bookingUpdateDto)
        {
            var oldBooking = await _bookingDal.GetAsync(b => b.Id == bookingUpdateDto.Id);
            if (oldBooking != null)
            {
                var mappedBooking = _mapper.Map<BookingUpdateDto, Booking>(bookingUpdateDto, oldBooking);
                var newBooking = await _bookingDal.UpdateAsync(mappedBooking);
                await _bookingDal.SaveAsync();
                return new SuccessDataResult<Booking>(newBooking, Messages.BookingUpdated);
            }
            else
            {
                return new ErrorDataResult<Booking>(null, Messages.BookingNotFound);
            }
        }
    }
}
