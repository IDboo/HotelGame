using HotelGame.WebMVC.Helper.Abstract;
using HotelGame.WebMVC.Helper.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace HotelGame.WebMVC.Configurations
{



    public class ConfigureDependencies
    {
        public static void AddServices(IServiceCollection services)
        {
            //services.AddScoped<IAuthenticationService, AuthenticationManager>();

            services.AddTransient<IUserAccessor, UserAccessor>();
            services.AddTransient<IFileHelper, FileHelper>();


        }



    }


}
