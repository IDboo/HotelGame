using AutoMapper;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.Bookings;

namespace HotelGame.DataAccess.AutoMapper
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<BookingAddDto, Booking>();
            CreateMap<BookingUpdateDto, Booking>();
            CreateMap<Booking, BookingUpdateDto>();
        }
    }
}   