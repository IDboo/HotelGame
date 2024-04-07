using HotelGame.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace HotelGame.WebMVC.Models.Customers
{
    public class GetAllCustomerViewModel : BaseViewModel
    {
        public List<Customer> Customers { get; set; }


        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile ImageUrl { get; set; }
        public int PeopleCount { get; set; }

    }
}
