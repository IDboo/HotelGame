namespace HotelGame.Entities.DTOs.PlayerHotels
{

    public class PlayerHotelUpdateDto
    {
        public int Id { get; set; }
        public int HotelTypeId { get; set; }
        public int UserId { get; set; }
        public int HotelName { get; set; }
        public int HotelQuality { get; set; }
        public int HotelLevel { get; set; }
        public int HotelMoney { get; set; }
        public int CustomerCommentPointAvarage { get; set; }
    }
}
