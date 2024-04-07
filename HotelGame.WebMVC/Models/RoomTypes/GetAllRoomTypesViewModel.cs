using HotelGame.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace HotelGame.WebMVC.Models.RoomTypes
{
    public class GetAllRoomTypesViewModel : BaseViewModel
    {
        public List<RoomType> RoomTypes { get; set; }



        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile ImageUrl { get; set; }
        public int PeopleCount { get; set; }
        public string OldImageUrl { get; set; }
    }
}
