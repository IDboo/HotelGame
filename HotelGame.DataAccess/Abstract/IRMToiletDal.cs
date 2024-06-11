using HotelGame.Core.DataAccess.Abstract;
using HotelGame.Entities.Concrete;

namespace HotelGame.DataAccess.Abstract
{
    public interface IRMToiletDal : IEntityRepository<RMToilet>
    {

        public int GetMaksimumLevel();
    }

}
