using HotelGame.Core.Entities;
using System.Collections.Generic;

namespace HotelGame.Entities.Concrete
{
    public class RoomMaterial : BaseEntity<int>
    {
        public string Name { get; set; }

        public List<PlayerRoomMaterial> PlayerRoomMaterials { get; set; }
        public List<RMAirCondition> RMAirConditions { get; set; }
        public List<RMBathRoom> RMBathRooms { get; set; }
        public List<RMBed> RMBeds { get; set; }
        public List<RMCarpet> RMCarpets { get; set; }
        public List<RMTelevision> RMTelevisions { get; set; }
        public List<RMToilet> RMToilets { get; set; }
    }

}
