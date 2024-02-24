using HotelGame.Core.Entities;

namespace HotelGame.Entities.Concrete
{
    public class PlayerRoomMaterial : BaseEntity<int>
    {
        public int PlayerRoomId { get; set; }
        public int RoomMaterialId { get; set; }
        public int RoomMaterial2Id { get; set; }

        public PlayerRoom PlayerRoom { get; set; }
        public RoomMaterial RoomMaterial { get; set; }
        public RoomMaterial2 RoomMaterial2 { get; set; }

    }

}
