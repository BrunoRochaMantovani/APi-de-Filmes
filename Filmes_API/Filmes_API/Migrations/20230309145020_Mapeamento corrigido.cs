using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Filmes_API.Migrations
{
    /// <inheritdoc />
    public partial class Mapeamentocorrigido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilmeId",
                table: "Diretores");

            migrationBuilder.DropColumn(
                name: "FilmeId",
                table: "Atores");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FilmeId",
                table: "Diretores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FilmeId",
                table: "Atores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
