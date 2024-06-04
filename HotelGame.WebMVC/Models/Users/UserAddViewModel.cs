namespace HotelGame.WebMVC.Models.Users
{
    public class UserAddViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string[] Roles { get; set; }

    }
}
