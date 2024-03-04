using System.ComponentModel.DataAnnotations;

namespace HotelGame.WebMVC.Models.Account
{
    public class SignUpAdminViewModel : BaseViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "E posta adresini yazınız")]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "İsminizi yazınız")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyisminizi yazınız")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Şifrenizi Yazınız")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifreler aynı olmalıdır")]
        public string ConfirmPassword { get; set; }



        public string ComfirmationCode { get; set; }




    }
}
