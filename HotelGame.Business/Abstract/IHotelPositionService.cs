using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.HotelPositions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelGame.Business.Abstract
{
    public interface IHotelPositionService
    {
        // Bir otel pozisyonunu getiren fonksiyon
        Task<IDataResult<HotelPosition>> GetByIdAsync(int Id);

        // Birden fazla otel pozisyonunu listeleme fonksiyonu
        Task<IDataResult<List<HotelPosition>>> GetAllAsync();

        // Yeni bir otel pozisyonu ekleyen fonksiyon
        Task<IResult> AddAsync(HotelPositionAddDto hotelPositionAddDto);

        // Bir otel pozisyonunu güncelleyen fonksiyon
        Task<IResult> UpdateAsync(HotelPositionUpdateDto hotelPositionUpdateDto);

        // Bir otel pozisyonunu silen fonksiyon
        Task<IResult> DeleteAsync(int Id);
    }
}
