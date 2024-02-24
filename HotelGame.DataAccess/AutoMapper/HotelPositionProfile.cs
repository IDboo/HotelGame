using AutoMapper;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.HotelPositions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.DataAccess.AutoMapper
{
    public class HotelPositionProfile : Profile
    {
        public HotelPositionProfile()
        {
            CreateMap<HotelPositionAddDto, HotelPosition>();
            CreateMap<HotelPositionUpdateDto, HotelPosition>();
            CreateMap<HotelPosition, HotelPositionUpdateDto>();
        }
    }
}
