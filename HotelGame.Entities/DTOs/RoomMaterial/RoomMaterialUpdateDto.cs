namespace HotelGame.Entities.DTOs.RoomMaterials
{

    public class RoomMaterialUpdateDto
    {
        public int Id { get; set; }
        public int PlayerRoomId { get; set; }
        public int RoomMaterialId { get; set; }
        public int RoomMaterial2Id { get; set; }
    }
}
