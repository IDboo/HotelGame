using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.PlayerRooms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelGame.Business.Abstract
{
    public interface IPlayerRoomService
    {
        // Bir oyuncu odasını getiren fonksiyon
        Task<IDataResult<PlayerRoom>> GetByIdAsync(int Id);

        // Birden fazla oyuncu odasını listeleme fonksiyonu
        Task<IDataResult<List<PlayerRoom>>> GetAllAsync();

        // Yeni bir oyuncu odasını ekleyen fonksiyon
        Task<IResult> AddAsync(PlayerRoomAddDto playerRoomAddDto);

        // Bir oyuncu odasını güncelleyen fonksiyon
        Task<IResult> UpdateAsync(PlayerRoomUpdateDto playerRoomUpdateDto);

        // Bir oyuncu odasını silen fonksiyon
        Task<IResult> DeleteAsync(int Id);

        public int LastId();
    }
}
