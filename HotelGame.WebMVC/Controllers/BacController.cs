using Microsoft.AspNetCore.Mvc;

namespace HotelGame.WebMVC.Controllers
{
    public class BacController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
