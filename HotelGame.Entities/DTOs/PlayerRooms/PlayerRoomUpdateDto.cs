namespace HotelGame.Entities.DTOs.PlayerRooms
{
    public class PlayerRoomUpdateDto
    {
        public int Id { get; set; }
        public int PlayerHotelId { get; set; }
        public int RoomTypeId { get; set; }
        public int RoomDailyPrice { get; set; }
        public bool Availability { get; set; } = true;
    }
}
