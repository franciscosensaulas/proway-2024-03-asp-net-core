using SupermercadoRepositorios.BancoDados;
using SupermercadoRepositorios.Entidades;
using System.Data;

namespace SupermercadoRepositorios.Repositorios
{
    //public class CategoriaRepositorio extends ClasseBase implements ICategoriaRepositorio
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly SupermercadoContexto _contexto;

        public CategoriaRepositorio()
        {
            _contexto = new SupermercadoContexto();
        }

        public List<Categoria> ObterTodos()
        {
            return _contexto.Categorias.ToList();
        }

        // Assinatura do método Cadastrar
        // encapsulamento + TipoRetorno + NomeMetodo(TipoParametro nomeParametro, ....)
        public void Cadastrar(Categoria categoria)
        {
            _contexto.Categorias.Add(categoria);
            _contexto.SaveChanges();
        }

        public void Atualizar(Categoria categoria)
        {
            _contexto.Categorias.Update(categoria);
            _contexto.SaveChanges();
        }

        public void Apagar(int id)
        {
            var categoria = ObterPorId(id);
            _contexto.Categorias.Remove(categoria);
            _contexto.SaveChanges();
        }

        public Categoria ObterPorId(int id)
        {
            return _contexto.Categorias.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
