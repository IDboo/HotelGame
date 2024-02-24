﻿using HotelGame.Core.DataAccess.Concrete;
using HotelGame.DataAccess.Abstract;
using HotelGame.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfHotelPositionDal : BaseEntityRepository<HotelPosition>, IHotelPositionDal
    {
        public EfHotelPositionDal(DbContext context) : base(context)
        {
        }


    }
}
