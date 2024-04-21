using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SupermercadoRepositorios.BancoDados;

namespace SupermercadoRepositorios.DependecyInjections
{
    public static class BancoDadosDependencyInjection
    {
        public static IServiceCollection ConfigureDatabase(
            this IServiceCollection services,
            IConfigurationManager configuration)
        {
            services.AddDbContext<SupermercadoContexto>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}
