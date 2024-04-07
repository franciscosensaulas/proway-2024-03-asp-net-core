using SupermercadoServicos.Dtos.Produtos;

namespace ProwayWebMvc.Models.Produtos
{
    public class ProdutoIndexViewModel
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public string Categoria { get; private set; }
        public DateTime? DataVencimento { get; private set; }
        public string? NomeArquivo { get; private set; }

        public static List<ProdutoIndexViewModel> ConstruirCom(List<ProdutoDto> dtos)
        {
            var viewModels = new List<ProdutoIndexViewModel>();
            foreach (var produtoDto in dtos)
            {
                var produtoIndexViewModel = new ProdutoIndexViewModel
                {
                    Id = produtoDto.Id,
                    Nome = produtoDto.Nome,
                    Categoria = produtoDto.Categoria,
                    PrecoUnitario = produtoDto.PrecoUnitario,
                    DataVencimento = produtoDto.DataVencimento,
                    NomeArquivo = produtoDto.NomeArquivo,
                };
                viewModels.Add(produtoIndexViewModel);
            }

            return viewModels;
        }
    }
}
