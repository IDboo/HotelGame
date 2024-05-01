﻿using AutoMapper;
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
using System.Threading.Tasks;

namespace HotelGame.Business.Concrete
{
    public class PlayerRoomMaterialManager : IPlayerRoomMaterialService
    {
        #region Injection

        private readonly IPlayerRoomMaterialDal _playerRoomMaterialDal;
        private readonly IMapper _mapper;
        private readonly IRMTelevisionService _rMTelevisionService;

        public PlayerRoomMaterialManager(IPlayerRoomMaterialDal playerRoomMaterialDal, IMapper mapper, IRMTelevisionService rMTelevisionService)
        {
            _playerRoomMaterialDal = playerRoomMaterialDal;
            _mapper = mapper;
            _rMTelevisionService = rMTelevisionService;
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

            foreach (var roomMaterial in defaultRoomMaterials.Data)
            {
                var checkRMTelevisionId = await _rMTelevisionService.GetByIdAsync(roomMaterial.RMTelevisionId);

                var checkRMTelevisonLevel = await _rMTelevisionService.GetByLevelAsync(checkRMTelevisionId.Data.Level);

                var upperTelevisionLevel = checkRMTelevisonLevel.Data.Level + 1;

                var checkUpperLevelTelevision = await _rMTelevisionService.GetByLevelAsync(upperTelevisionLevel);

                var upperLevelMaterials = new PlayerRoomMaterial
                {
                    RMTelevisionId = checkUpperLevelTelevision.Data.Id,
                };
                return new SuccessDataResult<PlayerRoomMaterial>(upperLevelMaterials);
            }
            return new ErrorDataResult<PlayerRoomMaterial>(null, "Hata");

        }




    }





}
