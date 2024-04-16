using HotelGame.Business.Abstract;
using HotelGame.DataAccess.Abstract;
using HotelGame.Entities.DTOs.RoomMaterial;
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
        private readonly IRMTelevisionService _rMTelevisionService;
        private readonly IRMToiletService _rMToiletService;
        private readonly IRMBedService _rMbedService;
        private readonly IRMCarpetService _rMCarpetService;
        private readonly IRMAirConditionDal _rMAirConditionDal;
        private readonly IRMBathRoomService _rMBathRoomService;
        private readonly IFileHelper _fileHelper;
        public RoomMaterialsController(IUserAccessor userAccessor, IRoomMaterialService roomMaterialService, IFileHelper fileHelper, IRMTelevisionService rMTelevisionService, IRMToiletService rMToiletService, IRMBedService rMbedService, IRMCarpetService rMCarpetService, IRMAirConditionDal rMAirConditionDal, IRMBathRoomService rMBathRoomService) : base(userAccessor)
        {
            _roomMaterialService = roomMaterialService;
            _fileHelper = fileHelper;
            _rMTelevisionService = rMTelevisionService;
            _rMToiletService = rMToiletService;
            _rMbedService = rMbedService;
            _rMCarpetService = rMCarpetService;
            _rMAirConditionDal = rMAirConditionDal;
            _rMBathRoomService = rMBathRoomService;
        }

        public IActionResult Index()
        {
            return View();
        }


        #region RoomMaterial

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
                };

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
                };

                var result = await _roomMaterialService.UpdateAsync(roomType);
                if (result.Success)
                {
                    return RedirectToAction("GetAllRoomMaterials");
                }
                return View();
            }
            return View();
        }


        #endregion


        #region RMTelevision

        public async Task<IActionResult> GetAllRMTelevisions()
        {

            var result = await _rMTelevisionService.GetAllAsync();
            if (result != null)
            {
                var roomMaterials = new GetAllRMTelevisionViewModel()
                {
                    RMTelevisions = result.Data,
                    Message = result.Message
                };
                return View(roomMaterials);
            }
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> AddRMTelevision(GetAllRMTelevisionViewModel getAllRMTelevisionViewModel)
        {
            if (ModelState.IsValid)
            {
                var roomType = new RMTelevisionAddDto()
                {
                    Name = getAllRMTelevisionViewModel.Name,
                    Level = getAllRMTelevisionViewModel.Level,
                    Price = getAllRMTelevisionViewModel.Price,
                    QualityPoint = getAllRMTelevisionViewModel.QualityPoint,
                };
                if (getAllRMTelevisionViewModel.ImageUrl != null)
                {
                    var fileName = getAllRMTelevisionViewModel.ImageUrl;
                    var imageFile = _fileHelper.UploadFile(fileName);
                    roomType.ImageUrl = imageFile;
                }

                var result = await _rMTelevisionService.AddAsync(roomType);
                if (result.Success)
                {
                    return RedirectToAction("GetAllRMTelevisions");
                }
                return View();
            }
            return View();
        }


        public async Task<IActionResult> DeleteRMTelevision(int Id)
        {
            var result = await _rMTelevisionService.DeleteAsync(Id);
            if (result.Success)
            {
                return RedirectToAction("GetAllRMTelevisions");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRMTelevision(int Id)
        {
            var result = await _rMTelevisionService.GetByIdAsync(Id);
            if (result.Success)
            {
                var hotelType = new GetAllRMTelevisionViewModel()
                {
                    Name = result.Data.Name,
                    Level = result.Data.Level,
                    Price = result.Data.Price,
                    QualityPoint = result.Data.QualityPoint,
                    OldImageUrl = result.Data.ImageUrl
                };
                return View(hotelType);
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateRMTelevision(GetAllRMTelevisionViewModel getAllRMTelevisionViewModel)
        {

            if (ModelState.IsValid)
            {
                var roomType = new RMTelevisionUpdateDto()
                {
                    Id = getAllRMTelevisionViewModel.Id,
                    Name = getAllRMTelevisionViewModel.Name,
                    Level = getAllRMTelevisionViewModel.Level,
                    Price = getAllRMTelevisionViewModel.Price,
                    QualityPoint = getAllRMTelevisionViewModel.QualityPoint,
                };

                if (getAllRMTelevisionViewModel.ImageUrl != null)
                {
                    var fileName = getAllRMTelevisionViewModel.ImageUrl;
                    var imageFile = _fileHelper.UploadFile(fileName);
                    roomType.ImageUrl = imageFile;
                }

                var result = await _rMTelevisionService.UpdateAsync(roomType);
                if (result.Success)
                {
                    return RedirectToAction("GetAllRMTelevisions");
                }
                return View();
            }
            return View();
        }

        #endregion

        

    }

}
