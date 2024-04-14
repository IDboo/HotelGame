using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.RoomMaterial;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelGame.Business.Abstract
{
    public interface IRMCarpetService
    {
        // Bir oda malzemesini getiren fonksiyon
        Task<IDataResult<RMCarpet>> GetByIdAsync(int Id);

        // Birden fazla oda malzemesini listeleme fonksiyonu
        Task<IDataResult<List<RMCarpet>>> GetAllAsync();

        // Yeni bir oda malzemesini ekleyen fonksiyon
        Task<IResult> AddAsync(RMCarpetAddDto rMCarpetAddDto);

        // Bir oda malzemesini güncelleyen fonksiyon
        Task<IResult> UpdateAsync(RMCarpetUpdateDto rMCarpetUpdateDto);

        // Bir oda malzemesini silen fonksiyon
        Task<IResult> DeleteAsync(int Id);
    }


}
