using HotelGame.Core.DataAccess.Concrete;
using HotelGame.DataAccess.Abstract;
using HotelGame.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HotelGame.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfRMAirConditionDal : BaseEntityRepository<RMAirCondition>, IRMAirConditionDal
    {
        public EfRMAirConditionDal(DbContext context) : base(context)
        {
        }


    }
}
