using SupermercadoRepositorios.Entidades;
using SupermercadoRepositorios.Repositorios.Base;

namespace SupermercadoRepositorios.Repositorios
{
    public interface IEstanteRepositorio : IRepositorioBase<Estante>
    {
        List<Estante> ObterTodos(string pesquisa);
    }
}
