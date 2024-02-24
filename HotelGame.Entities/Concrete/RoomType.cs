using HotelGame.Core.Entities;
using System.Collections.Generic;

namespace HotelGame.Entities.Concrete
{
    public class RoomType : BaseEntity<int>
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int PeopleCount { get; set; }
        public List<PlayerRoom> PlayerRooms { get; set; }
    }  

}
