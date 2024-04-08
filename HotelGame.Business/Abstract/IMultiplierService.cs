using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.HotelTypes;
using HotelGame.Entities.DTOs.Multipliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.Business.Abstract
{
    public interface IMultiplierService
    {
        //Bir veriyi getiren fonksiyon
        Task<IDataResult<Multiplier>> GetByIdAsync(int Id);

        //Bİrden fazla veriyi listeleme fonksiyonu
        Task<IDataResult<List<Multiplier>>> GetAllAsync();

        //Güncelleme Fonksiyonu
        Task<IResult> UpdateAsync(MultiplierUpdateDto multiplierUpdateDto);

    }
}
