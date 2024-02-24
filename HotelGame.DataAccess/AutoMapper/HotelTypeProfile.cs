using AutoMapper;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.HotelTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.DataAccess.AutoMapper
{
    public class HotelTypeProfile : Profile
    {
        public HotelTypeProfile()
        {
            CreateMap<HotelTypeAddDto, HotelType>();

            CreateMap<HotelTypeUpdateDto, HotelType>();

            CreateMap<HotelType, HotelTypeUpdateDto>();
        }
    }
}
