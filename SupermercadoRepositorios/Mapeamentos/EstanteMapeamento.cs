using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SupermercadoRepositorios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermercadoRepositorios.Mapeamentos
{
    public class EstanteMapeamento : IEntityTypeConfiguration<Estante>
    {
        public void Configure(EntityTypeBuilder<Estante> builder)
        {
            // Configurar a Primary Key para a propriedade do Id
            builder.HasKey(x => x.Id);

            // Definir que a coluna do Id será incrementada automaticamente
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            // Definir que a coluna nome é do tipo VARCHAR(50) requerida
            builder.Property(x => x.Nome)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            // Definir que a coluna sigla é do tipo CHAR(3) requerida
            builder.Property(x => x.Sigla)
                .HasColumnType("CHAR")
                .HasMaxLength(3)
                .IsRequired();
        }
    }
}
