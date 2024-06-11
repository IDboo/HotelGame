using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.RoomMaterial;
using HotelGame.Entities.DTOs.RoomMaterials;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelGame.Business.Abstract
{
    public interface IRMBedService
    {
        Task<IDataResult<RMBed>> GetByIdAsync(int Id);
        Task<IDataResult<List<RMBed>>> GetAllAsync();
        Task<IResult> AddAsync(RMBedAddDto rMBedAddDto);
        Task<IResult> UpdateAsync(RMBedUpdateDto rMBedUpdateDto);
        Task<IResult> DeleteAsync(int Id);
        Task<IDataResult<RMBed>> GetByLevelAsync(int level);
        Task<IDataResult<int>> UpdateUperLevelAsync(int Id, int PlayerHotelId);

        public int GetMaksimumLevel();
    }
}
