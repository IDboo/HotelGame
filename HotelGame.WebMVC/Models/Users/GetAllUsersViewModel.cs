using HotelGame.Entities.Concrete;
using HotelGame.WebMVC.Models.HotelTypes;
using System;
using System.Collections.Generic;

namespace HotelGame.WebMVC.Models.Users
{
    public class GetAllUsersViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string[] Roles { get; set; }

    }
}
