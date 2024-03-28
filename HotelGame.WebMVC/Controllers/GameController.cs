using Microsoft.AspNetCore.Mvc;

namespace HotelGame.WebMVC.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
