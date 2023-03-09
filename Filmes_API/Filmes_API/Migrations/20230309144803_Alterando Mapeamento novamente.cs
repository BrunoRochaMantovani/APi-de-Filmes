using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Filmes_API.Migrations
{
    /// <inheritdoc />
    public partial class AlterandoMapeamentonovamente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AtorId",
                table: "Filmes");

            migrationBuilder.DropColumn(
                name: "GeneroId",
                table: "Filmes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AtorId",
                table: "Filmes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GeneroId",
                table: "Filmes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
