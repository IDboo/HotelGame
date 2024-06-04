using HotelGame.Business.Abstract;
using HotelGame.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace HotelGame.Business.Concrete
{
    public class AuthenticationManager : IAuthenticationService
    {
        protected SignInManager<User> _signInManager;
        protected UserManager<User> _userManager;
        protected RoleManager<Role> _roleManager;

        public AuthenticationManager(SignInManager<User> signInManager, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public User AuthenticateUser(string userName, string password)
        {
            var result = _signInManager.PasswordSignInAsync(userName, password, false, lockoutOnFailure: false).Result;

            if (result.Succeeded)
            {
                var user = _userManager.FindByNameAsync(userName).Result;
                var roles = _userManager.GetRolesAsync(user).Result;
                user.Roles = roles.ToArray();
                return user;
            }
            return null;
        }

        public bool CreateUser(User user, string password)
        {
            var existingUserByName = _userManager.FindByNameAsync(user.UserName).Result;
            if (existingUserByName != null)
            {
                throw new System.Exception("Kullanıcı adı zaten mevcut: " + user.UserName);
            }

            var existingUserByEmail = _userManager.FindByEmailAsync(user.Email).Result;
            if (existingUserByEmail != null)
            {
                throw new System.Exception("E-posta adresi zaten mevcut: " + user.Email);
            }

            var result = _userManager.CreateAsync(user, password).Result;
            if (result.Succeeded)
            {
                var res = _userManager.AddToRoleAsync(user, "User").Result;
                if (res.Succeeded)
                {
                    return true;
                }
                else
                {
                    throw new System.Exception("Rol ekleme işlemi başarısız.");
                }
            }
            else
            {
                throw new System.Exception(string.Join("; ", result.Errors.Select(e => e.Description)));
            }
        }

        public User GetUser(string username)
        {
            return _userManager.FindByNameAsync(username).Result;
        }

        public async Task<bool> SignOut()
        {
            await _signInManager.SignOutAsync();
            return true;
        }

        public bool UserExists(string email)
        {
            return _userManager.FindByEmailAsync(email).Result != null;
        }
    }
}
