using HotelGame.Business.Abstract;
using HotelGame.Entities.DTOs.Multipliers;
using HotelGame.WebMVC.Helper.Abstract;
using HotelGame.WebMVC.Models.Multipliers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelGame.WebMVC.Areas.Admins.Controllers
{
    public class MultipliersController : BaseController
    {

        private readonly IMultiplierService _multiplierService;

        public MultipliersController(IUserAccessor userAccessor, IMultiplierService multiplierService) : base(userAccessor)
        {
            _multiplierService = multiplierService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> GetAllMultipliers()
        {
            var result = await _multiplierService.GetAllAsync();
            if (result.Success)
            {
                var multipliers = new GetAllMultiplierViewModel()
                {
                    Multipliers = result.Data,
                    Message = result.Message
                };
                return View(multipliers);
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            var result = await _multiplierService.GetByIdAsync(Id);
            if (result.Success)
            {
                var multiplier = new GetAllMultiplierViewModel()
                {
                    Name = result.Data.Name,
                    Coefficient = result.Data.Coefficient
                };
                return View(multiplier);
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Update(GetAllMultiplierViewModel getAllMultiplierViewModel)
        {
            if (ModelState.IsValid)
            {
                var multiplier = new MultiplierUpdateDto()
                {
                    Id = getAllMultiplierViewModel.Id,
                    Name = getAllMultiplierViewModel.Name,
                    Coefficient =getAllMultiplierViewModel.Coefficient,
                };
                var result = await _multiplierService.UpdateAsync(multiplier);
                if (result.Success)
                {
                    return RedirectToAction("GetAllMultipliers");
                }
                return View();
            }
            return View();
        }


    }
}
