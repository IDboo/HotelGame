using HotelGame.Business.Abstract;
using HotelGame.WebMVC.Helper.Abstract;
using HotelGame.WebMVC.Helper.Concrete;
using HotelGame.WebMVC.Models.Test;
using Microsoft.AspNetCore.Mvc;

namespace HotelGame.WebMVC.Areas.Admins.Controllers
{
    public class TestController : BaseController
    {
        private readonly IAutoCreaterService _autoCreaterService;


        public TestController(IUserAccessor userAccessor, IAutoCreaterService autoCreaterService) : base(userAccessor)
        {
            _autoCreaterService = autoCreaterService;
        }


        [HttpGet]
        public IActionResult HotelCreater()
        {
            var userId = CurrentUser.Id;
            return View(userId);
        }

        [HttpPost]
        public IActionResult HotelCreater(HotelCreaterViewModel hotelCreaterViewModel)
        {
            var userId = CurrentUser.Id;
            var result = _autoCreaterService.NewHotelCreater(userId, hotelCreaterViewModel.HotelName);
            if (result.Success)
            {
                return RedirectToAction("HotelCreater");
            }
            return View();
        }
    }
}
