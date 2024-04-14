using HotelGame.Core.DataAccess.Concrete;
using HotelGame.DataAccess.Abstract;
using HotelGame.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HotelGame.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfRMBathRoomDal : BaseEntityRepository<RMBathRoom>, IRMBathRoomDal
    {
        public EfRMBathRoomDal(DbContext context) : base(context)
        {
        }


    }
}
