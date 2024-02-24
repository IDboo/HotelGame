using AutoMapper;
using HotelGame.Business.Abstract;
using HotelGame.Business.Constans;
using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Core.Utilities.Result.Concrete;
using HotelGame.DataAccess.Abstract;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.PlayerHotelPositions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.Business.Concrete
{
    public class PlayerHotelPositionManager : IPlayerHotelPositionService
    {
        #region Injection

        private readonly IPlayerHotelPositionDal _playerHotelPositionDal;
        private readonly IMapper _mapper;

        public PlayerHotelPositionManager(IPlayerHotelPositionDal playerHotelPositionDal, IMapper mapper)
        {
            _playerHotelPositionDal = playerHotelPositionDal;
            _mapper = mapper;
        }

        #endregion

        public async Task<IResult> AddAsync(PlayerHotelPositionAddDto playerHotelPositionAddDto)
        {
            var playerHotelPosition = _mapper.Map<PlayerHotelPosition>(playerHotelPositionAddDto);
            await _playerHotelPositionDal.AddAsync(playerHotelPosition);
            await _playerHotelPositionDal.SaveAsync();
            return new SuccessResult(Messages.PlayerHotelPositionAdded);
        }

        public async Task<IResult> DeleteAsync(int Id)
        {
            var playerHotelPosition = await _playerHotelPositionDal.GetAsync(php => php.PlayerHotelId == Id);
            if (playerHotelPosition != null)
            {
                await _playerHotelPositionDal.DeleteAsync(playerHotelPosition);
                await _playerHotelPositionDal.SaveAsync();
                return new SuccessResult(Messages.PlayerHotelPositionDeleted);
            }
            else
            {
                return new ErrorResult(Messages.PlayerHotelPositionNotFound);
            }
        }

        public async Task<IDataResult<List<PlayerHotelPosition>>> GetAllAsync()
        {
            var playerHotelPositions = await _playerHotelPositionDal.GetAllAsync();
            if (playerHotelPositions != null)
            {
                return new SuccessDataResult<List<PlayerHotelPosition>>(playerHotelPositions, Messages.PlayerHotelPositionListed);
            }
            else
            {
                return new ErrorDataResult<List<PlayerHotelPosition>>(null, Messages.PlayerHotelPositionNotFound);
            }
        }

        public async Task<IDataResult<PlayerHotelPosition>> GetByIdAsync(int Id)
        {
            var playerHotelPosition = await _playerHotelPositionDal.GetAsync(php => php.PlayerHotelId == Id);
            if (playerHotelPosition != null)
            {
                return new SuccessDataResult<PlayerHotelPosition>(playerHotelPosition, Messages.PlayerHotelPositionGeted);
            }
            else
            {
                return new ErrorDataResult<PlayerHotelPosition>(null, Messages.PlayerHotelPositionNotFound);
            }
        }

        public async Task<IResult> UpdateAsync(PlayerHotelPositionUpdateDto playerHotelPositionUpdateDto)
        {
            var oldPlayerHotelPosition = await _playerHotelPositionDal.GetAsync(php => php.Id == playerHotelPositionUpdateDto.Id);
            if (oldPlayerHotelPosition != null)
            {
                var mappedPlayerHotelPosition = _mapper.Map<PlayerHotelPositionUpdateDto, PlayerHotelPosition>(playerHotelPositionUpdateDto, oldPlayerHotelPosition);
                var newPlayerHotelPosition = await _playerHotelPositionDal.UpdateAsync(mappedPlayerHotelPosition);
                await _playerHotelPositionDal.SaveAsync();
                return new SuccessDataResult<PlayerHotelPosition>(newPlayerHotelPosition, Messages.PlayerHotelPositionUpdated);
            }
            else
            {
                return new ErrorDataResult<PlayerHotelPosition>(null, Messages.PlayerHotelPositionNotFound);
            }
        }
    }
}
