namespace SupermercadoServicos.Dtos.Produtos
{
    public class ProdutoCadastrarDto
    {
        public string Nome { get; set; }
        public decimal PrecoUnitario { get; set; }
        public DateTime DataVencimento { get; set; }
        public int CategoriaId { get; set; }
        public string? Observacao { get; set; }
    }
}
