using HotelGame.Core.Entities;
using System.Collections.Generic;

namespace HotelGame.Entities.Concrete
{
    public class PlayerHotel : BaseEntity<int>
    {
        public int HotelTypeId { get; set; }
        public int UserId { get; set; }
        public string HotelName { get; set; }
        public int HotelQuality { get; set; }
        public int HotelLevel { get; set; }
        public int HotelMoney { get; set; }
        public int CustomerCommentPointAvarage { get; set; }
        public HotelType HotelType { get; set; }
        public User User { get; set; }

        public List<PlayerHotelPosition> PlayerHotelPositions { get; set; }
        public List<PlayerRoom> PlayerRooms { get; set; }

    }

}
