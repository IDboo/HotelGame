using HotelGame.Core.DataAccess.Abstract;
using HotelGame.Entities.Concrete;

namespace HotelGame.DataAccess.Abstract
{
    public interface IRMBathRoomDal : IEntityRepository<RMBathRoom>
    {
        public int GetMaksimumLevel();

    }

}
