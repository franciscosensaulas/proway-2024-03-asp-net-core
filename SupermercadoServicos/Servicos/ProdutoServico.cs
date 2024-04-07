using SupermercadoRepositorios.Entidades;
using SupermercadoRepositorios.Modelos;
using SupermercadoRepositorios.Repositorios;
using SupermercadoServicos.Dtos.Produtos;
using SupermercadoServicos.Interfaces;

namespace SupermercadoServicos.Servicos
{
    public class ProdutoServico : IProdutoServico
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        private readonly IArquivoUploadServico _arquivoUploadServico;

        public ProdutoServico(
            IProdutoRepositorio produtoRepositorio,
            ICategoriaRepositorio categoriaRepositorio,
            IArquivoUploadServico arquivoUploadServico)
        {
            _produtoRepositorio = produtoRepositorio;
            _categoriaRepositorio = categoriaRepositorio;
            _arquivoUploadServico = arquivoUploadServico;
        }

        public void Apagar(int id)
        {
            _produtoRepositorio.Apagar(id);
        }

        public int Cadastrar(ProdutoCadastrarDto produtoCadastrarDto)
        {
            var categoria = _categoriaRepositorio.ObterPorId(produtoCadastrarDto.CategoriaId);
            
            // Seleciona o arquivo, salvar (arquivo será enviado para o servidor)
            // Servidor terá que verificar, armazenar esse arquivo (local, S3/Azure Blob Storage, Banco Dados)
            var nomeArquivo = _arquivoUploadServico.ArmazenarArquivo(
                produtoCadastrarDto.Arquivo, produtoCadastrarDto.CaminhoServidor);

            var produto = new Produto
            {
                //Categoria = categoria,
                CategoriaId = categoria.Id,
                Nome = produtoCadastrarDto.Nome,
                PrecoUnitario = produtoCadastrarDto.PrecoUnitario,
                DataVencimento = produtoCadastrarDto.DataVencimento,
                Observacao = produtoCadastrarDto.Observacao,
                Arquivo = nomeArquivo,
            };
            _produtoRepositorio.Cadastrar(produto);
            return produto.Id;
        }

        public void Editar(ProdutoEditarDto produtoEditarDto)
        {
            throw new NotImplementedException();
        }

        public ProdutoDto ObterPorId(int id)
        {
            var produto = _produtoRepositorio.ObterPorId(id);
            return ConstruirProdutoDto(produto);
        }

        public List<ProdutoDto> ObterTodos()
        {
            var produtoDtos = new List<ProdutoDto>();
            var produtos = _produtoRepositorio.ObterTodos(new ProdutoFiltros());

            foreach (var produto in produtos)
                produtoDtos.Add(ConstruirProdutoDto(produto));
            return produtoDtos;
        }

        private ProdutoDto ConstruirProdutoDto(Produto produto)
        {
            return new ProdutoDto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                PrecoUnitario = produto.PrecoUnitario,
                Categoria = produto.Categoria.Nome,
                DataVencimento = produto.DataVencimento,
                NomeArquivo = produto.Arquivo,
            };
        }
    }
}
