using Microsoft.AspNetCore.Http;

namespace SupermercadoServicos.Dtos.Produtos
{
    public class ProdutoCadastrarDto
    {
        public string Nome { get; set; }
        public decimal PrecoUnitario { get; set; }
        public DateTime DataVencimento { get; set; }
        public int CategoriaId { get; set; }
        public string? Observacao { get; set; }
        public IFormFile? Arquivo { get; set; }
        public string CaminhoServidor { get; set; }
    }
}
