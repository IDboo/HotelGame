using HotelGame.Entities.Concrete;
using System.Collections.Generic;

namespace HotelGame.Entities.DTOs.PlayerRoomMaterials
{

    public class PlayerRoomMaterialUpdateDto
    {
        public int Id { get; set; }
        public int PlayerRoomId { get; set; }
        public int RMTelevisionId { get; set; }
        public int RMToiletId { get; set; }
        public int RMAirConditionId { get; set; }
        public int RMBathRoomId { get; set; }
        public int RMBedId { get; set; }
        public int RMCarpetId { get; set; }




    }
}
