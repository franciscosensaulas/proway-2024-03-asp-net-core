using System.ComponentModel.DataAnnotations;

namespace ProwayWebMvc.Models.Autenticacao
{
    public class AutenticacaoViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType (DataType.Password)]
        public string Senha { get; set; }
    }
}
