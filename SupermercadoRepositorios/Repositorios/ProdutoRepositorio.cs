using Microsoft.EntityFrameworkCore;
using SupermercadoRepositorios.BancoDados;
using SupermercadoRepositorios.Entidades;
using SupermercadoRepositorios.Modelos;
using SupermercadoRepositorios.Repositorios.Base;

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
    public class ProdutoRepositorio : RepositorioBase<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(SupermercadoContexto contexto) : base(contexto)
        {
        }

        /*
         * Orientação a Objetos
             - Classe
                - Proprieades
                - Métodos => public void Executar(int numero1)
                     - Com(string,int) e sem retorno(void)
                     - Com e sem parâmetros => int numero1, o que fica dentro dos parênteses
        */


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
    }
}
