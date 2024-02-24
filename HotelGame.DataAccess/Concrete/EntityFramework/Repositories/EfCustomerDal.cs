using HotelGame.Core.DataAccess.Concrete;
using HotelGame.DataAccess.Abstract;
using HotelGame.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HotelGame.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfCustomerDal : BaseEntityRepository<Customer>, ICustomerDal
    {
        public EfCustomerDal (DbContext context) : base(context)
        {
        }


    }
}
