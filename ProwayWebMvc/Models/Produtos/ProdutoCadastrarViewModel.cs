using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProwayWebMvc.Models.Produtos
{
    public class ProdutoCadastrarViewModel
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [Length(3, 150, ErrorMessage = "Nome deve conter no mínimo 3 caracteres no máximo 150")]
        public string? Nome { get; set; }
        
        [Required(ErrorMessage = "Preço Unitário é obrigatorio")]
        [DisplayName("Preço Unitário")]
        public decimal? PrecoUnitario { get; set; }
       
        [Required (ErrorMessage = "Categoria é obrigatória")]
        [DisplayName("Categoria")]
        public int? CategoriaId { get; set; }
        
        [Required(ErrorMessage = "Data de Vencimento é obrigatória")]
        [DisplayName("Data de Vencimento")]
        public DateTime? DataVencimento { get; set; }

        [DisplayName("Observação")]
        public string? Observacao { get; set; }

        // IFormFile é utilizado para fazer upload de arquivos do Browser para o servidor
        [DisplayName("Imagem")]
        public IFormFile? Arquivo { get; set; }
    }
}
