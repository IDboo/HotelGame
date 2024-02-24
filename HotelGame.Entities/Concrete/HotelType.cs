using HotelGame.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.Entities.Concrete
{
    public  class HotelType : BaseEntity<int>
    {
        public string Name { get; set; }
        public List<PlayerHotel> PlayerHotels { get; set; }

    }

}
