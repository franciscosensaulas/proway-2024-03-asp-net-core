using AutoMapper;
using ProwayWebMvc.Models.Autenticacao;
using ProwayWebMvc.Models.Estantes;
using SupermercadoRepositorios.Entidades;
using SupermercadoServicos.Dtos.Autenticacao;
using SupermercadoServicos.Dtos.Estantes;

namespace ProwayWebMvc.DependencyInjections
{
    public static class AutoMapperDependencyInjection
    {
        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            // source => origem
            // destination => destino
            // Requisição: Controller (ViewModel) => Serviço (Dto) => Repositorio (Entidade)
            var mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<EstanteCadastrarViewModel, EstanteCadastrarDto>();
                x.CreateMap<EstanteCadastrarDto, Estante>();
                x.CreateMap<EstanteEditarViewModel, EstanteEditarDto>();
                x.CreateMap<EstanteEditarDto, Estante>();
                x.CreateMap<EstanteDto, EstanteIndexViewModel>();
                x.CreateMap<Estante, EstanteDto>();
                x.CreateMap<EstanteDto, EstanteEditarViewModel>();

                x.CreateMap<AutenticacaoViewModel, AutenticacaoDto>()
                    .ForPath(x => x.Senha, opt => opt.MapFrom(x => x.Senha.Hash512()));
            });

            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
