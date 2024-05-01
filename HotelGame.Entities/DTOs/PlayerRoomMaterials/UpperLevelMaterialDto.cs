using HotelGame.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.Entities.DTOs.PlayerRoomMaterial
{
    public class UpperLevelMaterialDto
    {
        public int PlayerRoomId { get; set; }
        public int RMTelevisionId { get; set; }
        public int RMToiletId { get; set; }
        public int RMAirConditionId { get; set; }
        public int RMBathRoomId { get; set; }
        public int RMBedId { get; set; }
        public int RMCarpetId { get; set; }
    }
}
