using HotelGame.Core.DataAccess.Concrete;
using HotelGame.DataAccess.Abstract;
using HotelGame.DataAccess.Concrete.EntitiyFramework;
using HotelGame.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HotelGame.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfRMTelevisionDal : BaseEntityRepository<RMTelevision>, IRMTelevisionDal
    {
        public EfRMTelevisionDal(DbContext context) : base(context)
        {
        }

        public int GetMaksimumLevel()
        {
            using (HotelGameContext context = new HotelGameContext())
            {
                var result = from q in context.RMTelevisions
                             orderby q.Level ascending
                             select q.Level;
                return result.Last();
            }
        }


    }
}
