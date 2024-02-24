using AutoMapper;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.RoomMaterials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.DataAccess.AutoMapper
{
    public class RoomMaterialProfile : Profile
    {
        public RoomMaterialProfile()
        {
            CreateMap<RoomMaterialAddDto, RoomMaterial>();
            CreateMap<RoomMaterialUpdateDto, RoomMaterial>();
            CreateMap<RoomMaterial, RoomMaterialUpdateDto>();
        }
    }
}
