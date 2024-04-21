using Microsoft.Extensions.DependencyInjection;
using SupermercadoServicos.Interfaces;
using SupermercadoServicos.Servicos;

namespace SupermercadoServicos.DependecyInjections
{
    public static class ServicoDependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoriaServico, CategoriaServico>();
            services.AddScoped<IProdutoServico, ProdutoServico>();
            services.AddScoped<IEstanteServico, EstanteServico>();
            services.AddScoped<IArquivoUploadServico, ArquivoUploadServico>();
            return services;
        }
    }
}
