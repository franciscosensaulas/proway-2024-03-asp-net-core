using SupermercadoRepositorios.BancoDados;
using SupermercadoRepositorios.Entidades;
using SupermercadoRepositorios.Repositorios.Base;

namespace SupermercadoRepositorios.Repositorios
{
    public class CategoriaRepositorio : RepositorioBase<Categoria>, ICategoriaRepositorio
    {
        public CategoriaRepositorio(SupermercadoContexto contexto) : base(contexto)
        {
        }
    }
}
