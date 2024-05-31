using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.RoomMaterial;
using HotelGame.Entities.DTOs.RoomMaterials;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelGame.Business.Abstract
{
    public interface IRMAirConditionService
    {
        Task<IDataResult<RMAirCondition>> GetByIdAsync(int Id);
        Task<IDataResult<List<RMAirCondition>>> GetAllAsync();
        Task<IResult> AddAsync(RMAirConditionAddDto rMAirConditionAddDto);
        Task<IResult> UpdateAsync(RMAirConditionUpdateDto rMAirConditionUpdateDto);
        Task<IResult> DeleteAsync(int Id);
        Task<IDataResult<RMAirCondition>> GetByLevelAsync(int level);
    }
}
