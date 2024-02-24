using HotelGame.Core.Entities;
using System.Collections.Generic;

namespace HotelGame.Entities.Concrete
{
    public class HotelPosition : BaseEntity<int>
    {
        public string Name { get; set; }
        public List<PlayerHotelPosition> PlayerHotelPositions { get; set; }

    }

}
