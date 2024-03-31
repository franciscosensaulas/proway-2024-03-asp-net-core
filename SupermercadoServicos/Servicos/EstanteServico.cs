using SupermercadoRepositorios.Entidades;
using SupermercadoRepositorios.Repositorios;
using SupermercadoServicos.Dtos.Estantes;
using SupermercadoServicos.Interfaces;

namespace SupermercadoServicos.Servicos
{
    public class EstanteServico : IEstanteServico
    {
        private readonly IEstanteRepositorio _estanteRepositorio;

        public EstanteServico(IEstanteRepositorio estanteRepositorio)
        {
            _estanteRepositorio = estanteRepositorio;
        }

        public void Apagar(int id)
        {
            _estanteRepositorio.Apagar(id);
        }

        public int Cadastrar(EstanteCadastrarDto dto)
        {
            var estante = new Estante
            {
                Nome = dto.Nome,
                Sigla = dto.Sigla,
            };
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
            var estanteDto = new EstanteDto
            {
                Nome = estante.Nome,
                Sigla = estante.Sigla,
            };
            return estanteDto;
        }

        public List<EstanteDto> ObterTodos()
        {
            var estantes = _estanteRepositorio.ObterTodos(string.Empty);
            var estanteDtos = new List<EstanteDto>();

            foreach (var estante in estantes)
            {
                var estanteDto = new EstanteDto
                {
                    Id = estante.Id,
                    Nome = estante.Nome,
                    Sigla = estante.Sigla,
                };
                estanteDtos.Add(estanteDto);
            }
            return estanteDtos;
        }
    }
}
