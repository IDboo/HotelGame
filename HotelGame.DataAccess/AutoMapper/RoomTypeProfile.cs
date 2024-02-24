using AutoMapper;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.RoomTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.DataAccess.AutoMapper
{
    public class RoomTypeProfile : Profile
    {
        public RoomTypeProfile()
        {
            CreateMap<RoomTypeAddDto, RoomType>();
            CreateMap<RoomTypeUpdateDto, RoomType>();
            CreateMap<RoomType, RoomTypeUpdateDto>();
        }
    }
}
