using AutoMapper;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.PlayerRooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.DataAccess.AutoMapper
{
    public class PlayerRoomProfile : Profile
    {
        public PlayerRoomProfile()
        {
            CreateMap<PlayerRoomAddDto, PlayerRoom>();
            CreateMap<PlayerRoomUpdateDto, PlayerRoom>();
            CreateMap<PlayerRoom, PlayerRoomUpdateDto>();
        }
    }
}
