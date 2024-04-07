using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupermercadoRepositorios.Entidades;

namespace SupermercadoRepositorios.Mapeamentos
{
    public class ProdutoMapeamento : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            // Configurar a Primary Key para a propriedade do Id
            builder.HasKey(x => x.Id);

            // Definir que a coluna do Id será incrementada automaticamente
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            // Definir que a coluna nome é do tipo VARCHAR(150) requerida
            builder.Property(x => x.Nome)
                .HasColumnType("VARCHAR")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.PrecoUnitario)
                .HasColumnType("DECIMAL")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(x => x.DataVencimento)
                .HasColumnType("DATETIME2");

            builder.Property(x => x.Observacao)
                .HasColumnType("TEXT");

            builder.Property(x => x.Arquivo)
                .HasColumnName("VARCHAR")
                .HasMaxLength(300);
            

            // Adicionar coluna para criar o Foreign key, criando o
            // relacionamento entre produto e categoria
            builder.HasOne(x => x.Categoria)
                .WithMany()
                .IsRequired();

        }
    }
}
