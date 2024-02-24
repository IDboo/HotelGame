using HotelGame.Core.Entities;
using System.Collections.Generic;

namespace HotelGame.Entities.Concrete
{
    public class Staff : BaseEntity<int>
    { 
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Comment { get; set; }
        public int Wage { get; set; }

        public List<PlayerHotelStaff> PlayerHotelStaff { get; set; }
    }

}
