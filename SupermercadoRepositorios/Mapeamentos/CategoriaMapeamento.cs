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
    public class CategoriaMapeamento : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            // Configurar a Primary Key para a propriedade do Id
            builder.HasKey(x => x.Id);

            // Definir que a coluna do Id será incrementada automaticamente
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            // Definir que a coluna nome é do tipo VARCHAR(25) requerida
            builder.Property(x => x.Nome)
                .HasColumnType("VARCHAR")
                .HasMaxLength(25)
                .IsRequired();
        }
    }
}
