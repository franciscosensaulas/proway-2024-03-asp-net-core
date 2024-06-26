﻿using AutoMapper;
using SupermercadoRepositorios.Entidades;
using SupermercadoServicos.Dtos.Estantes;


namespace ProwayWebAPI.DependencyInjections
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
                x.CreateMap<EstanteCadastrarDto, Estante>();
                x.CreateMap<EstanteEditarDto, Estante>();
                x.CreateMap<Estante, EstanteDto>();
            });

            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
