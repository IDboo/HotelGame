using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.Entities.DTOs.Multipliers
{
    public class MultiplierUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Coefficient { get; set; }
    }
}
