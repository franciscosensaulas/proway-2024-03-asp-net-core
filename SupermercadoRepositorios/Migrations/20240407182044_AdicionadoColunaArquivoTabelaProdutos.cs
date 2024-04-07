using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupermercadoRepositorios.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoColunaArquivoTabelaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VARCHAR",
                table: "Produtos",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VARCHAR",
                table: "Produtos");
        }
    }
}
