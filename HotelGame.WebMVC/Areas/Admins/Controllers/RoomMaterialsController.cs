using HotelGame.Business.Abstract;
using HotelGame.Entities.DTOs.RoomMaterials;
using HotelGame.WebMVC.Helper.Abstract;
using HotelGame.WebMVC.Models.RoomMaterials;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelGame.WebMVC.Areas.Admins.Controllers
{
    public class RoomMaterialsController : BaseController
    {
        private readonly IRoomMaterialService _roomMaterialService;
        private readonly IFileHelper _fileHelper;
        public RoomMaterialsController(IUserAccessor userAccessor, IRoomMaterialService roomMaterialService, IFileHelper fileHelper) : base(userAccessor)
        {
            _roomMaterialService = roomMaterialService;
            _fileHelper = fileHelper;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> GetAllRoomMaterials()
        {
            var result = await _roomMaterialService.GetAllAsync();
            if (result != null)
            {
                var roomMaterials = new GetAllRoomMaterialsViewModel()
                {
                    RoomMaterials = result.Data,
                    Message = result.Message
                };
                return View(roomMaterials);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(GetAllRoomMaterialsViewModel getAllRoomMaterialsViewModel)
        {
            if (ModelState.IsValid)
            {
                var roomType = new RoomMaterialAddDto()
                {
                    Name = getAllRoomMaterialsViewModel.Name,
                    Level = getAllRoomMaterialsViewModel.Level,
                    Price = getAllRoomMaterialsViewModel.Price,
                    QualityPoint = getAllRoomMaterialsViewModel.QualityPoint,
                };

                if (getAllRoomMaterialsViewModel.ImageUrl != null)
                {
                    var fileName = getAllRoomMaterialsViewModel.ImageUrl;
                    var imageFile = _fileHelper.UploadFile(fileName);
                    roomType.ImageUrl = imageFile;
                }

                var result = await _roomMaterialService.AddAsync(roomType);
                if (result.Success)
                {
                    return RedirectToAction("GetAllRoomMaterials");
                }
                return View();
            }
            return View();
        }


        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _roomMaterialService.DeleteAsync(Id);
            if (result.Success)
            {
                return RedirectToAction("GetAllRoomMaterials");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            var result = await _roomMaterialService.GetByIdAsync(Id);
            if (result.Success)
            {
                var hotelType = new GetAllRoomMaterialsViewModel()
                {
                    Name = result.Data.Name,
                    Level = result.Data.Level,
                    Price = result.Data.Price,
                    QualityPoint = result.Data.QualityPoint,
                };
                return View(hotelType);
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Update(GetAllRoomMaterialsViewModel getAllRoomMaterialsViewModel)
        {

            if (ModelState.IsValid)
            {
                var roomType = new RoomMaterialUpdateDto()
                {
                    Id = getAllRoomMaterialsViewModel.Id,
                    Name = getAllRoomMaterialsViewModel.Name,
                    Level = getAllRoomMaterialsViewModel.Level,
                    Price = getAllRoomMaterialsViewModel.Price,
                    QualityPoint=getAllRoomMaterialsViewModel.QualityPoint,
                };

                if (getAllRoomMaterialsViewModel.ImageUrl != null)
                {
                    var fileName = getAllRoomMaterialsViewModel.ImageUrl;
                    var imageFile = _fileHelper.UploadFile(fileName);
                    roomType.ImageUrl = imageFile;
                }

                var result = await _roomMaterialService.UpdateAsync(roomType);
                if (result.Success)
                {
                    return RedirectToAction("GetAllRoomMaterials");
                }
                return View();
            }
            return View();
        }
    }

}
