using AutoMapper;
using HotelGame.Business.Abstract;
using HotelGame.Business.Constans;
using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Core.Utilities.Result.Concrete;
using HotelGame.DataAccess.Abstract;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.PlayerHotelStaffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.Business.Concrete
{
    public class PlayerHotelStaffManager : IPlayerHotelStaffService
    {

        #region Injection

        private readonly IPlayerHotelStaffDal _playerHotelStaffDal;
        private readonly IMapper _mapper;

        public PlayerHotelStaffManager(IPlayerHotelStaffDal playerHotelStaffDal, IMapper mapper)
        {
            _playerHotelStaffDal = playerHotelStaffDal;
            _mapper = mapper;
        }

        #endregion



        public async Task<IResult> AddAsync(PlayerHotelStaffAddDto playerHotelStaffAddDto)
        {
            var playerHotelStaff = _mapper.Map<PlayerHotelStaff>(playerHotelStaffAddDto);
            await _playerHotelStaffDal.AddAsync(playerHotelStaff);
            await _playerHotelStaffDal.SaveAsync();
            return new SuccessResult(Messages.PlayerHotelStaffAdded);

        }

        public async Task<IResult> DeleteAsync(int Id)
        {
            var playerHotelStaff = await _playerHotelStaffDal.GetAsync(x => x.Id == Id);
            if (playerHotelStaff != null)
            {
                await _playerHotelStaffDal.UpdateAsync(playerHotelStaff);
                await _playerHotelStaffDal.SaveAsync();
                return new SuccessResult(Messages.PlayerHotelStaffUpdated);
            }
            else
            {
                return new ErrorResult(Messages.PlayerHotelStaffNotFound);
            }
        }

        public async Task<IDataResult<List<PlayerHotelStaff>>> GetAllAsync()
        {
            var playerHotelStaffs = await _playerHotelStaffDal.GetAllAsync();
            if (playerHotelStaffs != null)
            {
                return new SuccessDataResult<List<PlayerHotelStaff>>(playerHotelStaffs , Messages.PlayerHotelStaffListed);
            }
            else
            {
                return new ErrorDataResult<List<PlayerHotelStaff>>(null , Messages.PlayerHotelStaffNotFound);
            }
        }

        public async Task<IDataResult<PlayerHotelStaff>> GetByIdAsync(int Id)
        {
            var playerHotelStaff = await _playerHotelStaffDal.GetAsync(x => x.Id == Id);
            if (playerHotelStaff != null)
            {
                return new SuccessDataResult<PlayerHotelStaff>(playerHotelStaff , Messages.PlayerHotelStaffGeted);
            }
            else
            {
                return new ErrorDataResult<PlayerHotelStaff>(null , Messages.PlayerHotelStaffNotFound);
            }
        }

        public async Task<IResult> UpdateAsync(PlayerHotelStaffUpdateDto playerHotelStaffUpdateDto)
        {
            var oldPlayerHotelStaff = await _playerHotelStaffDal.GetAsync(x => x.Id == playerHotelStaffUpdateDto.Id);

            if (oldPlayerHotelStaff != null)
            {
                var mappedPlayerHotelStaff = _mapper.Map<PlayerHotelStaffUpdateDto, PlayerHotelStaff>(playerHotelStaffUpdateDto , oldPlayerHotelStaff);
                var updatedPlayerHotelStaff = await _playerHotelStaffDal.UpdateAsync(mappedPlayerHotelStaff);
                await _playerHotelStaffDal.SaveAsync();
                return new SuccessDataResult<PlayerHotelStaff>(updatedPlayerHotelStaff , Messages.PlayerHotelStaffUpdated);
            }
            else
            {
                return new ErrorResult(Messages.PlayerHotelStaffNotFound);
            }
        }
    }
}
