using HotelGame.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace HotelGame.WebMVC.Models.RoomMaterials
{
    public class GetAllRoomMaterialsViewModel : BaseViewModel
    {
        public List<RoomMaterial> RoomMaterials { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }


    }
}
