using HotelGame.Core.DataAccess.Concrete;
using HotelGame.DataAccess.Abstract;
using HotelGame.DataAccess.Concrete.EntitiyFramework;
using HotelGame.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfPlayerRoomMaterialDal : BaseEntityRepository<PlayerRoomMaterial>, IPlayerRoomMaterialDal
    {
        public EfPlayerRoomMaterialDal(DbContext context) : base(context)
        {
        }

        public int GetLastId()
        {
            using (HotelGameContext context = new HotelGameContext())
            {
                var result = from q in context.PlayerRoomMaterials
                             orderby q.Id ascending
                             select q.Id;
                return result.Last();
            }
        }

    }
}
