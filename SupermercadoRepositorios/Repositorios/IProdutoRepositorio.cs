using SupermercadoRepositorios.Entidades;
using SupermercadoRepositorios.Modelos;
using SupermercadoRepositorios.Repositorios.Base;

namespace SupermercadoRepositorios.Repositorios
{
    public interface IProdutoRepositorio : IRepositorioBase<Produto>
    {
        List<Produto> ObterTodos(ProdutoFiltros produtoFiltros);
        int ObterQuantidadeTotalRegistros();
    }
}
