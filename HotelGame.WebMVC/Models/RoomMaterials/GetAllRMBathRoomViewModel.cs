using HotelGame.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace HotelGame.WebMVC.Models.RoomMaterials
{
    public class GetAllRMBathRoomViewModel : BaseViewModel
    {
        public List<RMBathRoom> RMBathRooms { get; set; }

        public int Id { get; set; }
        public int RoomMaterialId { get; set; }
        public string Name { get; set; }
        public IFormFile ImageUrl { get; set; }
        public int Level { get; set; }
        public int Price { get; set; }
        public int QualityPoint { get; set; }
        public string OldImageUrl { get; set; }


    }

}
