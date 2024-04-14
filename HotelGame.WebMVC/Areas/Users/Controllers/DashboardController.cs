using HotelGame.Business.Abstract;
using HotelGame.WebMVC.Helper.Abstract;
using HotelGame.WebMVC.Models.GamePlay;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelGame.WebMVC.Areas.Users.Controllers
{
    public class DashboardController : BaseController
    {
        private readonly IAutoCreaterService _autoCreaterService;
        private readonly IPlayerHotelService _playerHotelService;
        private readonly IPlayerRoomService _playerRoomService;
        private readonly IRoomTypeService _roomTypeService;

        public DashboardController(IUserAccessor userAccessor, IAutoCreaterService autoCreaterService, IPlayerHotelService playerHotelService, IPlayerRoomService playerRoomService, IRoomTypeService roomTypeService) : base(userAccessor)
        {
            _autoCreaterService = autoCreaterService;
            _playerHotelService = playerHotelService;
            _playerRoomService = playerRoomService;
            _roomTypeService = roomTypeService;
        }


        public async Task<IActionResult> Index()
        {
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
