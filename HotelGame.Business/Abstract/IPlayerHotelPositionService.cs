using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.PlayerHotelPositions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelGame.Business.Abstract
{
    public interface IPlayerHotelPositionService
    {
        // Bir oyuncu otel pozisyonunu getiren fonksiyon
        Task<IDataResult<PlayerHotelPosition>> GetByIdAsync(int Id);

        // Birden fazla oyuncu otel pozisyonunu listeleme fonksiyonu
        Task<IDataResult<List<PlayerHotelPosition>>> GetAllAsync();

        // Yeni bir oyuncu otel pozisyonu ekleyen fonksiyon
        Task<IResult> AddAsync(PlayerHotelPositionAddDto playerHotelPositionAddDto);

        // Bir oyuncu otel pozisyonunu güncelleyen fonksiyon
        Task<IResult> UpdateAsync(PlayerHotelPositionUpdateDto playerHotelPositionUpdateDto);

        // Bir oyuncu otel pozisyonunu silen fonksiyon
        Task<IResult> DeleteAsync(int Id);
    }
}
