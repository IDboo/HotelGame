namespace HotelGame.WebMVC.Models.Users
{
    public class UserUpdateViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string[] Roles { get; set; }
    }
}
