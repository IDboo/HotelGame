using HotelGame.Core.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.Business.Abstract
{
    public interface IAutoCreaterService
    {
        IResult NewHotelCreater(int userId, string hotelName);

    }
}
