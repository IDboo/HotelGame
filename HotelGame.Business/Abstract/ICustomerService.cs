using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.Customers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelGame.Business.Abstract
{
    public interface ICustomerService
    {
        // Bir müşteriyi getiren fonksiyon
        Task<IDataResult<Customer>> GetByIdAsync(int Id);

        // Birden fazla müşteriyi listeleme fonksiyonu
        Task<IDataResult<List<Customer>>> GetAllAsync();

        // Yeni bir müşteri ekleyen fonksiyon
        Task<IResult> AddAsync(CustomerAddDto customerAddDto);

        // Bir müşteriyi güncelleyen fonksiyon
        Task<IResult> UpdateAsync(CustomerUpdateDto customerUpdateDto);

        // Bir müşteriyi silen fonksiyon
        Task<IResult> DeleteAsync(int Id);
    }
}
