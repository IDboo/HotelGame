using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.PlayerHotels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelGame.Business.Abstract
{
    public interface IPlayerHotelService
    {
        // Bir oyuncu otelini getiren fonksiyon
        Task<IDataResult<PlayerHotel>> GetByIdAsync(int Id);

        // Birden fazla oyuncu otelini listeleme fonksiyonu
        Task<IDataResult<List<PlayerHotel>>> GetAllAsync();

        // Yeni bir oyuncu oteli ekleyen fonksiyon
        Task<IResult> AddAsync(PlayerHotelAddDto playerHotelAddDto);

        // Bir oyuncu otelini güncelleyen fonksiyon
        Task<IResult> UpdateAsync(PlayerHotelUpdateDto playerHotelUpdateDto);

        // Bir oyuncu otelini silen fonksiyon
        Task<IResult> DeleteAsync(int Id);

        Task<IDataResult<PlayerHotel>> PlayerHotelByUserId(int userId);

        int LastId();

        IResult Add(PlayerHotelAddDto playerHotelAddDto);
    }
}
