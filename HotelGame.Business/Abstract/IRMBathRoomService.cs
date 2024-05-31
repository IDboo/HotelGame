using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.RoomMaterial;
using HotelGame.Entities.DTOs.RoomMaterials;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelGame.Business.Abstract
{
    public interface IRMBathRoomService
    {
        Task<IDataResult<RMBathRoom>> GetByIdAsync(int Id);
        Task<IDataResult<List<RMBathRoom>>> GetAllAsync();
        Task<IResult> AddAsync(RMBathRoomAddDto rMBathRoomAddDto);
        Task<IResult> UpdateAsync(RMBathRoomUpdateDto rMBathRoomUpdateDto);
        Task<IResult> DeleteAsync(int Id);
        Task<IDataResult<RMBathRoom>> GetByLevelAsync(int level);
    }
}
