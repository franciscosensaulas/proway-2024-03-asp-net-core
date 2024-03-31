using Microsoft.EntityFrameworkCore;
using SupermercadoRepositorios.BancoDados;
using SupermercadoRepositorios.Entidades;

namespace SupermercadoRepositorios.Repositorios.Base
{
    public class RepositorioBase<TEntidade> : IRepositorioBase<TEntidade>
        where TEntidade : EntidadeBase
    {
        protected readonly SupermercadoContexto _contexto;
        protected readonly DbSet<TEntidade> _dbSet;

        public RepositorioBase(SupermercadoContexto contexto)
        {
            _contexto = contexto;
            _dbSet = _contexto.Set<TEntidade>();
        }

        public List<TEntidade> ObterTodos()
        {
            return _dbSet.ToList();
        }

        public TEntidade Cadastrar(TEntidade entidade)
        {
            _dbSet.Add(entidade);
            _contexto.SaveChanges();
            return entidade;
        }

        public void Atualizar(TEntidade entidade)
        {
            _dbSet.Update(entidade);
            _contexto.SaveChanges();
        }

        public void Apagar(int id)
        {
            var entidade = ObterPorId(id);
            _dbSet.Remove(entidade);
            _contexto.SaveChanges();
        }

        public TEntidade? ObterPorId(int id)
        {
            return _dbSet.Find(id);
        }
    }
}
