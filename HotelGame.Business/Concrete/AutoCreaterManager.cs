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

        public IResult NewHotelCreater(int userId)
        {
            _playerHotelService.AddAsync(new PlayerHotelAddDto
            {
                UserId = userId,
                HotelLevel = 1,
                HotelMoney = 1500,
                HotelName = "Yeni Otelim",
                HotelTypeId= 1,
                CustomerCommentPointAvarage = 3,
                HotelQuality = 0
            });
            int lastHotelId = _playerHotelService.LastId();
            for (int i = 1; i < 5; i++)
            {
                _playerRoomService.AddAsync(new PlayerRoomAddDto
                {
                    PlayerHotelId = lastHotelId,
                    RoomTypeId = i,
                    Availability = true,
                    RoomDailyPrice = 25
                });
                int lastplayerRoomId = _playerRoomService.LastId();
                for (int j = 1; j < 6; j++)
                {
                    _playerRoomMaterialService.AddAsync(new PlayerRoomMaterialAddDto
                    {
                        PlayerRoomId = lastplayerRoomId,
                        RoomMaterialId = j,
                    });
                }
            }
            var roomMaterials = _roomMaterialService.GetAllAsync();
            var roomMaterialsQualityPoint = 0;
            foreach (var item in roomMaterials.Result.Data)
            {
                roomMaterialsQualityPoint = roomMaterialsQualityPoint + item.QualityPoint;

            }
            _playerHotelService.UpdateAsync(new PlayerHotelUpdateDto
            {

                HotelQuality = roomMaterialsQualityPoint,
            });

            return new SuccessResult("Otel Oluşturuldu");
        }

    }
}
