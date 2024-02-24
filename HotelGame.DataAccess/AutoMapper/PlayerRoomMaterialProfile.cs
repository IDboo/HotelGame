using AutoMapper;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.PlayerRoomMaterials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.DataAccess.AutoMapper
{
    public class PlayerRoomMaterialProfile : Profile
    {
        public PlayerRoomMaterialProfile()
        {
            CreateMap<PlayerRoomMaterialAddDto, PlayerRoomMaterial>();
            CreateMap<PlayerRoomMaterialUpdateDto, PlayerRoomMaterial>();
            CreateMap<PlayerRoomMaterial, PlayerRoomMaterialUpdateDto>();
        }
    }
}
