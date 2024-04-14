using AutoMapper;
using HotelGame.Business.Abstract;
using HotelGame.Business.Constans;
using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Core.Utilities.Result.Concrete;
using HotelGame.DataAccess.Abstract;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.PlayerHotels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelGame.Business.Concrete
{
    public class PlayerHotelManager : IPlayerHotelService
    {
        #region Injection

        private readonly IPlayerHotelDal _playerHotelDal;
        private readonly IMapper _mapper;

        public PlayerHotelManager(IPlayerHotelDal playerHotelDal, IMapper mapper)
        {
            _playerHotelDal = playerHotelDal;
            _mapper = mapper;
        }

        #endregion

        public async Task<IResult> AddAsync(PlayerHotelAddDto playerHotelAddDto)
        {
            var playerHotel = _mapper.Map<PlayerHotel>(playerHotelAddDto);
            await _playerHotelDal.AddAsync(playerHotel);
            await _playerHotelDal.SaveAsync();
            return new SuccessResult(Messages.PlayerHotelAdded);
        }

        public async Task<IResult> DeleteAsync(int Id)
        {
            var playerHotel = await _playerHotelDal.GetAsync(h => h.Id == Id);
            if (playerHotel != null)
            {
                await _playerHotelDal.DeleteAsync(playerHotel);
                await _playerHotelDal.SaveAsync();
                return new SuccessResult(Messages.PlayerHotelDeleted);
            }
            else
            {
                return new ErrorResult(Messages.PlayerHotelNotFound);
            }
        }

        public async Task<IDataResult<List<PlayerHotel>>> GetAllAsync()
        {
            var playerHotels = await _playerHotelDal.GetAllAsync();
            if (playerHotels != null)
            {
                return new SuccessDataResult<List<PlayerHotel>>(playerHotels, Messages.PlayerHotelListed);
            }
            else
            {
                return new ErrorDataResult<List<PlayerHotel>>(null, Messages.PlayerHotelNotFound);
            }
        }

        public async Task<IDataResult<PlayerHotel>> GetByIdAsync(int Id)
        {
            var playerHotel = await _playerHotelDal.GetAsync(ph => ph.Id == Id);
            if (playerHotel != null)
            {
                return new SuccessDataResult<PlayerHotel>(playerHotel, Messages.PlayerHotelGeted);
            }
            else
            {
                return new ErrorDataResult<PlayerHotel>(null, Messages.PlayerHotelNotFound);
            }
        }

        public async Task<IResult> UpdateAsync(PlayerHotelUpdateDto playerHotelUpdateDto)
        {
            var oldPlayerHotel = await _playerHotelDal.GetAsync(ph => ph.Id == playerHotelUpdateDto.Id);
            if (oldPlayerHotel != null)
            {
                var mappedPlayerHotel = _mapper.Map<PlayerHotelUpdateDto, PlayerHotel>(playerHotelUpdateDto, oldPlayerHotel);
                var newPlayerHotel = await _playerHotelDal.UpdateAsync(mappedPlayerHotel);
                await _playerHotelDal.SaveAsync();
                return new SuccessDataResult<PlayerHotel>(newPlayerHotel, Messages.PlayerHotelUpdated);
            }
            else
            {
                return new ErrorDataResult<PlayerHotel>(null, Messages.PlayerHotelNotFound);
            }
        }

        public int LastId()
        {
            return _playerHotelDal.GetLastId();
        }

        public IResult Add(PlayerHotelAddDto playerHotelAddDto)
        {
            var playerHotel = _mapper.Map<PlayerHotel>(playerHotelAddDto);
            _playerHotelDal.Add(playerHotel);
            _playerHotelDal.Save();
            return new SuccessResult(Messages.PlayerHotelAdded);
        }

        public async Task<IDataResult<PlayerHotel>> CheckPlayerHotel(int userId)
        {
            var checkPlayerHotel = await _playerHotelDal.GetAsync(x => x.UserId == userId);
            if (checkPlayerHotel != null)
            {
                return new SuccessDataResult<PlayerHotel>(checkPlayerHotel);
            }
            else
            {
                return new ErrorDataResult<PlayerHotel>(null, "Bulunamadı");
            }
        }
    }
}
