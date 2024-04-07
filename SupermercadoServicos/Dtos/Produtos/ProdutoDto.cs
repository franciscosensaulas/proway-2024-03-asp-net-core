namespace SupermercadoServicos.Dtos.Produtos
{
    public class ProdutoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal PrecoUnitario { get; set; }
        public string Categoria { get; set; }
        public DateTime? DataVencimento { get; set; }
        public string? NomeArquivo { get; set; }
    }
}
