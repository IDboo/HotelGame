using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.RoomMaterial;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelGame.Business.Abstract
{
    public interface IRMAirConditionService
    {
        // Bir oda malzemesini getiren fonksiyon
        Task<IDataResult<RMAirCondition>> GetByIdAsync(int Id);

        // Birden fazla oda malzemesini listeleme fonksiyonu
        Task<IDataResult<List<RMAirCondition>>> GetAllAsync();

        // Yeni bir oda malzemesini ekleyen fonksiyon
        Task<IResult> AddAsync(RMAirConditionAddDto rMAirConditionAddDto);

        // Bir oda malzemesini güncelleyen fonksiyon
        Task<IResult> UpdateAsync(RMAirConditionUpdateDto rMAirConditionUpdateDto);

        // Bir oda malzemesini silen fonksiyon
        Task<IResult> DeleteAsync(int Id);
    }


}
