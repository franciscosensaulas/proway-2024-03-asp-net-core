using Microsoft.EntityFrameworkCore;
using SupermercadoRepositorios.Entidades;
using SupermercadoRepositorios.Mapeamentos;

namespace SupermercadoRepositorios.BancoDados
{
    public class SupermercadoContexto : DbContext
    {
        public DbSet<Estante> Estantes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        // dotnet tool install --global dotnet-ef

        // dotnet ef migrations add <NomeMigration> --project <NomeProjetoRepositorio> --startup-project <NomeProjetoWeb>
        // Exemplo: dotnet ef migrations add InicialMigracao --project SupermercadoRepositorios --startup-project ProwayWebMvc

        // dotnet ef database update --project SupermercadoRepositorios --startup-project ProwayWebMvc
        // Migration: é um snapshot do código referente as tabelas do banco de dados

        public SupermercadoContexto(DbContextOptions options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoriaMapeamento());
            modelBuilder.ApplyConfiguration(new EstanteMapeamento());
            modelBuilder.ApplyConfiguration(new ProdutoMapeamento());
        }
    }
}
