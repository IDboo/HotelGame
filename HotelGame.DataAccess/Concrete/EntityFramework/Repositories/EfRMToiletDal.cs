using HotelGame.Core.DataAccess.Concrete;
using HotelGame.DataAccess.Abstract;
using HotelGame.DataAccess.Concrete.EntitiyFramework;
using HotelGame.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HotelGame.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfRMToiletDal : BaseEntityRepository<RMToilet>, IRMToiletDal
    {
        public EfRMToiletDal(DbContext context) : base(context)
        {
        }

        public int GetMaksimumLevel()
        {
            using (HotelGameContext context = new HotelGameContext())
            {
                var result = from q in context.RMToilets
                             orderby q.Level ascending
                             select q.Level;
                return result.Last();
            }
        }

    }
}
