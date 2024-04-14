using AutoMapper;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.RoomMaterial;
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

            CreateMap<RMTelevisionAddDto, RMTelevision>();
            CreateMap<RMTelevisionUpdateDto, RMTelevision>();
            CreateMap<RMTelevision, RMTelevisionUpdateDto>();

            CreateMap<RMBedAddDto, RMBed>();
            CreateMap<RMBedUpdateDto, RMBed>();
            CreateMap<RMBed, RMBedUpdateDto>();

            CreateMap<RMBathRoomAddDto, RMBathRoom>();
            CreateMap<RMBathRoomUpdateDto, RMBathRoom>();
            CreateMap<RMBathRoom, RMBathRoomUpdateDto>();

            CreateMap<RMCarpetAddDto, RMCarpet>();
            CreateMap<RMCarpetUpdateDto, RMCarpet>();
            CreateMap<RMCarpet, RMCarpetUpdateDto>();

            CreateMap<RMAirConditionAddDto, RMAirCondition>();
            CreateMap<RMAirConditionUpdateDto, RMAirCondition>();
            CreateMap<RMAirCondition, RMAirConditionUpdateDto>();

            CreateMap<RMToiletAddDto, RMToilet>();
            CreateMap<RMToiletUpdateDto, RMToilet>();
            CreateMap<RMToilet, RMToiletUpdateDto>();


        }
    }
}
