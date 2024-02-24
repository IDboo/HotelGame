using HotelGame.Entities.Concrete;
using System.Collections.Generic;

namespace HotelGame.Entities.DTOs.RoomTypes
{
    public class RoomTypeAddDto
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int PeopleCount { get; set; }
    }
}
