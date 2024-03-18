using HotelGame.Entities.Concrete;
using System.Collections.Generic;

namespace HotelGame.WebMVC.Models.HotelTypes
{
    public class GetAllHotelTypesViewModel : BaseViewModel
    {
        public List<HotelType> HotelTypes { get; set; }

        public HotelTypeAddViewModel hotelTypeAddView { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }


    }
}
