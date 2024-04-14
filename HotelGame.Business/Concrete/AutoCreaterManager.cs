using HotelGame.Business.Abstract;
using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Core.Utilities.Result.Concrete;
using HotelGame.Entities.DTOs.PlayerHotels;
using HotelGame.Entities.DTOs.PlayerRoomMaterials;
using HotelGame.Entities.DTOs.PlayerRooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.Business.Concrete
{
    public class AutoCreaterManager : IAutoCreaterService
    {
        private readonly IHotelTypeService _hotelTypeService;
        private readonly IRoomTypeService _roomTypeService;
        private readonly IRoomMaterialService _roomMaterialService;
        private readonly IPlayerHotelService _playerHotelService;
        private readonly IPlayerRoomService _playerRoomService;
        private readonly IPlayerRoomMaterialService _playerRoomMaterialService;

        public AutoCreaterManager(IHotelTypeService hotelTypeService, IRoomTypeService roomTypeService, IRoomMaterialService roomMaterialService, IPlayerHotelService playerHotelService, IPlayerRoomService playerRoomService, IPlayerRoomMaterialService playerRoomMaterialService)
        {
            _hotelTypeService = hotelTypeService;
            _roomTypeService = roomTypeService;
            _roomMaterialService = roomMaterialService;
            _playerHotelService = playerHotelService;
            _playerRoomService = playerRoomService;
            _playerRoomMaterialService = playerRoomMaterialService;
        }

        public IResult NewHotelCreater(int userId, string hotelName)
        {
            _playerHotelService.Add(new PlayerHotelAddDto
            {
                UserId = userId,
                HotelLevel = 1,
                HotelMoney = 1500,
                HotelName = hotelName,
                HotelTypeId = 1,
                CustomerCommentPointAvarage = 3,
                HotelQuality = 65
            });
            int lastHotelId = _playerHotelService.LastId();
            for (int i = 1; i < 6; i++)
            {
                _playerRoomService.Add(new PlayerRoomAddDto
                {
                    PlayerHotelId = lastHotelId,
                    RoomTypeId = i,
                    Availability = true,
                    RoomDailyPrice = 25
                });
                int lastplayerRoomId = _playerRoomService.LastId();
                for (int j = 1; j < 7; j++)
                {
                    _playerRoomMaterialService.Add(new PlayerRoomMaterialAddDto
                    {
                        PlayerRoomId = lastplayerRoomId,
                        RoomMaterialId = j,
                    });
                }
            }

            return new SuccessResult("Otel Oluşturuldu");
        }
    }
}
