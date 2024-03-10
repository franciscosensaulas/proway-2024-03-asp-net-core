using SupermercadoRepositorios.Entidades;
using SupermercadoRepositorios.Modelos;

namespace SupermercadoRepositorios.Repositorios
{
    public interface IProdutoRepositorio
    {
        void Cadastrar(Produto produto);
        List<Produto> ObterTodos(ProdutoFiltros produtoFiltros);
        int ObterQuantidadeTotalRegistros();
        void Apagar(int id);
        Produto ObterPorId(int id);
        void Atualizar(Produto produto);
    }
}
