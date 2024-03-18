using HotelGame.Business.Abstract;
using HotelGame.Entities.DTOs.HotelTypes;
using HotelGame.WebMVC.Helper.Abstract;
using HotelGame.WebMVC.Models.HotelTypes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelGame.WebMVC.Areas.Admins.Controllers
{
    public class HotelTypesController : BaseController
    {

        private readonly IHotelTypeService _hotelTypeService;


        public HotelTypesController(IUserAccessor userAccessor, IHotelTypeService hotelTypeService) : base(userAccessor)
        {
            _hotelTypeService = hotelTypeService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> GetAllHotelTypes()
        {
            var result = await _hotelTypeService.GetAllAsync();

            if (result.Success)
            {
                var hotelTypes = new GetAllHotelTypesViewModel()
                {
                    HotelTypes = result.Data,
                    Message = result.Message
                };
                return View(hotelTypes);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(GetAllHotelTypesViewModel getAllHotelTypesViewModel)
        {
            if (ModelState.IsValid)
            {
                var hotelType = new HotelTypeAddDto()
                {
                    Name = getAllHotelTypesViewModel.Name
                };

                var result = await _hotelTypeService.AddAsync(hotelType);
                if (result.Success)
                {
                    return RedirectToAction("GetAllHotelTypes");
                }
                return View();
            }
            return View();
        }


        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _hotelTypeService.DeleteAsync(Id);
            if (result.Success)
            {
                return RedirectToAction("GetAllHotelTypes");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            var result = await _hotelTypeService.GetByIdAsync(Id);
            if (result.Success)
            {
                var hotelType = new GetAllHotelTypesViewModel()
                {
                   Name = result.Data.Name
                };
                return View(hotelType);
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Update(GetAllHotelTypesViewModel getAllHotelTypesViewModel)
        {
            if (ModelState.IsValid)
            {
                var hotelType = new HotelTypeUpdateDto()
                {
                    Id = getAllHotelTypesViewModel.Id,  
                    Name = getAllHotelTypesViewModel.Name
                };
                var result = await _hotelTypeService.UpdateAsync(hotelType);
                if (result.Success)
                {
                    return RedirectToAction("GetAllHotelTypes");
                }
                return View();
            }
            return View();
        }


        


    }
}
