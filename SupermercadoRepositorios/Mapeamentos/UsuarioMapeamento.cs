using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupermercadoRepositorios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermercadoRepositorios.Extensions;

namespace SupermercadoRepositorios.Mapeamentos
{
    public class UsuarioMapeamento : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuarios");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Senha)
                .HasColumnType("VARCHAR")
                .HasMaxLength(200)
                .IsRequired();


            builder.HasData(new Usuario
            {
                Id = 1,
                Nome = "Usuário admin",
                Email = "admin@franciscosensaulas.com.br",
                Senha = "1234".Hash512()
            });
        }
    }
}
