using HotelGame.Business.Abstract;
using HotelGame.WebMVC.Helper.Abstract;
using HotelGame.WebMVC.Models.GamePlay;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HotelGame.WebMVC.Areas.Users.Controllers
{
    public class PlayerRoomController : BaseController
    {
        private readonly IPlayerRoomMaterialService _playerRoomMaterialService;
        private readonly IPlayerRoomService _playerRoomService;
        private readonly IPlayerHotelService _playerHotelService;
        private readonly IRMTelevisionService _rMTelevisionService;
        private readonly IRMAirConditionService _rMAirConditionService;
        private readonly IRMBedService _rMBedService;
        private readonly IRMBathRoomService _rMBathRoomService;
        private readonly IRMToiletService _rMToiletService;
        private readonly IRMCarpetService _rMCarpetService;

        public PlayerRoomController(
            IUserAccessor userAccessor,
            IPlayerRoomMaterialService playerRoomMaterialService,
            IPlayerRoomService playerRoomService,
            IPlayerHotelService playerHotelService,
            IRMTelevisionService rMTelevisionService,
            IRMAirConditionService rMAirConditionService,
            IRMBedService rMBedService,
            IRMBathRoomService rMBathRoomService,
            IRMToiletService rMToiletService,
            IRMCarpetService rMCarpetService)
            : base(userAccessor)
        {
            _playerRoomMaterialService = playerRoomMaterialService;
            _playerRoomService = playerRoomService;
            _playerHotelService = playerHotelService;
            _rMTelevisionService = rMTelevisionService;
            _rMAirConditionService = rMAirConditionService;
            _rMBedService = rMBedService;
            _rMBathRoomService = rMBathRoomService;
            _rMToiletService = rMToiletService;
            _rMCarpetService = rMCarpetService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetRoomDetail(int Id)
        {
            var userId = CurrentUser.Id;
            var rMTelevision = await _rMTelevisionService.GetAllAsync();
            var rMAirCondition = await _rMAirConditionService.GetAllAsync();
            var rMBeds = await _rMBedService.GetAllAsync();
            var rMBathRooms = await _rMBathRoomService.GetAllAsync();
            var rMToilets = await _rMToiletService.GetAllAsync();
            var rMCarpet = await _rMCarpetService.GetAllAsync();

            var maksimumLevelAirCondition = _rMAirConditionService.GetMaksimumLevel();
            var maksimumLevelBathRoom = _rMBathRoomService.GetMaksimumLevel();
            var maksimumLevelBed = _rMBedService.GetMaksimumLevel();
            var maksimumLevelCarpet = _rMCarpetService.GetMaksimumLevel();
            var maksimumLevelTelevision = _rMTelevisionService.GetMaksimumLevel();
            var maksimumLevelToilet = _rMToiletService.GetMaksimumLevel();

            var result = await _playerRoomMaterialService.GetAllByPlayerRoomIdAsync(Id);
            var playerHotelDetail = await _playerHotelService.PlayerHotelByUserId(userId);

            var upperLevelMaterialResult = await _playerRoomMaterialService.GetUpperLevelMaterial(Id);

            if (result.Success && upperLevelMaterialResult.Success && playerHotelDetail.Data != null)
            {
                var playerRoomMaterials = new GetAllPlayerRoomsViewModel
                {
                    PlayerHotel = playerHotelDetail.Data,
                    PlayerRoomMaterials = result.Data,
                    UpperRoomMaterial = upperLevelMaterialResult.Data,
                    MaksimumLevelAirCondition = maksimumLevelAirCondition,
                    MaksimumLevelBed = maksimumLevelBed,
                    MaksimumLevelBathRoom = maksimumLevelBathRoom,
                    MaksimumLevelCarpet = maksimumLevelCarpet,
                    MaksimumLevelTelevision = maksimumLevelTelevision,
                    MaksimumLevelToilet = maksimumLevelToilet
                };
                return View(playerRoomMaterials);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRMTelevision(int PlayerRoomId, int RMTelevisionId, int PlayerHotelId)
        {
            var result = await _playerRoomMaterialService.UpdateRmTelevisionLevelAsync(PlayerRoomId, RMTelevisionId, PlayerHotelId);
            if (result.Success)
            {
                return RedirectToAction("GetRoomDetail", new { Id = PlayerRoomId });
            }
            ViewBag.ProjectResultMessage = result.Message;
            return RedirectToAction("GetRoomDetail");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRMAirCondition(int PlayerRoomId, int RMAirConditionId, int PlayerHotelId)
        {
            var result = await _playerRoomMaterialService.UpdateRmAirConditionLevelAsync(PlayerRoomId, RMAirConditionId, PlayerHotelId);
            if (result.Success)
            {
                return RedirectToAction("GetRoomDetail", new { Id = PlayerRoomId });
            }
            ViewBag.ProjectResultMessage = result.Message;
            return RedirectToAction("GetRoomDetail");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRMBathRoom(int PlayerRoomId, int RMBathRoomId, int PlayerHotelId)
        {
            var result = await _playerRoomMaterialService.UpdateRmBathRoomLevelAsync(PlayerRoomId, RMBathRoomId, PlayerHotelId);
            if (result.Success)
            {
                return RedirectToAction("GetRoomDetail", new { Id = PlayerRoomId });
            }
            ViewBag.ProjectResultMessage = result.Message;
            return RedirectToAction("GetRoomDetail");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRMBed(int PlayerRoomId, int RMBedId, int PlayerHotelId)
        {
            var result = await _playerRoomMaterialService.UpdateRmBedLevelAsync(PlayerRoomId, RMBedId, PlayerHotelId);
            if (result.Success)
            {
                return RedirectToAction("GetRoomDetail", new { Id = PlayerRoomId });
            }
            ViewBag.ProjectResultMessage = result.Message;
            return RedirectToAction("GetRoomDetail");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRMCarpet(int PlayerRoomId, int RMCarpetId, int PlayerHotelId)
        {
            var result = await _playerRoomMaterialService.UpdateRmCarpetLevelAsync(PlayerRoomId, RMCarpetId, PlayerHotelId);
            if (result.Success)
            {
                return RedirectToAction("GetRoomDetail", new { Id = PlayerRoomId });
            }
            ViewBag.ProjectResultMessage = result.Message;
            return RedirectToAction("GetRoomDetail");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRMToilet(int PlayerRoomId, int RMToiletId, int PlayerHotelId)
        {
            var result = await _playerRoomMaterialService.UpdateRmToiletLevelAsync(PlayerRoomId, RMToiletId, PlayerHotelId);
            if (result.Success)
            {
                return RedirectToAction("GetRoomDetail", new { Id = PlayerRoomId });
            }
            ViewBag.ProjectResultMessage = result.Message;
            return RedirectToAction("GetRoomDetail");
        }
    }
}
