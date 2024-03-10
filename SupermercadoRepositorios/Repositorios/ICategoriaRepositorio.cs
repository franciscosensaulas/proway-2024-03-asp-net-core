using SupermercadoRepositorios.Entidades;

namespace SupermercadoRepositorios.Repositorios
{
    public interface ICategoriaRepositorio
    {
        List<Categoria> ObterTodos();
        void Cadastrar(Categoria categoria);
        void Atualizar(Categoria categoria);
        void Apagar(int id);
        Categoria ObterPorId(int id);
    }
}
