using HotelGame.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace HotelGame.WebMVC.Models.Staffs
{
    public class GetAllStaffViewModel : BaseViewModel
    {
        public List<Staff> Staffs { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile ImageUrl { get; set; }
        public string Comment { get; set; }
        public int Wage { get; set; }

        public string OldImageUrl { get; set; }
    }
}
