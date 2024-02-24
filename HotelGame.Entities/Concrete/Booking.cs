using HotelGame.Core.Entities;

namespace HotelGame.Entities.Concrete
{
    public class Booking : BaseEntity<int>
    {
        public int PlayerRoomId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerComment { get; set; }
        public int CustomerCommentPoint { get; set; }
        public PlayerRoom PlayerRoom { get; set; }
        public Customer Customer { get; set;}


    }

}
