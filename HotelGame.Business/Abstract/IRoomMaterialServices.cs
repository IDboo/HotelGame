using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.RoomMaterials;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelGame.Business.Abstract
{
    public interface IRoomMaterialService
    {
        // Bir oda malzemesini getiren fonksiyon
        Task<IDataResult<RoomMaterial>> GetByIdAsync(int Id);

        // Birden fazla oda malzemesini listeleme fonksiyonu
        Task<IDataResult<List<RoomMaterial>>> GetAllAsync();

        // Yeni bir oda malzemesini ekleyen fonksiyon
        Task<IResult> AddAsync(RoomMaterialAddDto roomMaterialAddDto);

        // Bir oda malzemesini güncelleyen fonksiyon
        Task<IResult> UpdateAsync(RoomMaterialUpdateDto roomMaterialUpdateDto);

        // Bir oda malzemesini silen fonksiyon
        Task<IResult> DeleteAsync(int Id);
    }
}
