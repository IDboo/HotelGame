using HotelGame.Business.Abstract;
using HotelGame.WebMVC.Models.Account;
using HotelGame.WebMVC.Models.Test;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelGame.WebMVC.Controllers
{
    public class BacController : Controller
    {

        private readonly IRoomMaterialService _roomMaterialService;

        public BacController(IRoomMaterialService roomMaterialService)
        {
            _roomMaterialService = roomMaterialService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _roomMaterialService.GetAllAsync();

            if (result != null)
            {
                var roomMaterial = new LoginViewModel
                {
                    RoomMaterials = result.Data
                };

                return View(roomMaterial);
            }
            return View();
        }


        public async Task<IActionResult> RoomMaterials()
        {
            var result = await _roomMaterialService.GetAllAsync();

            if (result != null)
            {
                var roomMaterial = new RoomMaterialViewTest
                {
                    RoomMaterials = result.Data
                };

                return View(roomMaterial);
            }
            return View();
        }

    }
}
