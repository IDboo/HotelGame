using HotelGame.Core.DataAccess.Abstract;
using HotelGame.Entities.Concrete;

namespace HotelGame.DataAccess.Abstract
{
    public interface IRMAirConditionDal : IEntityRepository<RMAirCondition>
    {

        public int GetMaksimumLevel();
    }

}
