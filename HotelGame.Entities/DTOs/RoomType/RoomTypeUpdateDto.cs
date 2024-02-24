using HotelGame.Entities.Concrete;
using System.Collections.Generic;

namespace HotelGame.Entities.DTOs.RoomTypes
{

    public class RoomTypeUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int PeopleCount { get; set; }
    }
}
