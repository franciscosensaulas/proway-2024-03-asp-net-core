using AutoMapper;
using SupermercadoRepositorios.Entidades;
using SupermercadoRepositorios.Repositorios;
using SupermercadoServicos.Dtos.Estantes;
using SupermercadoServicos.Interfaces;

namespace SupermercadoServicos.Servicos
{
    public class EstanteServico : IEstanteServico
    {
        private readonly IEstanteRepositorio _estanteRepositorio;
        private readonly IMapper _mapper;

        public EstanteServico(IEstanteRepositorio estanteRepositorio, IMapper mapper)
        {
            _estanteRepositorio = estanteRepositorio;
            _mapper = mapper;
        }

        public void Apagar(int id)
        {
            _estanteRepositorio.Apagar(id);
        }

        public int Cadastrar(EstanteCadastrarDto dto)
        {
            var estante = _mapper.Map<Estante>(dto);
            _estanteRepositorio.Cadastrar(estante);
            return estante.Id;
        }

        public void Editar(EstanteEditarDto dto)
        {
            var estante = _estanteRepositorio.ObterPorId(dto.Id);
            estante.Nome = dto.Nome;
            estante.Sigla = dto.Sigla;
            _estanteRepositorio.Atualizar(estante);
        }

        public EstanteDto ObterPorId(int id)
        {
            var estante = _estanteRepositorio.ObterPorId(id);
            return _mapper.Map<EstanteDto>(estante);
        }

        public List<EstanteDto> ObterTodos()
        {
            var estantes = _estanteRepositorio.ObterTodos(string.Empty);
            return _mapper.Map<List<EstanteDto>>(estantes);
        }
    }
}
