using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.PlayerRoomMaterial;
using System.Collections.Generic;

namespace HotelGame.WebMVC.Models.GamePlay
{
    public class GetAllPlayerRoomsViewModel : BaseViewModel
    {
        public List<PlayerRoom> PlayerRooms { get; set; }

        public PlayerHotel PlayerHotel { get; set; }

        public string HotelName { get; set; }

        public bool CheckPlayerHotel { get; set; }

        public List<PlayerRoomMaterial> PlayerRoomMaterials { get; set; }

        public PlayerRoomMaterial UpperRoomMaterial { get; set; }

        public int MaksimumLevelTelevision { get; set; }
        public int MaksimumLevelAirCondition { get; set; }
        public int MaksimumLevelBed { get; set; }
        public int MaksimumLevelCarpet { get; set; }
        public int MaksimumLevelBathRoom { get; set; }
        public int MaksimumLevelToilet { get; set; }
    }

}
