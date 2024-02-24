using HotelGame.Core.Entities;

namespace HotelGame.Entities.Concrete
{
    public class PlayerHotelStaff : BaseEntity<int>
    {
        public int PlayerHotelPositionId { get; set; }
        public int StaffId { get; set; }
        public PlayerHotelPosition PlayerHotelPosition { get; set; }
        public Staff Staff { get; set; }
    }

}
