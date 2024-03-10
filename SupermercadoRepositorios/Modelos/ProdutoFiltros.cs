namespace SupermercadoRepositorios.Modelos
{
    public class ProdutoFiltros
    {

        private string pesquisa;
        private string ordem;
        private string campo;

        // Get é utilizado para obter o dado
        // Set é utilizado para definir o dado
        public string Pesquisa
        {
            get
            {
                return pesquisa;
            }
            set
            {
                pesquisa = $"%{value}%";
            }
        }
        public int Quantidade { get; set; }
        public int Pagina { get; set; }
        public string OrdenacaoCampo
        {
            get
            {
                return campo;
            }
            set
            {
                value = value.ToLower();

                if (value == "código")
                    campo = "produtos.id";
                else if (value == "nome")
                    campo = "produtos.nome";
                else if (value == "categoria")
                    campo = "categorias.nome";
                else if (value == "preço unitário")
                    campo = "produtos.preco_unitario";
            }
        }
        public string OrdenacaoOrdem
        {
            get
            {
                return ordem;
            }
            set
            {
                if (value.ToLower() == "a-z")
                    ordem = "ASC";
                else
                    ordem = "DESC";
            }
        }
    }
}
