using AutoMapper;
using HotelGame.Business.Abstract;
using HotelGame.Business.Constans;
using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Core.Utilities.Result.Concrete;
using HotelGame.DataAccess.Abstract;
using HotelGame.DataAccess.Concrete.EntityFramework.Repositories;
using HotelGame.Entities.Concrete;
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

        public PlayerRoomMaterialManager(IPlayerRoomMaterialDal playerRoomMaterialDal, IMapper mapper)
        {
            _playerRoomMaterialDal = playerRoomMaterialDal;
            _mapper = mapper;
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
    }
}
