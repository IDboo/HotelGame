namespace HotelGame.Entities.DTOs.Staffs
{

    public class StaffUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Comment { get; set; }
        public int Wage { get; set; }
    }
}
