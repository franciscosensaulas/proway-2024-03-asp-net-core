using SupermercadoRepositorios.Entidades;

namespace SupermercadoRepositorios.Repositorios.Base
{
    public interface IRepositorioBase<TEntidade>
        where TEntidade: EntidadeBase
    {
        List<TEntidade> ObterTodos();
        TEntidade Cadastrar(TEntidade entidade);
        void Atualizar(TEntidade entidade);
        void Apagar(int id);
        TEntidade? ObterPorId(int id);
    }
}