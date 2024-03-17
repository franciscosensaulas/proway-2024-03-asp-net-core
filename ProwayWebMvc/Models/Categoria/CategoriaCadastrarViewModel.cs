using System.ComponentModel.DataAnnotations;

namespace ProwayWebMvc.Models.Categoria
{
    public class CategoriaCadastrarViewModel
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [MinLength(3, ErrorMessage = "Nome deve conter no mínimo 3 caracteres")]
        [MaxLength(25, ErrorMessage = "Nome deve conter no máximo 25 caracteres")]
        public string Nome { get; set; }
    }
}
