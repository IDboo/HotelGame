using HotelGame.Core.Entities;
using System.Collections.Generic;

namespace HotelGame.Entities.Concrete
{
    public class PlayerRoomMaterial : BaseEntity<int>
    {
        public int PlayerRoomId { get; set; }
        public int RMTelevisionId { get; set; }
        public int RMToiletId { get; set; }
        public int RMAirConditionId { get; set; }
        public int RMBathRoomId { get; set; }
        public int RMBedId { get; set; }
        public int RMCarpetId { get; set; }


        public PlayerRoom PlayerRoom { get; set; }
        public RMTelevision RMTelevision { get; set; }
        public RMToilet RMToilet { get; set; }
        public RMAirCondition RMAirCondition { get; set; }
        public RMBathRoom RMBathRoom { get; set; }
        public RMBed RMBed { get; set; }
        public RMCarpet RMCarpet { get; set; }

    }

}
