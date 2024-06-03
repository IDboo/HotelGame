using HotelGame.Business.Abstract;
using HotelGame.WebMVC.Helper.Abstract;
using HotelGame.WebMVC.Models.GamePlay;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace HotelGame.WebMVC.Areas.Users.Controllers
{
    public class DashboardController : BaseController
    {
        private readonly IAutoCreaterService _autoCreaterService;
        private readonly IPlayerHotelService _playerHotelService;
        private readonly IPlayerRoomService _playerRoomService;
        private readonly IRoomTypeService _roomTypeService;
        private readonly IPlayerRoomMaterialService _playerRoomMaterialService;

        private readonly IRMTelevisionService _rMTelevisionService;
        private readonly IRMAirConditionService _rMAirConditionService;
        private readonly IRMBedService _rMBedService;
        private readonly IRMBathRoomService _rMBathRoomService;
        private readonly IRMToiletService _rMToiletService;
        private readonly IRMCarpetService _rMCarpetService;

        public DashboardController(IUserAccessor userAccessor, IAutoCreaterService autoCreaterService, IPlayerHotelService playerHotelService, IPlayerRoomService playerRoomService, IRoomTypeService roomTypeService, IRMTelevisionService rMTelevisionService, IRMAirConditionService rMAirConditionService, IRMBedService rMBedService, IRMBathRoomService rMBathRoomService, IRMToiletService rMToiletService, IRMCarpetService rMCarpetService, IPlayerRoomMaterialService playerRoomMaterialService) : base(userAccessor)
        {
            _autoCreaterService = autoCreaterService;
            _playerHotelService = playerHotelService;
            _playerRoomService = playerRoomService;
            _roomTypeService = roomTypeService;
            _rMTelevisionService = rMTelevisionService;
            _rMAirConditionService = rMAirConditionService;
            _rMBedService = rMBedService;
            _rMBathRoomService = rMBathRoomService;
            _rMToiletService = rMToiletService;
            _rMCarpetService = rMCarpetService;
            _playerRoomMaterialService = playerRoomMaterialService;
        }


        public async Task<IActionResult> Index()
        {
            var rMTelevision = await _rMTelevisionService.GetAllAsync();
            var rMAirCondition = await _rMAirConditionService.GetAllAsync();
            var rMBeds = await _rMBedService.GetAllAsync();
            var rMBathRooms = await _rMBathRoomService.GetAllAsync();
            var rMToilets = await _rMToiletService.GetAllAsync();
            var rMCarpet = await _rMCarpetService.GetAllAsync();

            var playerRoomMaterials = await _playerRoomMaterialService.GetAllAsync();   
            var roomTypes = await _roomTypeService.GetAllAsync();

            var userId = CurrentUser.Id;
            var result = await _playerHotelService.PlayerHotelByUserId(userId);
            if (result.Success)
            {
                var playerHotelDetail = await _playerHotelService.PlayerHotelByUserId(userId);
                var currentPlayerRooms = await _playerRoomService.GetAllByUserIdAsync(result.Data.Id);

                var playerHotel = new GetAllPlayerRoomsViewModel
                {
                    PlayerHotel = playerHotelDetail.Data,
                    PlayerRooms = currentPlayerRooms.Data
                };
                return View(playerHotel);
            }
            else
            {
                var playerHotel = new GetAllPlayerRoomsViewModel
                {
                    CheckPlayerHotel = true
                };
                return View(playerHotel);
            }
        }


        [HttpPost]
        public IActionResult HotelCreater(GetAllPlayerRoomsViewModel getAllPlayerRoomsViewModel)
        {
            var userId = CurrentUser.Id;
            var result = _autoCreaterService.NewHotelCreater(userId, getAllPlayerRoomsViewModel.HotelName);
            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            return View();
        }




    }
}
