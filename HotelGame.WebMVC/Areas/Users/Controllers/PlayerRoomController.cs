using HotelGame.Business.Abstract;
using HotelGame.WebMVC.Helper.Abstract;
using HotelGame.WebMVC.Models.GamePlay;
using Microsoft.AspNetCore.Mvc;
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
        public PlayerRoomController(IUserAccessor userAccessor, IPlayerRoomMaterialService playerRoomMaterialService, IPlayerRoomService playerRoomService, IPlayerHotelService playerHotelService, IRMTelevisionService rMTelevisionService, IRMAirConditionService rMAirConditionService) : base(userAccessor)
        {
            _playerRoomMaterialService = playerRoomMaterialService;
            _playerRoomService = playerRoomService;
            _playerHotelService = playerHotelService;
            _rMTelevisionService = rMTelevisionService;
            _rMAirConditionService = rMAirConditionService;
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
            var result = await _playerRoomMaterialService.GetAllByPlayerRoomIdAsync(Id);
            var playerHotelDetail = await _playerHotelService.PlayerHotelByUserId(userId);
            var upperLevelMaterial = await _playerRoomMaterialService.GetUpperLevelMaterial(Id);

            if (result.Success)
            {
                var playerRoomMaterials = new GetAllPlayerRoomsViewModel
                {
                    PlayerHotel = playerHotelDetail.Data,
                    PlayerRoomMaterials = result.Data,
                    UpperRoomMaterial = upperLevelMaterial.Data,
                };

                return View(playerRoomMaterials);
            }
            return View();
        }
    }
}
