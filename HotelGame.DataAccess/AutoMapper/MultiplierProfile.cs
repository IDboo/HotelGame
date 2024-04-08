using AutoMapper;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.Multipliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.DataAccess.AutoMapper
{
    public class MultiplierProfile : Profile
    {
        public MultiplierProfile()
        {
            CreateMap<MultiplierUpdateDto, Multiplier>();
            CreateMap<Multiplier, MultiplierUpdateDto>();
        }
    }
}
