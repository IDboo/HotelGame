using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.Core.Entities
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
        public DateTime CreatedTime{ get; set; } = DateTime.Now;
        public DateTime UpdatedTime { get; set;}
        public bool IsActive { get; set; } = true; 


    }
}
