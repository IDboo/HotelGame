using HotelGame.Core.Entities;
using System.Collections.Generic;

namespace HotelGame.Entities.Concrete
{
    public class PlayerHotelPosition : BaseEntity<int>
    {
        public int PlayerHotelId { get; set; }
        public int HotelPositionId { get; set; }
        public int StaffCount { get; set; }
        public PlayerHotel PlayerHotel { get; set; }
        public HotelPosition HotelPosition { get; set; }

        public List<PlayerHotelStaff> PlayerHotelStaffs { get; set; }
    }

}
