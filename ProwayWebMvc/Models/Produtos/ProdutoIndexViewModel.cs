using SupermercadoServicos.Dtos.Produtos;

namespace ProwayWebMvc.Models.Produtos
{
    public class ProdutoIndexViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal PrecoUnitario { get; set; }
        public string Categoria { get; set; }
        public DateTime? DataVencimento { get; set; }


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
                };
                viewModels.Add(produtoIndexViewModel);
            }

            return viewModels;
        }
    }
}
