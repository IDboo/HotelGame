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
                        return Redirect(returnUrl);

                    if (user.Roles.Contains("Admin"))
                    {
                        return RedirectToAction("Index", "Dashboard", new { area = "Admins" });
                        //return RedirectToAction("Index", "Dashboard","Admin/Index");
                    }
                    else if (user.Roles.Contains("User"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "Users" });

                        /*return RedirectToAction("Index", "Dashboard","Admin/User");*/
                    }
                    else if (user.Roles.Contains("ProjectAdmin"))
                    {
                        return RedirectToAction("Index", "Dashboard", new { area = "ProjectAdmins" });

                        /*return RedirectToAction("Index", "Dashboard","Admin/User");*/
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Eposta Adresiniz veya Şifreniz Yanlış");
                    ViewBag.Error = "Eposta Adresiniz veya Şifreniz Yanlış";
                    return View("Login");
                }
            }
            else
            {
                ModelState.AddModelError("", "Eposta Adresiniz veya Şifreniz Yanlış");

            }
            return View();
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
                User user = new User
                {
                    Name = model.Name,
                    LastName = model.LastName,
                    UserName = model.Email,
                    Email = model.Email,
                };
                bool result = _authenticationService.CreateUser(user, model.Password);
                if (result)
                {
                    return RedirectToAction("Login");
                }
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _authenticationService.SignOut();
            return RedirectToAction("LogOutComplete");
        }

        public IActionResult LogOutComplete()
        {
            return View("Login");
        }
        public IActionResult Unauthorize()
        {
            return View();
        }



    }
}
