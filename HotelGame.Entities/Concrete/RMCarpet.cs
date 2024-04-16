using HotelGame.Core.Entities;
using System.Collections.Generic;

namespace HotelGame.Entities.Concrete
{
    public class RMCarpet : BaseEntity<int>
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Level { get; set; }
        public int Price { get; set; }
        public int QualityPoint { get; set; }

        public List<PlayerRoomMaterial> PlayerRoomMaterial { get; set; }
    }
}
