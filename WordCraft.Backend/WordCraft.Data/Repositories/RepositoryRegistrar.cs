using Microsoft.Extensions.DependencyInjection;
using WordCraft.Data.Repositories.WordCraft.AuthRepository;
using WordCraft.Data.Repositories.WordCraft.UserRepository;
using WordCraft.Data.UnitOfWorks;

namespace WordCraft.Data.Repositories
{
    public static class RepositoryRegistrar
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();

        }
    }
}
