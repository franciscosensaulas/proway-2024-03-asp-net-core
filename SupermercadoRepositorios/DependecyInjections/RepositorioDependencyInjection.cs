using Microsoft.Extensions.DependencyInjection;
using SupermercadoRepositorios.Repositorios;

namespace SupermercadoRepositorios.DependecyInjections
{
    public static class RepositorioDependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddScoped<IEstanteRepositorio, EstanteRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            return services;
        }
    }
}
