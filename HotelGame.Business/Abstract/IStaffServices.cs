using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.Staffs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelGame.Business.Abstract
{
    public interface IStaffService
    {
        // Bir personeli getiren fonksiyon
        Task<IDataResult<Staff>> GetByIdAsync(int Id);

        // Birden fazla personeli listeleme fonksiyonu
        Task<IDataResult<List<Staff>>> GetAllAsync();

        // Yeni bir personeli ekleyen fonksiyon
        Task<IResult> AddAsync(StaffAddDto staffAddDto);

        // Bir personeli güncelleyen fonksiyon
        Task<IResult> UpdateAsync(StaffUpdateDto staffUpdateDto);

        // Bir personeli silen fonksiyon
        Task<IResult> DeleteAsync(int Id);
    }
}
