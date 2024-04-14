using HotelGame.Entities.Concrete;
using System.Collections.Generic;

namespace HotelGame.WebMVC.Models.GamePlay
{
    public class GetAllPlayerRoomsViewModel : BaseViewModel
    {
        public List<PlayerRoom> PlayerRooms { get; set; }

        public string HotelName { get; set; }

        public bool CheckPlayerHotel { get; set; }

    }
}
