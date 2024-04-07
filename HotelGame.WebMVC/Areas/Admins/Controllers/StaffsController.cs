using HotelGame.WebMVC.Helper.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelGame.WebMVC.Areas.Admins.Controllers
{
    public class StaffsController : BaseController
    {
        public StaffsController(IUserAccessor userAccessor) : base(userAccessor)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
