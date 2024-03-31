using System.ComponentModel.DataAnnotations;

namespace ProwayWebMvc.Models.Estantes
{
    public class EstanteCadastrarViewModel
    {
        [Required(ErrorMessage = "{0} é obrigatório")]
        [Length(3, 50, ErrorMessage = "{0} deve conter no mínimo {1} caracteres no máximo {2}")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [Length(3, 3, ErrorMessage = "{0} deve conter no mínimo {1} caracteres no máximo {2}")]
        public string Sigla { get; set; }
    }
}
