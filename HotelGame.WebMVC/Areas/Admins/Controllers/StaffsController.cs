using HotelGame.Business.Abstract;
using HotelGame.Entities.DTOs.Staffs;
using HotelGame.WebMVC.Helper.Abstract;
using HotelGame.WebMVC.Models.Staffs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelGame.WebMVC.Areas.Admins.Controllers
{
    public class StaffsController : BaseController
    {

        private readonly IStaffService _staffService;
        private readonly IFileHelper _fileHelper;

        public StaffsController(IUserAccessor userAccessor, IStaffService staffService, IFileHelper fileHelper) : base(userAccessor)
        {
            _staffService = staffService;
            _fileHelper = fileHelper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAllStaff()
        {
            var result = await _staffService.GetAllAsync();

            if (result.Success)
            {
                var staff = new GetAllStaffViewModel()
                {
                    Staffs = result.Data,
                    Message = result.Message
                };
                return View(staff);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(GetAllStaffViewModel getAllStaffViewModel)
        {
            if (ModelState.IsValid)
            {
                var staff = new StaffAddDto()
                {
                    Name = getAllStaffViewModel.Name,
                    Comment = getAllStaffViewModel.Comment,
                    Wage = getAllStaffViewModel.Wage,
                };

                if (getAllStaffViewModel.ImageUrl != null)
                {
                    var fileName = getAllStaffViewModel.ImageUrl;
                    var imageFile = _fileHelper.UploadFile(fileName);
                    staff.ImageUrl = imageFile;
                }

                var result = await _staffService.AddAsync(staff);
                if (result.Success)
                {
                    return RedirectToAction("GetAllStaff");
                }
                return View();
            }
            return View();
        }


        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _staffService.DeleteAsync(Id);
            if (result.Success)
            {
                return RedirectToAction("GetAllStaff");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            var result = await _staffService.GetByIdAsync(Id);
            if (result.Success)
            {
                var staff = new GetAllStaffViewModel()
                {
                    Name = result.Data.Name,
                    Comment = result.Data.Comment,
                    Wage= result.Data.Wage,
                    OldImageUrl = result.Data.ImageUrl,
                };
                return View(staff);
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Update(GetAllStaffViewModel getAllStaffViewModel)
        {
            if (ModelState.IsValid)
            {
                var staff = new StaffUpdateDto()
                {
                    Id = getAllStaffViewModel.Id,
                    Name = getAllStaffViewModel.Name,
                    Wage = getAllStaffViewModel.Wage,
                    Comment = getAllStaffViewModel.Comment, 
                };

                if (getAllStaffViewModel.ImageUrl != null)
                {
                    var fileName = getAllStaffViewModel.ImageUrl;
                    var imageFile = _fileHelper.UploadFile(fileName);
                    staff.ImageUrl = imageFile;
                }

                var result = await _staffService.UpdateAsync(staff);
                if (result.Success)
                {
                    return RedirectToAction("GetAllStaff");
                }
                return View();
            }
            return View();
        }
    }
}
