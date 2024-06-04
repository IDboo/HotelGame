using HotelGame.Business.Abstract;
using HotelGame.Entities.Concrete;
using HotelGame.WebMVC.Models.Account;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace HotelGame.WebMVC.Controllers
{
    public class AccountController : Controller
    {
        private IAuthenticationService _authenticationService;

        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = _authenticationService.AuthenticateUser(model.Email, model.Password);
                if (user != null)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Json(new { success = true, redirectUrl = returnUrl });
                    }

                    if (user.Roles.Contains("Admin"))
                    {
                        return Json(new { success = true, redirectUrl = Url.Action("Index", "Dashboard", new { area = "Admins" }) });
                    }
                    else if (user.Roles.Contains("User"))
                    {
                        return Json(new { success = true, redirectUrl = Url.Action("Index", "Dashboard", new { area = "Users" }) });
                    }
                    else if (user.Roles.Contains("ProjectAdmin"))
                    {
                        return Json(new { success = true, redirectUrl = Url.Action("Index", "Dashboard", new { area = "ProjectAdmins" }) });
                    }
                }
                else
                {
                    return Json(new { success = false, message = "Eposta Adresiniz veya Şifreniz Yanlış" });
                }
            }
            return Json(new { success = false, message = "Eposta Adresiniz veya Şifreniz Yanlış" });
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Kullanıcı varlığını kontrol et
                    if (_authenticationService.UserExists(model.Email))
                    {
                        return Json(new { success = false, message = "Bu e-posta adresi zaten kullanılıyor." });
                    }

                    User user = new User
                    {
                        Name = model.Name,
                        LastName = model.LastName,
                        UserName = model.Email, // UserName olarak e-posta adresi kullanılıyor
                        Email = model.Email
                    };

                    bool result = _authenticationService.CreateUser(user, model.Password);
                    if (result)
                    {
                        return Json(new { success = true });
                    }
                }
                catch (System.Exception ex)
                {
                    return Json(new { success = false, message = ex.Message });
                }
            }
            return Json(new { success = false, message = "Kayıt işlemi sırasında bir hata oluştu." });
        }

        public async Task<IActionResult> LogOut()
        {
            await _authenticationService.SignOut();
            return RedirectToAction("Index", "Home"); // Ana sayfaya yönlendir
        }

        public IActionResult Unauthorize()
        {
            return View();
        }
    }
}
