using Microsoft.EntityFrameworkCore;
using SupermercadoRepositorios.BancoDados;
using SupermercadoRepositorios.Entidades;
using SupermercadoRepositorios.Modelos;

namespace SupermercadoRepositorios.Repositorios
{
    // Repositório: tem a responsabilidade de
    // intermediar a camadas anteriores (tela) com o Banco de Dados, ou seja, ele é responsável 
    // por executar comandos de SQL (SELECT,INSERT,UPDATE,DELETE) 
    // CRUD => 
    // Create => INSERT
    // Read => SELECT
    // Update => UPDATE
    // Delete => DELETE
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly SupermercadoContexto _contexto;

        public ProdutoRepositorio()
        {
            _contexto = new SupermercadoContexto();
        }

        /*
         * Orientação a Objetos
             - Classe
                - Proprieades
                - Métodos => public void Executar(int numero1)
                     - Com(string,int) e sem retorno(void)
                     - Com e sem parâmetros => int numero1, o que fica dentro dos parênteses
        */
        public void Cadastrar(Produto produto)
        {
            _contexto.Produtos.Add(produto);
            _contexto.SaveChanges();
        }

        public List<Produto> ObterTodos(ProdutoFiltros produtoFiltros)
        {
            return _contexto.Produtos
                .Include(x => x.Categoria) // Inner JOIN (incluindo no SELECT o inner join com a tabela de categorias)
                .ToList();
        }

        public int ObterQuantidadeTotalRegistros()
        {
            return _contexto.Produtos.Count();
        }

        public void Apagar(int id)
        {
            var produto = ObterPorId(id);
            _contexto.Produtos.Remove(produto);
            _contexto.SaveChanges();
        }

        public Produto ObterPorId(int id)
        {
            return _contexto.Produtos.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Atualizar(Produto produto)
        {
            _contexto.Produtos.Update(produto); 
            _contexto.SaveChanges();
        }
    }
}
