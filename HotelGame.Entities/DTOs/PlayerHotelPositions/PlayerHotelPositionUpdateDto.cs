namespace HotelGame.Entities.DTOs.PlayerHotelPositions
{

    public class PlayerHotelPositionUpdateDto
    {
        public int Id { get; set; }
        public int PlayerHotelId { get; set; }
        public int HotelPositionId { get; set; }
        public int StaffCount { get; set; }
    }
}
