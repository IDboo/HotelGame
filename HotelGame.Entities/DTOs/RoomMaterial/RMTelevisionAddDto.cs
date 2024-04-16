using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.Entities.DTOs.RoomMaterial
{
    public class RMTelevisionAddDto
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Level { get; set; }
        public int Price { get; set; }
        public int QualityPoint { get; set; }
    }
}
