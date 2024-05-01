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
        private readonly IRMBedService _rMBedService;
        private readonly IRMCarpetService _rMCarpetService;
        private readonly IRMAirConditionService _rMAirConditionService;
        private readonly IRMBathRoomService _rMBathRoomService;
        private readonly IFileHelper _fileHelper;
        public RoomMaterialsController(IUserAccessor userAccessor, IRoomMaterialService roomMaterialService, IFileHelper fileHelper, IRMTelevisionService rMTelevisionService, IRMToiletService rMToiletService, IRMBedService rMBedService, IRMCarpetService rMCarpetService, IRMBathRoomService rMBathRoomService, IRMAirConditionService rMAirConditionService) : base(userAccessor)
        {
            _roomMaterialService = roomMaterialService;
            _fileHelper = fileHelper;
            _rMTelevisionService = rMTelevisionService;
            _rMToiletService = rMToiletService;
            _rMBedService = rMBedService;
            _rMCarpetService = rMCarpetService;
            _rMBathRoomService = rMBathRoomService;
            _rMAirConditionService = rMAirConditionService;
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

        #region RMCarpet
        public async Task<IActionResult> GetAllRMCarpets()
        {

            var result = await _rMCarpetService.GetAllAsync();
            if (result != null)
            {
                var roomMaterials = new GetAllRMCarpetViewModel()
                {
                    RMCarpets = result.Data,
                    Message = result.Message
                };
                return View(roomMaterials);
            }
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> AddRMCarpet(GetAllRMCarpetViewModel getAllRMCarpetViewModel)
        {
            if (ModelState.IsValid)
            {
                var roomType = new RMCarpetAddDto()
                {
                    Name = getAllRMCarpetViewModel.Name,
                    Level = getAllRMCarpetViewModel.Level,
                    Price = getAllRMCarpetViewModel.Price,
                    QualityPoint = getAllRMCarpetViewModel.QualityPoint,
                };
                if (getAllRMCarpetViewModel.ImageUrl != null)
                {
                    var fileName = getAllRMCarpetViewModel.ImageUrl;
                    var imageFile = _fileHelper.UploadFile(fileName);
                    roomType.ImageUrl = imageFile;
                }

                var result = await _rMCarpetService.AddAsync(roomType);
                if (result.Success)
                {
                    return RedirectToAction("GetAllRMCarpets");
                }
                return View();
            }
            return View();
        }


        public async Task<IActionResult> DeleteRMCarpet(int Id)
        {
            var result = await _rMCarpetService.DeleteAsync(Id);
            if (result.Success)
            {
                return RedirectToAction("GetAllRMCarpets");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRMCarpet(int Id)
        {
            var result = await _rMCarpetService.GetByIdAsync(Id);
            if (result.Success)
            {
                var hotelType = new GetAllRMCarpetViewModel()
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
        public async Task<IActionResult> UpdateRMCarpet(GetAllRMCarpetViewModel getAllRMCarpetViewModel)
        {

            if (ModelState.IsValid)
            {
                var roomType = new RMCarpetUpdateDto()
                {
                    Id = getAllRMCarpetViewModel.Id,
                    Name = getAllRMCarpetViewModel.Name,
                    Level = getAllRMCarpetViewModel.Level,
                    Price = getAllRMCarpetViewModel.Price,
                    QualityPoint = getAllRMCarpetViewModel.QualityPoint,
                };

                if (getAllRMCarpetViewModel.ImageUrl != null)
                {
                    var fileName = getAllRMCarpetViewModel.ImageUrl;
                    var imageFile = _fileHelper.UploadFile(fileName);
                    roomType.ImageUrl = imageFile;
                }

                var result = await _rMCarpetService.UpdateAsync(roomType);
                if (result.Success)
                {
                    return RedirectToAction("GetAllRMCarpets");
                }
                return View();
            }
            return View();
        }
        #endregion

        #region RmAirCondition

        public async Task<IActionResult> GetAllRMAirConditions()
        {

            var result = await _rMAirConditionService.GetAllAsync();
            if (result != null)
            {
                var roomMaterials = new GetAllRMAirConditionViewModel()
                {
                    RMAirConditions = result.Data,
                    Message = result.Message
                };
                return View(roomMaterials);
            }
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> AddRMAirCondition(GetAllRMAirConditionViewModel getAllRMAirConditionViewModel)
        {
            if (ModelState.IsValid)
            {
                var roomType = new RMAirConditionAddDto()
                {
                    Name = getAllRMAirConditionViewModel.Name,
                    Level = getAllRMAirConditionViewModel.Level,
                    Price = getAllRMAirConditionViewModel.Price,
                    QualityPoint = getAllRMAirConditionViewModel.QualityPoint,
                };
                if (getAllRMAirConditionViewModel.ImageUrl != null)
                {
                    var fileName = getAllRMAirConditionViewModel.ImageUrl;
                    var imageFile = _fileHelper.UploadFile(fileName);
                    roomType.ImageUrl = imageFile;
                }

                var result = await _rMAirConditionService.AddAsync(roomType);
                if (result.Success)
                {
                    return RedirectToAction("GetAllRMAirConditions");
                }
                return View();
            }
            return View();
        }


        public async Task<IActionResult> DeleteRMAirCondition(int Id)
        {
            var result = await _rMAirConditionService.DeleteAsync(Id);
            if (result.Success)
            {
                return RedirectToAction("GetAllRMAirConditions");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRMAirCondition(int Id)
        {
            var result = await _rMAirConditionService.GetByIdAsync(Id);
            if (result.Success)
            {
                var hotelType = new GetAllRMAirConditionViewModel()
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
        public async Task<IActionResult> UpdateRMAirCondition(GetAllRMAirConditionViewModel getAllRMAirConditionViewModel)
        {

            if (ModelState.IsValid)
            {
                var roomType = new RMAirConditionUpdateDto()
                {
                    Id = getAllRMAirConditionViewModel.Id,
                    Name = getAllRMAirConditionViewModel.Name,
                    Level = getAllRMAirConditionViewModel.Level,
                    Price = getAllRMAirConditionViewModel.Price,
                    QualityPoint = getAllRMAirConditionViewModel.QualityPoint,
                };

                if (getAllRMAirConditionViewModel.ImageUrl != null)
                {
                    var fileName = getAllRMAirConditionViewModel.ImageUrl;
                    var imageFile = _fileHelper.UploadFile(fileName);
                    roomType.ImageUrl = imageFile;
                }

                var result = await _rMAirConditionService.UpdateAsync(roomType);
                if (result.Success)
                {
                    return RedirectToAction("GetAllRMAirConditions");
                }
                return View();
            }
            return View();
        }

        #endregion

        #region Toilet
        public async Task<IActionResult> GetAllRMToilets()
        {

            var result = await _rMToiletService.GetAllAsync();
            if (result != null)
            {
                var roomMaterials = new GetAllRMToiletViewModel()
                {
                    RMToilets = result.Data,
                    Message = result.Message
                };
                return View(roomMaterials);
            }
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> AddRMToilet(GetAllRMToiletViewModel getAllRMToiletViewModel)
        {
            if (ModelState.IsValid)
            {
                var roomType = new RMToiletAddDto()
                {
                    Name = getAllRMToiletViewModel.Name,
                    Level = getAllRMToiletViewModel.Level,
                    Price = getAllRMToiletViewModel.Price,
                    QualityPoint = getAllRMToiletViewModel.QualityPoint,
                };
                if (getAllRMToiletViewModel.ImageUrl != null)
                {
                    var fileName = getAllRMToiletViewModel.ImageUrl;
                    var imageFile = _fileHelper.UploadFile(fileName);
                    roomType.ImageUrl = imageFile;
                }

                var result = await _rMToiletService.AddAsync(roomType);
                if (result.Success)
                {
                    return RedirectToAction("GetAllRMToilets");
                }
                return View();
            }
            return View();
        }


        public async Task<IActionResult> DeleteRMToilet(int Id)
        {
            var result = await _rMToiletService.DeleteAsync(Id);
            if (result.Success)
            {
                return RedirectToAction("GetAllRMToilets");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRMToilet(int Id)
        {
            var result = await _rMToiletService.GetByIdAsync(Id);
            if (result.Success)
            {
                var hotelType = new GetAllRMToiletViewModel()
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
        public async Task<IActionResult> UpdateRMToilet(GetAllRMToiletViewModel getAllRMToiletViewModel)
        {

            if (ModelState.IsValid)
            {
                var roomType = new RMToiletUpdateDto()
                {
                    Id = getAllRMToiletViewModel.Id,
                    Name = getAllRMToiletViewModel.Name,
                    Level = getAllRMToiletViewModel.Level,
                    Price = getAllRMToiletViewModel.Price,
                    QualityPoint = getAllRMToiletViewModel.QualityPoint,
                };

                if (getAllRMToiletViewModel.ImageUrl != null)
                {
                    var fileName = getAllRMToiletViewModel.ImageUrl;
                    var imageFile = _fileHelper.UploadFile(fileName);
                    roomType.ImageUrl = imageFile;
                }

                var result = await _rMToiletService.UpdateAsync(roomType);
                if (result.Success)
                {
                    return RedirectToAction("GetAllRMToilets");
                }
                return View();
            }
            return View();
        }
        #endregion

        #region Bed
        public async Task<IActionResult> GetAllRMBeds()
        {

            var result = await _rMBedService.GetAllAsync();
            if (result != null)
            {
                var roomMaterials = new GetAllRMBedViewModel()
                {
                    RMBeds = result.Data,
                    Message = result.Message
                };
                return View(roomMaterials);
            }
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> AddRMBed(GetAllRMBedViewModel getAllRMBedViewModel)
        {
            if (ModelState.IsValid)
            {
                var roomType = new RMBedAddDto()
                {
                    Name = getAllRMBedViewModel.Name,
                    Level = getAllRMBedViewModel.Level,
                    Price = getAllRMBedViewModel.Price,
                    QualityPoint = getAllRMBedViewModel.QualityPoint,
                };
                if (getAllRMBedViewModel.ImageUrl != null)
                {
                    var fileName = getAllRMBedViewModel.ImageUrl;
                    var imageFile = _fileHelper.UploadFile(fileName);
                    roomType.ImageUrl = imageFile;
                }

                var result = await _rMBedService.AddAsync(roomType);
                if (result.Success)
                {
                    return RedirectToAction("GetAllRMBeds");
                }
                return View();
            }
            return View();
        }


        public async Task<IActionResult> DeleteRMBed(int Id)
        {
            var result = await _rMBedService.DeleteAsync(Id);
            if (result.Success)
            {
                return RedirectToAction("GetAllRMBeds");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRMBed(int Id)
        {
            var result = await _rMBedService.GetByIdAsync(Id);
            if (result.Success)
            {
                var hotelType = new GetAllRMBedViewModel()
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
        public async Task<IActionResult> UpdateRMBed(GetAllRMBedViewModel getAllRMBedViewModel)
        {

            if (ModelState.IsValid)
            {
                var roomType = new RMBedUpdateDto()
                {
                    Id = getAllRMBedViewModel.Id,
                    Name = getAllRMBedViewModel.Name,
                    Level = getAllRMBedViewModel.Level,
                    Price = getAllRMBedViewModel.Price,
                    QualityPoint = getAllRMBedViewModel.QualityPoint,
                };

                if (getAllRMBedViewModel.ImageUrl != null)
                {
                    var fileName = getAllRMBedViewModel.ImageUrl;
                    var imageFile = _fileHelper.UploadFile(fileName);
                    roomType.ImageUrl = imageFile;
                }

                var result = await _rMBedService.UpdateAsync(roomType);
                if (result.Success)
                {
                    return RedirectToAction("GetAllRMBeds");
                }
                return View();
            }
            return View();
        }
        #endregion

        #region BathRoom
        public async Task<IActionResult> GetAllRMBathRooms()
        {

            var result = await _rMBathRoomService.GetAllAsync();
            if (result != null)
            {
                var roomMaterials = new GetAllRMBathRoomViewModel()
                {
                    RMBathRooms = result.Data,
                    Message = result.Message
                };
                return View(roomMaterials);
            }
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> AddRMBathRoom(GetAllRMBathRoomViewModel getAllRMBathRoomViewModel)
        {
            if (ModelState.IsValid)
            {
                var roomType = new RMBathRoomAddDto()
                {
                    Name = getAllRMBathRoomViewModel.Name,
                    Level = getAllRMBathRoomViewModel.Level,
                    Price = getAllRMBathRoomViewModel.Price,
                    QualityPoint = getAllRMBathRoomViewModel.QualityPoint,
                };
                if (getAllRMBathRoomViewModel.ImageUrl != null)
                {
                    var fileName = getAllRMBathRoomViewModel.ImageUrl;
                    var imageFile = _fileHelper.UploadFile(fileName);
                    roomType.ImageUrl = imageFile;
                }

                var result = await _rMBathRoomService.AddAsync(roomType);
                if (result.Success)
                {
                    return RedirectToAction("GetAllRMBathRooms");
                }
                return View();
            }
            return View();
        }


        public async Task<IActionResult> DeleteRMBathRoom(int Id)
        {
            var result = await _rMBathRoomService.DeleteAsync(Id);
            if (result.Success)
            {
                return RedirectToAction("GetAllRMBathRooms");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRMBathRoom(int Id)
        {
            var result = await _rMBathRoomService.GetByIdAsync(Id);
            if (result.Success)
            {
                var hotelType = new GetAllRMBathRoomViewModel()
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
        public async Task<IActionResult> UpdateRMBathRoom(GetAllRMBathRoomViewModel getAllRMBathRoomViewModel)
        {

            if (ModelState.IsValid)
            {
                var roomType = new RMBathRoomUpdateDto()
                {
                    Id = getAllRMBathRoomViewModel.Id,
                    Name = getAllRMBathRoomViewModel.Name,
                    Level = getAllRMBathRoomViewModel.Level,
                    Price = getAllRMBathRoomViewModel.Price,
                    QualityPoint = getAllRMBathRoomViewModel.QualityPoint,
                };

                if (getAllRMBathRoomViewModel.ImageUrl != null)
                {
                    var fileName = getAllRMBathRoomViewModel.ImageUrl;
                    var imageFile = _fileHelper.UploadFile(fileName);
                    roomType.ImageUrl = imageFile;
                }

                var result = await _rMBathRoomService.UpdateAsync(roomType);
                if (result.Success)
                {
                    return RedirectToAction("GetAllRMBathRooms");
                }
                return View();
            }
            return View();
        }
        #endregion
    }

}
