using WebApplication1.Interfaceses;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1
{
    public static class StartUp
    {
        public static void AddConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDbContext, ApplicationDbContext>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICompanyService, CompanyService>();
        }
    }
}
