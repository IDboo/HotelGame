using AutoMapper;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.DataAccess.AutoMapper
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerAddDto, Customer>();
            CreateMap<CustomerUpdateDto, Customer>();
            CreateMap<Customer, CustomerUpdateDto>();
        }
    }
}
