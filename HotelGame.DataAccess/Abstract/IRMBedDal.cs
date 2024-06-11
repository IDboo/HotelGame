using HotelGame.Core.DataAccess.Abstract;
using HotelGame.Entities.Concrete;

namespace HotelGame.DataAccess.Abstract
{
    public interface IRMBedDal : IEntityRepository<RMBed>
    {

        public int GetMaksimumLevel();
    }

}
