using AutoMapper;
using HotelGame.Business.Abstract;
using HotelGame.Core.Utilities.Result.Abstract;
using HotelGame.Core.Utilities.Result.Concrete;
using HotelGame.DataAccess.Abstract;
using HotelGame.Entities.Concrete;
using HotelGame.Entities.DTOs.RoomMaterial;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelGame.Business.Concrete
{
    public class RMToiletManager : IRMToiletService
    {
        #region Injection

        private readonly IRMToiletDal _rMToiletDal;
        private readonly IMapper _mapper;

        public RMToiletManager(IRMToiletDal rMToiletDal, IMapper mapper)
        {
            _rMToiletDal = rMToiletDal;
            _mapper = mapper;
        }

        #endregion

        public async Task<IResult> AddAsync(RMToiletAddDto rMToiletAddDto)
        {
            var rMToilet = _mapper.Map<RMToilet>(rMToiletAddDto);
            await _rMToiletDal.AddAsync(rMToilet);
            await _rMToiletDal.SaveAsync();
            return new SuccessResult("Eklendi");
        }

        public async Task<IResult> DeleteAsync(int Id)
        {
            var rMToilet = await _rMToiletDal.GetAsync(rm => rm.Id == Id);
            if (rMToilet != null)
            {
                await _rMToiletDal.DeleteAsync(rMToilet);
                await _rMToiletDal.SaveAsync();
                return new SuccessResult("Silindi");
            }
            else
            {
                return new ErrorResult("Bulunamadı");
            }
        }

        public async Task<IDataResult<List<RMToilet>>> GetAllAsync()
        {
            var rMToilets = await _rMToiletDal.GetAllAsync();
            if (rMToilets != null)
            {
                return new SuccessDataResult<List<RMToilet>>(rMToilets, "Getirildi");
            }
            else
            {
                return new ErrorDataResult<List<RMToilet>>(null, "Bulunamadı");
            }
        }

        public async Task<IDataResult<RMToilet>> GetByIdAsync(int Id)
        {
            var rMToilet = await _rMToiletDal.GetAsync(rm => rm.Id == Id);
            if (rMToilet != null)
            {
                return new SuccessDataResult<RMToilet>(rMToilet, "Getirildi");
            }
            else
            {
                return new ErrorDataResult<RMToilet>(null, "Bulunamdı");
            }
        }

        public async Task<IDataResult<RMToilet>> GetByLevelAsync(int level)
        {
            var rMToilet = await _rMToiletDal.GetAsync(x => x.Level == level);
            if (rMToilet != null)
            {
                return new SuccessDataResult<RMToilet>(rMToilet);
            }
            else
            {
                return new ErrorDataResult<RMToilet>(null, "Hata");
            }
        }

        public async Task<IResult> UpdateAsync(RMToiletUpdateDto rMToiletUpdateDto)
        {
            var oldRMToilet = await _rMToiletDal.GetAsync(rm => rm.Id == rMToiletUpdateDto.Id);
            if (oldRMToilet != null)
            {
                var mappedRMToilet = _mapper.Map<RMToiletUpdateDto, RMToilet>(rMToiletUpdateDto, oldRMToilet);
                var newRMToilet = await _rMToiletDal.UpdateAsync(mappedRMToilet);
                await _rMToiletDal.SaveAsync();
                return new SuccessDataResult<RMToilet>(newRMToilet, "Güncellendi");
            }
            else
            {
                return new ErrorDataResult<RMToilet>(null, "Bulunamadı");
            }
        }
    }
}
