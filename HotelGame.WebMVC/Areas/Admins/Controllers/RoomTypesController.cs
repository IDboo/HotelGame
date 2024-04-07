using HotelGame.Business.Abstract;
using HotelGame.Entities.DTOs.RoomTypes;
using HotelGame.WebMVC.Helper.Abstract;
using HotelGame.WebMVC.Models.RoomTypes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelGame.WebMVC.Areas.Admins.Controllers
{
    public class RoomTypesController : BaseController
    {
        private readonly IRoomTypeService _roomTypeService;
        private readonly IFileHelper _fileHelper;


        public RoomTypesController(IUserAccessor userAccessor, IRoomTypeService roomTypeService, IFileHelper fileHelper) : base(userAccessor)
        {
            _roomTypeService = roomTypeService;
            _fileHelper = fileHelper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAllRoomTypes()
        {
            var result = await _roomTypeService.GetAllAsync();
            if (result != null)
            {
                var hotelTypes = new GetAllRoomTypesViewModel()
                {
                    RoomTypes = result.Data,
                    Message = result.Message
                };
                return View(hotelTypes);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(GetAllRoomTypesViewModel getAllRoomTypesViewModel)
        {
            if (ModelState.IsValid)
            {
                var roomType = new RoomTypeAddDto()
                {
                    Name = getAllRoomTypesViewModel.Name,
                    PeopleCount = getAllRoomTypesViewModel.PeopleCount,
                };

                if (getAllRoomTypesViewModel.ImageUrl != null)
                {
                    var fileName = getAllRoomTypesViewModel.ImageUrl;
                    var imageFile = _fileHelper.UploadFile(fileName);
                    roomType.ImageUrl = imageFile;
                }

                var result = await _roomTypeService.AddAsync(roomType);
                if (result.Success)
                {
                    return RedirectToAction("GetAllRoomTypes");
                }
                return View();
            }
            return View();
        }


        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _roomTypeService.DeleteAsync(Id);
            if (result.Success)
            {
                return RedirectToAction("GetAllRoomTypes");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            var result = await _roomTypeService.GetByIdAsync(Id);
            if (result.Success)
            {
                var hotelType = new GetAllRoomTypesViewModel()
                {
                    Name = result.Data.Name,
                    PeopleCount = result.Data.PeopleCount,
                    OldImageUrl = result.Data.ImageUrl,
                };
                return View(hotelType);
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Update(GetAllRoomTypesViewModel getAllRoomTypesViewModel)
        {

            if (ModelState.IsValid)
            {
                var roomType = new RoomTypeUpdateDto()
                {
                    Id = getAllRoomTypesViewModel.Id,
                    Name = getAllRoomTypesViewModel.Name,
                    PeopleCount = getAllRoomTypesViewModel.PeopleCount,

                };

                if (getAllRoomTypesViewModel.ImageUrl != null)
                {
                    var fileName = getAllRoomTypesViewModel.ImageUrl;
                    var imageFile = _fileHelper.UploadFile(fileName);
                    roomType.ImageUrl = imageFile;
                }



                var result = await _roomTypeService.UpdateAsync(roomType);
                if (result.Success)
                {
                    return RedirectToAction("GetAllRoomTypes");
                }
                return View();
            }
            return View();
        }
    }
}
