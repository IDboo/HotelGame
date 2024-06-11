using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.RoomMaterial;
using HotelGame.Entities.DTOs.RoomMaterials;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelGame.Business.Abstract
{
    public interface IRMCarpetService
    {
        Task<IDataResult<RMCarpet>> GetByIdAsync(int Id);
        Task<IDataResult<List<RMCarpet>>> GetAllAsync();
        Task<IResult> AddAsync(RMCarpetAddDto rMCarpetAddDto);
        Task<IResult> UpdateAsync(RMCarpetUpdateDto rMCarpetUpdateDto);
        Task<IResult> DeleteAsync(int Id);
        Task<IDataResult<RMCarpet>> GetByLevelAsync(int level);
        Task<IDataResult<int>> UpdateUperLevelAsync(int Id, int PlayerHotelId);

        public int GetMaksimumLevel();
    }
}
