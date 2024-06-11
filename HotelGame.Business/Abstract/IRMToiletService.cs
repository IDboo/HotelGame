using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.RoomMaterial;
using HotelGame.Entities.DTOs.RoomMaterials;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelGame.Business.Abstract
{
    public interface IRMToiletService
    {
        Task<IDataResult<RMToilet>> GetByIdAsync(int Id);
        Task<IDataResult<List<RMToilet>>> GetAllAsync();
        Task<IResult> AddAsync(RMToiletAddDto rMToiletAddDto);
        Task<IResult> UpdateAsync(RMToiletUpdateDto rMToiletUpdateDto);
        Task<IResult> DeleteAsync(int Id);
        Task<IDataResult<RMToilet>> GetByLevelAsync(int level);
        Task<IDataResult<int>> UpdateUperLevelAsync(int Id, int PlayerHotelId);

        public int GetMaksimumLevel();
    }
}
