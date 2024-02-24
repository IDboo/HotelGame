using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.RoomTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelGame.Business.Abstract
{
    public interface IRoomTypeService
    {
        // Bir oda tipini getiren fonksiyon
        Task<IDataResult<RoomType>> GetByIdAsync(int Id);

        // Birden fazla oda tipini listeleme fonksiyonu
        Task<IDataResult<List<RoomType>>> GetAllAsync();

        // Yeni bir oda tipini ekleyen fonksiyon
        Task<IResult> AddAsync(RoomTypeAddDto roomTypeAddDto);

        // Bir oda tipini güncelleyen fonksiyon
        Task<IResult> UpdateAsync(RoomTypeUpdateDto roomTypeUpdateDto);

        // Bir oda tipini silen fonksiyon
        Task<IResult> DeleteAsync(int Id);
    }
}
