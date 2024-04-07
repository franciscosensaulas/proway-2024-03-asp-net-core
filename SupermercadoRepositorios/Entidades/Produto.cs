using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupermercadoRepositorios.Entidades
{
    public class Produto : EntidadeBase
    {
        public string Nome { get; set; }
        public decimal PrecoUnitario { get; set; }
        public DateTime? DataVencimento { get; set; }
        public string? Observacao { get; set; }
        public string? Arquivo { get; set; }


        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
