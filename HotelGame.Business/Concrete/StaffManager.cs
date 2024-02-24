using AutoMapper;
using HotelGame.Business.Abstract;
using HotelGame.Business.Constans;
using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Core.Utilities.Result.Concrete;
using HotelGame.DataAccess.Abstract;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.Staffs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelGame.Business.Concrete
{
    public class StaffManager : IStaffService
    {
        private readonly IStaffDal _staffDal;
        private readonly IMapper _mapper;

        public StaffManager(IStaffDal staffDal, IMapper mapper)
        {
            _staffDal = staffDal;
            _mapper = mapper;
        }

        public async Task<IResult> AddAsync(StaffAddDto staffAddDto)
        {
            var staff = _mapper.Map<Staff>(staffAddDto);
            await _staffDal.AddAsync(staff);
            await _staffDal.SaveAsync();
            return new SuccessResult(Messages.StaffAdded);
        }

        public async Task<IResult> DeleteAsync(int Id)
        {
            var staff = await _staffDal.GetAsync(s => s.Id == Id);
            if (staff != null)
            {
                await _staffDal.DeleteAsync(staff);
                await _staffDal.SaveAsync();
                return new SuccessResult(Messages.StaffDeleted);
            }
            else
            {
                return new ErrorResult(Messages.StaffNotFound);
            }
        }

        public async Task<IDataResult<List<Staff>>> GetAllAsync()
        {
            var staffs = await _staffDal.GetAllAsync();
            if (staffs != null)
            {
                return new SuccessDataResult<List<Staff>>(staffs, Messages.StaffListed);
            }
            else
            {
                return new ErrorDataResult<List<Staff>>(null, Messages.StaffNotFound);
            }
        }

        public async Task<IDataResult<Staff>> GetByIdAsync(int Id)
        {
            var staff = await _staffDal.GetAsync(s => s.Id == Id);
            if (staff != null)
            {
                return new SuccessDataResult<Staff>(staff, Messages.StaffGeted);
            }
            else
            {
                return new ErrorDataResult<Staff>(null, Messages.StaffNotFound);
            }
        }

        public async Task<IResult> UpdateAsync(StaffUpdateDto staffUpdateDto)
        {
            var oldStaff = await _staffDal.GetAsync(s => s.Id == staffUpdateDto.Id);
            if (oldStaff != null)
            {
                var mappedStaff = _mapper.Map<StaffUpdateDto, Staff>(staffUpdateDto, oldStaff);
                var newStaff = await _staffDal.UpdateAsync(mappedStaff);
                await _staffDal.SaveAsync();
                return new SuccessDataResult<Staff>(newStaff, Messages.StaffUpdated);
            }
            else
            {
                return new ErrorDataResult<Staff>(null, Messages.StaffNotFound);
            }
        }
    }
}
