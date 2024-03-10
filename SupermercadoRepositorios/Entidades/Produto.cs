using System.ComponentModel.DataAnnotations.Schema;

namespace SupermercadoRepositorios.Entidades
{
    public class Produto : EntidadeBase
    {
        public string Nome { get; set; }
        [Column("preco_unitario")]
        public decimal PrecoUnitario { get; set; }


        [Column("id_categoria")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
