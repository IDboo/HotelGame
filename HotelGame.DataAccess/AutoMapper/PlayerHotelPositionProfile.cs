using AutoMapper;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.PlayerHotelPositions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.DataAccess.AutoMapper
{
    public class PlayerHotelPositionProfile : Profile
    {
        public PlayerHotelPositionProfile()
        {
            CreateMap<PlayerHotelPositionAddDto, PlayerHotelPosition>();
            CreateMap<PlayerHotelPositionUpdateDto, PlayerHotelPosition>();
            CreateMap<PlayerHotelPosition, PlayerHotelPositionUpdateDto>();
        }
    }
}
