using HotelGame.Core.Entities;
using System.Collections.Generic;

namespace HotelGame.Entities.Concrete
{
    public class PlayerRoom : BaseEntity<int>
    {
        public int PlayerHotelId { get; set; }
        public int RoomTypeId { get; set; }
        public int RoomDailyPrice { get; set; }
        public bool Availability { get; set; } = true;
        public List<Booking> Bookings { get; set; }
        public PlayerHotel PlayerHotel { get; set; }
        public RoomType RoomType { get; set; }
        public List<PlayerRoomMaterial> PlayerRoomMaterials { get; set; }
    }

}
