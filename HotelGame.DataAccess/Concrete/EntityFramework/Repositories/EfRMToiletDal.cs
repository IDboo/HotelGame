using HotelGame.Core.DataAccess.Concrete;
using HotelGame.DataAccess.Abstract;
using HotelGame.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HotelGame.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfRMToiletDal : BaseEntityRepository<RMToilet>, IRMToiletDal
    {
        public EfRMToiletDal(DbContext context) : base(context)
        {
        }


    }
}
