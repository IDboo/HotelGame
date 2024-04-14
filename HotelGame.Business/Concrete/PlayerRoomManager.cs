using AutoMapper;
using HotelGame.Business.Abstract;
using HotelGame.Business.Constans;
using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Core.Utilities.Result.Concrete;
using HotelGame.DataAccess.Abstract;
using HotelGame.DataAccess.Concrete.EntityFramework.Repositories;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.PlayerRooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.Business.Concrete
{
    public class PlayerRoomManager : IPlayerRoomService
    {
        #region Injection

        private readonly IPlayerRoomDal _playerRoomDal;
        private readonly IMapper _mapper;

        public PlayerRoomManager(IPlayerRoomDal playerRoomDal, IMapper mapper)
        {
            _playerRoomDal = playerRoomDal;
            _mapper = mapper;
        }

        #endregion

        public async Task<IResult> AddAsync(PlayerRoomAddDto playerRoomAddDto)
        {
            var playerRoom = _mapper.Map<PlayerRoom>(playerRoomAddDto);
            await _playerRoomDal.AddAsync(playerRoom);
            await _playerRoomDal.SaveAsync();
            return new SuccessResult(Messages.PlayerRoomAdded);
        }

        public async Task<IResult> DeleteAsync(int Id)
        {
            var playerRoom = await _playerRoomDal.GetAsync(pr => pr.Id == Id );
            if (playerRoom != null)
            {
                await _playerRoomDal.DeleteAsync(playerRoom);
                await _playerRoomDal.SaveAsync();
                return new SuccessResult(Messages.PlayerRoomDeleted);
            }
            else
            {
                return new ErrorResult(Messages.PlayerRoomNotFound);
            }
        }

        public async Task<IDataResult<List<PlayerRoom>>> GetAllAsync()
        {
            var playerRooms = await _playerRoomDal.GetAllAsync();
            if (playerRooms != null)
            {
                return new SuccessDataResult<List<PlayerRoom>>(playerRooms, Messages.PlayerRoomListed);
            }
            else
            {
                return new ErrorDataResult<List<PlayerRoom>>(null, Messages.PlayerRoomNotFound);
            }
        }

        public async Task<IDataResult<PlayerRoom>> GetByIdAsync(int Id)
        {
            var playerRoom = await _playerRoomDal.GetAsync(pr => pr.Id == Id);
            if (playerRoom != null)
            {
                return new SuccessDataResult<PlayerRoom>(playerRoom, Messages.PlayerRoomGeted);
            }
            else
            {
                return new ErrorDataResult<PlayerRoom>(null, Messages.PlayerRoomNotFound);
            }
        }

        public async Task<IResult> UpdateAsync(PlayerRoomUpdateDto playerRoomUpdateDto)
        {
            var oldPlayerRoom = await _playerRoomDal.GetAsync(pr => pr.Id == playerRoomUpdateDto.Id);
            if (oldPlayerRoom != null)
            {
                var mappedPlayerRoom = _mapper.Map<PlayerRoomUpdateDto, PlayerRoom>(playerRoomUpdateDto, oldPlayerRoom);
                var newPlayerRoom = await _playerRoomDal.UpdateAsync(mappedPlayerRoom);
                await _playerRoomDal.SaveAsync();
                return new SuccessDataResult<PlayerRoom>(newPlayerRoom, Messages.PlayerRoomUpdated);
            }
            else
            {
                return new ErrorDataResult<PlayerRoom>(null, Messages.PlayerRoomNotFound);
            }
        }

        public int LastId()
        {
            return _playerRoomDal.GetLastId();
        }

        public IResult Add(PlayerRoomAddDto playerRoomAddDto)
        {
            var playerRoom = _mapper.Map<PlayerRoom>(playerRoomAddDto);
            _playerRoomDal.Add(playerRoom);
            _playerRoomDal.Save();
            return new SuccessResult(Messages.PlayerRoomAdded);
        }

        public async Task<IDataResult<List<PlayerRoom>>> GetAllByUserIdAsync(int playerHotelId)
        {
            var playerRooms = await _playerRoomDal.GetAllAsync(x => x.PlayerHotelId == playerHotelId);
            if (playerRooms != null)
            {
                return new SuccessDataResult<List<PlayerRoom>>(playerRooms);
            }
            else
            {
                return new ErrorDataResult<List<PlayerRoom>>(null , "Hata"); 
            }
        }
    }
}
