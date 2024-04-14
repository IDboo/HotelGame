using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.RoomMaterial;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelGame.Business.Abstract
{
    public interface IRMBathRoomService
    {
        // Bir oda malzemesini getiren fonksiyon
        Task<IDataResult<RMBathRoom>> GetByIdAsync(int Id);

        // Birden fazla oda malzemesini listeleme fonksiyonu
        Task<IDataResult<List<RMBathRoom>>> GetAllAsync();

        // Yeni bir oda malzemesini ekleyen fonksiyon
        Task<IResult> AddAsync(RMBathRoomAddDto rMBathRoomAddDto);

        // Bir oda malzemesini güncelleyen fonksiyon
        Task<IResult> UpdateAsync(RMBathRoomUpdateDto rMBathRoomUpdateDto);

        // Bir oda malzemesini silen fonksiyon
        Task<IResult> DeleteAsync(int Id);
    }


}
