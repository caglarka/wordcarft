using Microsoft.EntityFrameworkCore;
using WordCraft.Core.Models.ConfigurationModel;
using WordCraft.Core.Utilities.Security.Jwt;
using WordCraft.Data.DbContexts;
using WordCraft.Data.Repositories;
using WordCraft.Service.Mapper;
using WordCraft.Service.Services.WordCraft.AuthServices;
using WordCraft.Service.Services.WordCraft.UserServices;

namespace WordCraft.API.Containers
{
    public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configRoot)
        {
            services.AddDbContext<WorkCraftContext>(options =>
            {
                options.UseSqlServer(configRoot.GetConnectionString("WordCraftConnection"));
            });

            services.AddAutoMapper(typeof(MapperProfile));
            services.AddScoped<ITokenHelper, JwtHelper>();


            services.AddRepositories();
            services.AddConfigs(configRoot);
            services.AddServices();
        }
        private static void AddConfigs(this IServiceCollection services, IConfiguration configRoot)
        {
            var jwtTokenConfigName = configRoot.GetSection(typeof(JwtTokenConfig).Name);
            services.Configure<JwtTokenConfig>(jwtTokenConfigName);                       
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
        }
        private static void AddValidations(this IServiceCollection services)
        {
        }
    }
}
