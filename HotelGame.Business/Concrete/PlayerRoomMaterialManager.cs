using AutoMapper;
using HotelGame.Business.Abstract;
using HotelGame.Business.Constans;
using HotelGame.Core.Utilities.Business;
using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Core.Utilities.Result.Concrete;
using HotelGame.DataAccess.Abstract;
using HotelGame.DataAccess.Concrete.EntityFramework.Repositories;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.PlayerRoomMaterial;
using HotelGame.Entities.DTOs.PlayerRoomMaterials;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace HotelGame.Business.Concrete
{
    public class PlayerRoomMaterialManager : IPlayerRoomMaterialService
    {
        #region Injection

        private readonly IPlayerRoomMaterialDal _playerRoomMaterialDal;
        private readonly IMapper _mapper;
        private readonly IRMTelevisionService _rMTelevisionService;
        private readonly IRMAirConditionService _rMAirConditionService;
        private readonly IRMBedService _rMBedService;
        private readonly IRMBathRoomService _rMBathRoomService;
        private readonly IRMToiletService _rMToiletService;
        private readonly IRMCarpetService _rMCarpetService;

        public PlayerRoomMaterialManager(
            IPlayerRoomMaterialDal playerRoomMaterialDal,
            IMapper mapper,
            IRMTelevisionService rMTelevisionService,
            IRMAirConditionService rMAirConditionService,
            IRMBedService rMBedService,
            IRMBathRoomService rMBathRoomService,
            IRMToiletService rMToiletService,
            IRMCarpetService rMCarpetService)
        {
            _playerRoomMaterialDal = playerRoomMaterialDal;
            _mapper = mapper;
            _rMTelevisionService = rMTelevisionService;
            _rMAirConditionService = rMAirConditionService;
            _rMBedService = rMBedService;
            _rMBathRoomService = rMBathRoomService;
            _rMToiletService = rMToiletService;
            _rMCarpetService = rMCarpetService;
        }

        #endregion

        public async Task<IResult> AddAsync(PlayerRoomMaterialAddDto playerRoomMaterialAddDto)
        {
            var playerRoomMaterial = _mapper.Map<PlayerRoomMaterial>(playerRoomMaterialAddDto);
            await _playerRoomMaterialDal.AddAsync(playerRoomMaterial);
            await _playerRoomMaterialDal.SaveAsync();
            return new SuccessResult(Messages.PlayerRoomMaterialAdded);
        }

        public async Task<IResult> DeleteAsync(int playerRoomMaterialId)
        {
            var playerRoomMaterial = await _playerRoomMaterialDal.GetAsync(prm => prm.Id == playerRoomMaterialId);
            if (playerRoomMaterial != null)
            {
                await _playerRoomMaterialDal.DeleteAsync(playerRoomMaterial);
                await _playerRoomMaterialDal.SaveAsync();
                return new SuccessResult(Messages.PlayerRoomMaterialDeleted);
            }
            else
            {
                return new ErrorResult(Messages.PlayerRoomMaterialNotFound);
            }
        }

        public async Task<IDataResult<List<PlayerRoomMaterial>>> GetAllAsync()
        {
            var playerRoomMaterials = await _playerRoomMaterialDal.GetAllAsync();
            if (playerRoomMaterials != null)
            {
                return new SuccessDataResult<List<PlayerRoomMaterial>>(playerRoomMaterials, Messages.PlayerRoomMaterialListed);
            }
            else
            {
                return new ErrorDataResult<List<PlayerRoomMaterial>>(null, Messages.PlayerRoomMaterialNotFound);
            }
        }

        public async Task<IDataResult<PlayerRoomMaterial>> GetByIdAsync(int playerRoomMaterialId)
        {
            var playerRoomMaterial = await _playerRoomMaterialDal.GetAsync(prm => prm.Id == playerRoomMaterialId);
            if (playerRoomMaterial != null)
            {
                return new SuccessDataResult<PlayerRoomMaterial>(playerRoomMaterial, Messages.PlayerRoomMaterialGeted);
            }
            else
            {
                return new ErrorDataResult<PlayerRoomMaterial>(null, Messages.PlayerRoomMaterialNotFound);
            }
        }

        public async Task<IResult> UpdateAsync(PlayerRoomMaterialUpdateDto playerRoomMaterialUpdateDto)
        {
            var oldPlayerRoomMaterial = await _playerRoomMaterialDal.GetAsync(prm => prm.Id == playerRoomMaterialUpdateDto.Id);
            if (oldPlayerRoomMaterial != null)
            {
                var mappedPlayerRoomMaterial = _mapper.Map<PlayerRoomMaterialUpdateDto, PlayerRoomMaterial>(playerRoomMaterialUpdateDto, oldPlayerRoomMaterial);
                var newPlayerRoomMaterial = await _playerRoomMaterialDal.UpdateAsync(mappedPlayerRoomMaterial);
                await _playerRoomMaterialDal.SaveAsync();
                return new SuccessDataResult<PlayerRoomMaterial>(newPlayerRoomMaterial, Messages.PlayerRoomMaterialUpdated);
            }
            else
            {
                return new ErrorDataResult<PlayerRoomMaterial>(null, Messages.PlayerRoomMaterialNotFound);
            }
        }

        public int LastId()
        {
            return _playerRoomMaterialDal.GetLastId();
        }

        public IResult Add(PlayerRoomMaterialAddDto playerRoomMaterialAddDto)
        {
            var playerRoomMaterial = _mapper.Map<PlayerRoomMaterial>(playerRoomMaterialAddDto);
            _playerRoomMaterialDal.Add(playerRoomMaterial);
            _playerRoomMaterialDal.Save();
            return new SuccessResult(Messages.PlayerRoomMaterialAdded);
        }

        public async Task<IDataResult<List<PlayerRoomMaterial>>> GetAllByPlayerRoomIdAsync(int playerRoomId)
        {
            var playerRoomMaterial = await _playerRoomMaterialDal.GetAllAsync(x => x.PlayerRoomId == playerRoomId);
            if (playerRoomMaterial != null)
            {
                // Loglama ekle
                using (StreamWriter writer = new StreamWriter("log.txt", true))
                {
                    writer.WriteLine($"GetAllByPlayerRoomIdAsync - PlayerRoomId: {playerRoomId}, Count: {playerRoomMaterial.Count}");
                }
                return new SuccessDataResult<List<PlayerRoomMaterial>>(playerRoomMaterial);
            }
            else
            {
                return new ErrorDataResult<List<PlayerRoomMaterial>>(null, "Hata");
            }
        }

        public async Task<IDataResult<PlayerRoomMaterial>> GetUpperLevelMaterial(int playerRoomId)
        {
            var defaultRoomMaterials = await GetAllByPlayerRoomIdAsync(playerRoomId);
            var upperLevelMaterials = new PlayerRoomMaterial();

            using (StreamWriter writer = new StreamWriter("log.txt", true))
            {
                writer.WriteLine($"GetUpperLevelMaterial - defaultRoomMaterials.Count: {defaultRoomMaterials.Data?.Count}");
            }

            if (defaultRoomMaterials.Data == null || defaultRoomMaterials.Data.Count == 0)
            {
                using (StreamWriter writer = new StreamWriter("log.txt", true))
                {
                    writer.WriteLine($"GetUpperLevelMaterial - defaultRoomMaterials.Data is null or empty");
                }
                return new ErrorDataResult<PlayerRoomMaterial>("Default room materials not found");
            }

            foreach (var roomMaterial in defaultRoomMaterials.Data)
            {
                using (StreamWriter writer = new StreamWriter("log.txt", true))
                {
                    writer.WriteLine($"Checking Material - RoomMaterialId: {roomMaterial.Id}, RMTelevisionId: {roomMaterial.RMTelevisionId}, RMAirConditionId: {roomMaterial.RMAirConditionId}, RMBedId: {roomMaterial.RMBedId}, RMBathRoomId: {roomMaterial.RMBathRoomId}, RMToiletId: {roomMaterial.RMToiletId}, RMCarpetId: {roomMaterial.RMCarpetId}");
                }

                if (roomMaterial.RMTelevisionId != 0)
                {
                    var checkRMTelevisionId = await _rMTelevisionService.GetByIdAsync(roomMaterial.RMTelevisionId);
                    if (checkRMTelevisionId.Data != null)
                    {
                        var checkRMTelevisonLevel = await _rMTelevisionService.GetByLevelAsync(checkRMTelevisionId.Data.Level);
                        if (checkRMTelevisonLevel.Data != null)
                        {
                            var upperTelevisionLevel = checkRMTelevisonLevel.Data.Level + 1;
                            var checkUpperLevelTelevision = await _rMTelevisionService.GetByLevelAsync(upperTelevisionLevel);
                            if (checkUpperLevelTelevision.Data != null)
                            {
                                upperLevelMaterials.RMTelevisionId = checkUpperLevelTelevision.Data.Id;
                                upperLevelMaterials.RMTelevision = checkUpperLevelTelevision.Data;  // İlişkiyi ekliyoruz
                            }
                        }
                    }
                }

                if (roomMaterial.RMAirConditionId != 0)
                {
                    var checkRMAirConditionId = await _rMAirConditionService.GetByIdAsync(roomMaterial.RMAirConditionId);
                    if (checkRMAirConditionId.Data != null)
                    {
                        var checkRMAirConditionLevel = await _rMAirConditionService.GetByLevelAsync(checkRMAirConditionId.Data.Level);
                        if (checkRMAirConditionLevel.Data != null)
                        {
                            var upperAirConditionLevel = checkRMAirConditionLevel.Data.Level + 1;
                            var checkUpperLevelAirCondition = await _rMAirConditionService.GetByLevelAsync(upperAirConditionLevel);
                            if (checkUpperLevelAirCondition.Data != null)
                            {
                                upperLevelMaterials.RMAirConditionId = checkUpperLevelAirCondition.Data.Id;
                                upperLevelMaterials.RMAirCondition = checkUpperLevelAirCondition.Data;  // İlişkiyi ekliyoruz
                            }
                        }
                    }
                }

                if (roomMaterial.RMBedId != 0)
                {
                    var checkRMBedId = await _rMBedService.GetByIdAsync(roomMaterial.RMBedId);
                    if (checkRMBedId.Data != null)
                    {
                        var checkRMBedLevel = await _rMBedService.GetByLevelAsync(checkRMBedId.Data.Level);
                        if (checkRMBedLevel.Data != null)
                        {
                            var upperBedLevel = checkRMBedLevel.Data.Level + 1;
                            var checkUpperLevelBed = await _rMBedService.GetByLevelAsync(upperBedLevel);
                            if (checkUpperLevelBed.Data != null)
                            {
                                upperLevelMaterials.RMBedId = checkUpperLevelBed.Data.Id;
                                upperLevelMaterials.RMBed = checkUpperLevelBed.Data;  // İlişkiyi ekliyoruz
                            }
                        }
                    }
                }

                if (roomMaterial.RMBathRoomId != 0)
                {
                    var checkRMBathRoomId = await _rMBathRoomService.GetByIdAsync(roomMaterial.RMBathRoomId);
                    if (checkRMBathRoomId.Data != null)
                    {
                        var checkRMBathRoomLevel = await _rMBathRoomService.GetByLevelAsync(checkRMBathRoomId.Data.Level);
                        if (checkRMBathRoomLevel.Data != null)
                        {
                            var upperBathRoomLevel = checkRMBathRoomLevel.Data.Level + 1;
                            var checkUpperLevelBathRoom = await _rMBathRoomService.GetByLevelAsync(upperBathRoomLevel);
                            if (checkUpperLevelBathRoom.Data != null)
                            {
                                upperLevelMaterials.RMBathRoomId = checkUpperLevelBathRoom.Data.Id;
                                upperLevelMaterials.RMBathRoom = checkUpperLevelBathRoom.Data;  // İlişkiyi ekliyoruz
                            }
                        }
                    }
                }

                if (roomMaterial.RMToiletId != 0)
                {
                    var checkRMToiletId = await _rMToiletService.GetByIdAsync(roomMaterial.RMToiletId);
                    if (checkRMToiletId.Data != null)
                    {
                        var checkRMToiletLevel = await _rMToiletService.GetByLevelAsync(checkRMToiletId.Data.Level);
                        if (checkRMToiletLevel.Data != null)
                        {
                            var upperToiletLevel = checkRMToiletLevel.Data.Level + 1;
                            var checkUpperLevelToilet = await _rMToiletService.GetByLevelAsync(upperToiletLevel);
                            if (checkUpperLevelToilet.Data != null)
                            {
                                upperLevelMaterials.RMToiletId = checkUpperLevelToilet.Data.Id;
                                upperLevelMaterials.RMToilet = checkUpperLevelToilet.Data;  // İlişkiyi ekliyoruz
                            }
                        }
                    }
                }

                if (roomMaterial.RMCarpetId != 0)
                {
                    var checkRMCarpetId = await _rMCarpetService.GetByIdAsync(roomMaterial.RMCarpetId);
                    if (checkRMCarpetId.Data != null)
                    {
                        var checkRMCarpetLevel = await _rMCarpetService.GetByLevelAsync(checkRMCarpetId.Data.Level);
                        if (checkRMCarpetLevel.Data != null)
                        {
                            var upperCarpetLevel = checkRMCarpetLevel.Data.Level + 1;
                            var checkUpperLevelCarpet = await _rMCarpetService.GetByLevelAsync(upperCarpetLevel);
                            if (checkUpperLevelCarpet.Data != null)
                            {
                                upperLevelMaterials.RMCarpetId = checkUpperLevelCarpet.Data.Id;
                                upperLevelMaterials.RMCarpet = checkUpperLevelCarpet.Data;  // İlişkiyi ekliyoruz
                            }
                        }
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter("log.txt", true))
            {
                writer.WriteLine($"GetUpperLevelMaterial - upperLevelMaterials: RMTelevisionId={upperLevelMaterials.RMTelevisionId}, RMAirConditionId={upperLevelMaterials.RMAirConditionId}, RMBedId={upperLevelMaterials.RMBedId}, RMBathRoomId={upperLevelMaterials.RMBathRoomId}, RMToiletId={upperLevelMaterials.RMToiletId}, RMCarpetId={upperLevelMaterials.RMCarpetId}");
            }

            return new SuccessDataResult<PlayerRoomMaterial>(upperLevelMaterials);
        }
    }
}
