using SupermercadoRepositorios.Entidades;
using SupermercadoRepositorios.Repositorios;
using SupermercadoServicos.Dtos.Categorias;
using SupermercadoServicos.Interfaces;

namespace SupermercadoServicos.Servicos
{
    public class CategoriaServico : ICategoriaServico
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriaServico()
        {
            _categoriaRepositorio = new CategoriaRepositorio();
        }

        public void Apagar(int id)
        {
            _categoriaRepositorio.Apagar(id);
        }

        public int Cadastrar(CategoriaCadastrarDto categoriaCadastrarDto)
        {
            var categoria = new Categoria();
            categoria.Nome = categoriaCadastrarDto.Nome;

            _categoriaRepositorio.Cadastrar(categoria);

            return categoria.Id;
        }

        // Data Transfer Object
        public void Editar(CategoriaEditarDto categoriaEditarDto)
        {
            var categoria = _categoriaRepositorio.ObterPorId(categoriaEditarDto.Id);
            categoria.Nome = categoriaEditarDto.Nome;

            _categoriaRepositorio.Atualizar(categoria);
        }

        public CategoriaDto ObterPorId(int id)
        {
            // Buscar a lista de categorias do Banco de dados
            var categoria = _categoriaRepositorio.ObterPorId(id);
            // Instanciar a CategoriaDto com o dado do registro do BD
            var categoriaDto = new CategoriaDto
            {
                Id = categoria.Id,
                Nome = categoria.Nome
            };
            // Retorna o dto criado
            return categoriaDto;
        }

        public List<CategoriaDto> ObterTodos()
        {
            // Buscar a lista de categorias do Banco de dados
            var categorias = _categoriaRepositorio.ObterTodos();
            // Criar uma lista de categoria dto, pq a camada de serviço
            // retorna DTO para a camada de aplicação
            var categoriaDtos = new List<CategoriaDto>();
            // Percorrer a lista de categorias do BD
            foreach (var categoria in categorias)
            {
                // Instanciar a CategoriaDto com os dados do registro do BD
                var categoriaDto = new CategoriaDto
                {
                    Id = categoria.Id,
                    Nome = categoria.Nome
                };
                // Adicionar a categoriaDto na lista de dtos
                categoriaDtos.Add(categoriaDto);
            }
            // Retorna a lista criada
            return categoriaDtos;
        }
    }
}
