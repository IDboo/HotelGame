using HotelGame.Core.DataAccess.Concrete;
using HotelGame.DataAccess.Abstract;
using HotelGame.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HotelGame.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfRMBedDal : BaseEntityRepository<RMBed>, IRMBedDal
    {
        public EfRMBedDal(DbContext context) : base(context)
        {
        }


    }
}
