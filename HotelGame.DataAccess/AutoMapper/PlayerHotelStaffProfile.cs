using AutoMapper;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.PlayerHotelStaffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.DataAccess.AutoMapper
{
    public class PlayerHotelStaffProfile : Profile
    {
        public PlayerHotelStaffProfile()
        {
            CreateMap<PlayerHotelStaffAddDto , PlayerHotelStaff>();
            CreateMap<PlayerHotelStaffUpdateDto , PlayerHotelStaff>();
            CreateMap<PlayerHotelStaff, PlayerHotelStaffUpdateDto>();
        }
    }
}
