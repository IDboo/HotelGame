using HotelGame.Core.Entities;
using HotelGame.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.Entities.Concrete
{
    public class RMTelevision : BaseEntity<int>
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Level { get; set; }
        public int Price { get; set; }
        public int QualityPoint { get; set; }

        public List<PlayerRoomMaterial> PlayerRoomMaterial { get; set; }
    }
}
