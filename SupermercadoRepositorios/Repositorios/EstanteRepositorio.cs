using SupermercadoRepositorios.BancoDados;
using SupermercadoRepositorios.Entidades;
using SupermercadoRepositorios.Repositorios.Base;
using System.Data;

namespace SupermercadoRepositorios.Repositorios
{
    public class EstanteRepositorio : RepositorioBase<Estante>, IEstanteRepositorio
    {
        // Construtor tem como objetivo definir/construir tudo que é necessário para que a classe funcione corretametne
        // Encapsulamento + NomeClasseAtual()
        public EstanteRepositorio(SupermercadoContexto contexto) : base(contexto)
        {
        }

        public List<Estante> ObterTodos(string pesquisa)
        {
            return _contexto.Estantes.Where(x => x.Nome.Contains(pesquisa)).ToList();
        }
    }
}
