using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.PlayerHotelStaffs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelGame.Business.Abstract
{
    public interface IPlayerHotelStaffService
    {
        // Bir oyuncu otel personelini getiren fonksiyon
        Task<IDataResult<PlayerHotelStaff>> GetByIdAsync(int Id);

        // Birden fazla oyuncu otel personelini listeleme fonksiyonu
        Task<IDataResult<List<PlayerHotelStaff>>> GetAllAsync();

        // Yeni bir oyuncu otel personelini ekleyen fonksiyon
        Task<IResult> AddAsync(PlayerHotelStaffAddDto playerHotelStaffAddDto);

        // Bir oyuncu otel personelini güncelleyen fonksiyon
        Task<IResult> UpdateAsync(PlayerHotelStaffUpdateDto playerHotelStaffUpdateDto);

        // Bir oyuncu otel personelini silen fonksiyon
        Task<IResult> DeleteAsync(int Id);
    }
}
