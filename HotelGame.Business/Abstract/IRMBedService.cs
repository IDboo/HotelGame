using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.RoomMaterial;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelGame.Business.Abstract
{
    public interface IRMBedService
    {
        // Bir oda malzemesini getiren fonksiyon
        Task<IDataResult<RMBed>> GetByIdAsync(int Id);

        // Birden fazla oda malzemesini listeleme fonksiyonu
        Task<IDataResult<List<RMBed>>> GetAllAsync();

        // Yeni bir oda malzemesini ekleyen fonksiyon
        Task<IResult> AddAsync(RMBedAddDto rMBedAddDto);

        // Bir oda malzemesini güncelleyen fonksiyon
        Task<IResult> UpdateAsync(RMBedUpdateDto rMBedUpdateDto);

        // Bir oda malzemesini silen fonksiyon
        Task<IResult> DeleteAsync(int Id);
    }


}
