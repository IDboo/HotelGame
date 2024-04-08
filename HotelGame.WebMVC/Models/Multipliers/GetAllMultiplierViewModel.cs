using HotelGame.Entities.Concrete;
using System.Collections.Generic;

namespace HotelGame.WebMVC.Models.Multipliers
{
    public class GetAllMultiplierViewModel : BaseViewModel
    {
        public List<Multiplier> Multipliers { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Coefficient { get; set; }
    }
}
