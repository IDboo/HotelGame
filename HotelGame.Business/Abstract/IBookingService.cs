using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.Bookings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelGame.Business.Abstract
{
    public interface IBookingService
    {
        // Bir rezervasyonu getiren fonksiyon
        Task<IDataResult<Booking>> GetByIdAsync(int Id);

        // Birden fazla rezervasyonu listeleme fonksiyonu
        Task<IDataResult<List<Booking>>> GetAllAsync();

        // Yeni bir rezervasyon ekleyen fonksiyon
        Task<IResult> AddAsync(BookingAddDto bookingAddDto);

        // Bir rezervasyonu güncelleyen fonksiyon
        Task<IResult> UpdateAsync(BookingUpdateDto bookingUpdateDto);

        // Bir rezervasyonu silen fonksiyon
        Task<IResult> DeleteAsync(int Id);
    }
}
