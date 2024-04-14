using HotelGame.Core.Entities;

namespace HotelGame.Entities.Concrete
{
    public class RMCarpet : BaseEntity<int>
    {
        public int RoomMaterialId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Level { get; set; }
        public int Price { get; set; }
        public int QualityPoint { get; set; }

        public RoomMaterial RoomMaterial { get; set; }
    }
}
