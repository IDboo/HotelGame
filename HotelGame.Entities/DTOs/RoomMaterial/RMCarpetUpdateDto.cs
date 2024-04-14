namespace HotelGame.Entities.DTOs.RoomMaterial
{
    public class RMCarpetUpdateDto
    {
        public int Id { get; set; }
        public int RoomMaterialId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Level { get; set; }
        public int Price { get; set; }
        public int QualityPoint { get; set; }
    }
}
