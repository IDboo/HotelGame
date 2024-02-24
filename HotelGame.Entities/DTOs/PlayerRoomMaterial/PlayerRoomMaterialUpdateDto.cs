namespace HotelGame.Entities.DTOs.PlayerRoomMaterials
{

    public class PlayerRoomMaterialUpdateDto
    {
        public int Id { get; set; }
        public int PlayerRoomId { get; set; }
        public int RoomMaterialId { get; set; }
        public int RoomMaterial2Id { get; set; }
    }
}
