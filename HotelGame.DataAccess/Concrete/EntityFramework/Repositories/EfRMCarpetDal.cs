using HotelGame.Core.DataAccess.Concrete;
using HotelGame.DataAccess.Abstract;
using HotelGame.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HotelGame.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfRMCarpetDal : BaseEntityRepository<RMCarpet>, IRMCarpetDal
    {
        public EfRMCarpetDal(DbContext context) : base(context)
        {
        }


    }
}
