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
            var result = await _playerRoomMaterialService.GetAllByPlayerRoomIdAsync(Id);
            var playerHotelDetail = await _playerHotelService.PlayerHotelByUserId(userId);
            var upperLevelMaterialResult = await _playerRoomMaterialService.GetUpperLevelMaterial(Id);

            string logFilePath = "C:\\AllProjects\\C#\\HotelGame\\HotelGame.WebMVC\\logs.txt";
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"UserId: {userId}");
                writer.WriteLine($"RMTelevision Count: {rMTelevision?.Data?.Count}");
                writer.WriteLine($"RMAirCondition Count: {rMAirCondition?.Data?.Count}");
                writer.WriteLine($"RMBed Count: {rMBeds?.Data?.Count}");
                writer.WriteLine($"RMBathRoom Count: {rMBathRooms?.Data?.Count}");
                writer.WriteLine($"RMToilet Count: {rMToilets?.Data?.Count}");
                writer.WriteLine($"RMCarpet Count: {rMCarpet?.Data?.Count}");
                writer.WriteLine($"PlayerHotelDetail: {playerHotelDetail?.Data?.HotelName}");
                writer.WriteLine($"PlayerRoomMaterials Count: {result?.Data?.Count}");
                writer.WriteLine($"UpperLevelMaterial: {upperLevelMaterialResult?.Data?.ToString() ?? "Null"}");

                if (result.Data != null)
                {
                    foreach (var material in result.Data)
                    {
                        writer.WriteLine($"Material Id: {material.Id}, RMAirCondition: {material.RMAirCondition?.Name ?? "Null"}, RMTelevision: {material.RMTelevision?.Name ?? "Null"}");
                    }
                }
            }

            if (result.Success && upperLevelMaterialResult.Success && playerHotelDetail.Data != null)
            {
                var playerRoomMaterials = new GetAllPlayerRoomsViewModel
                {
                    PlayerHotel = playerHotelDetail.Data,
                    PlayerRoomMaterials = result.Data,
                    UpperRoomMaterial = upperLevelMaterialResult.Data
                };

                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"PlayerRoomMaterials: {string.Join(", ", playerRoomMaterials.PlayerRoomMaterials.Select(m => m.RMAirCondition?.Name ?? "Null"))}");
                    writer.WriteLine($"UpperRoomMaterial: {playerRoomMaterials.UpperRoomMaterial?.RMAirCondition?.Name ?? "Null"}");
                    writer.WriteLine($"UpperRoomMaterial Details: {playerRoomMaterials.UpperRoomMaterial}");
                }

                // Burada null kontrolü ekliyoruz
                if (playerRoomMaterials.UpperRoomMaterial == null)
                {
                    using (StreamWriter writer = new StreamWriter(logFilePath, true))
                    {
                        writer.WriteLine("UpperRoomMaterial is null after assignment.");
                    }
                }

                return View(playerRoomMaterials);
            }

            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine("Failed to retrieve player room materials or upper level material is null.");
                writer.WriteLine($"Success: {result.Success}, UpperLevelMaterialSuccess: {upperLevelMaterialResult.Success}, PlayerHotelData: {playerHotelDetail.Data != null}");
            }

            return View();
        }
    }
}
