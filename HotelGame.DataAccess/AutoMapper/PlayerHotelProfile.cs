using AutoMapper;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.PlayerHotels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.DataAccess.AutoMapper
{
    public class PlayerHotelProfile : Profile
    {
        public PlayerHotelProfile()
        {
            CreateMap<PlayerHotelAddDto, PlayerHotel>();
            CreateMap<PlayerHotelUpdateDto, PlayerHotel>();
            CreateMap<PlayerHotel, PlayerHotelUpdateDto>();
        }
    }
}
