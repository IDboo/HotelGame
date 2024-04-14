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
        private readonly IRoomMaterialService _roomMaterialService;
        private readonly IPlayerRoomService _playerRoomService;
        private readonly IPlayerHotelService _playerHotelService;

        public PlayerRoomController(IUserAccessor userAccessor, IPlayerRoomMaterialService playerRoomMaterialService, IRoomMaterialService roomMaterialService, IPlayerRoomService playerRoomService, IPlayerHotelService playerHotelService) : base(userAccessor)
        {
            _playerRoomMaterialService = playerRoomMaterialService;
            _roomMaterialService = roomMaterialService;
            _playerRoomService = playerRoomService;
            _playerHotelService = playerHotelService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetRoomDetail(int Id)
        {
            var userId = CurrentUser.Id;
            var roomMaterial = await _roomMaterialService.GetAllAsync();
            var result = await _playerRoomMaterialService.GetAllByPlayerRoomIdAsync(Id);
            var playerHotelDetail = await _playerHotelService.PlayerHotelByUserId(userId);

            if (result.Success)
            {
                var playerRoomMaterials = new GetAllPlayerRoomsViewModel
                {
                    PlayerHotel = playerHotelDetail.Data,
                    PlayerRoomMaterials = result.Data
                };

                return View(playerRoomMaterials);
            }
            return View();
        }
    }
}
