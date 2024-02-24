using AutoMapper;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.Staffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.DataAccess.AutoMapper
{
    public class StaffProfile : Profile
    {
        public StaffProfile()
        {
            CreateMap<StaffAddDto, Staff>();
            CreateMap<StaffUpdateDto, Staff>();
            CreateMap<Staff, StaffUpdateDto>();
        }
    }
}
