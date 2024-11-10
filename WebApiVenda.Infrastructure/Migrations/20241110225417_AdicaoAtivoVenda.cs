using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiVenda.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdicaoAtivoVenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Vendas",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Vendas");
        }
    }
}
