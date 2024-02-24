using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.HotelTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.Business.Abstract
{
    public interface IHotelTypeService
    {
        //Bir veriyi getiren fonksiyon
        Task<IDataResult<HotelType>> GetByIdAsync(int Id);

        //Bİrden fazla veriyi listeleme fonksiyonu
        Task<IDataResult<List<HotelType>>> GetAllAsync();

        //Ekleme fonksiyonu
        Task<IResult> AddAsync(HotelTypeAddDto hotelTypeAddDto);

        //Güncelleme Fonksiyonu
        Task<IResult> UpdateAsync(HotelTypeUpdateDto hotelTypeUpdateDto);

        //Silme Fonksiyonu
        Task<IResult> DeleteAsync(int Id);
    }
}