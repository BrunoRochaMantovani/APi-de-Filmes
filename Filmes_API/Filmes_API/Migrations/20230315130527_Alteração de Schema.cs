using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Filmes_API.Migrations
{
    /// <inheritdoc />
    public partial class AlteraçãodeSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmeAtor");

            migrationBuilder.DropTable(
                name: "FilmeGenero");

            migrationBuilder.DropTable(
                name: "Atores");

            migrationBuilder.AddColumn<int>(
                name: "GeneroId",
                table: "Filmes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Filmes_GeneroId",
                table: "Filmes",
                column: "GeneroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Filmes_Generos_GeneroId",
                table: "Filmes",
                column: "GeneroId",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filmes_Generos_GeneroId",
                table: "Filmes");

            migrationBuilder.DropIndex(
                name: "IX_Filmes_GeneroId",
                table: "Filmes");

            migrationBuilder.DropColumn(
                name: "GeneroId",
                table: "Filmes");

            migrationBuilder.CreateTable(
                name: "Atores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data_Nascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nacionalidade = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    PrimeiroNome = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    UltimoNome = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilmeGenero",
                columns: table => new
                {
                    FilmeId = table.Column<int>(type: "int", nullable: false),
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmeGenero", x => new { x.FilmeId, x.GeneroId });
                    table.ForeignKey(
                        name: "FK_FilmeGenero_Filmes_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Filmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmeGenero_Generos_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmeAtor",
                columns: table => new
                {
                    AtorId = table.Column<int>(type: "int", nullable: false),
                    FilmeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmeAtor", x => new { x.AtorId, x.FilmeId });
                    table.ForeignKey(
                        name: "FK_FilmeAtor_Atores_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Atores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmeAtor_Filmes_AtorId",
                        column: x => x.AtorId,
                        principalTable: "Filmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atores_Nacionalidade",
                table: "Atores",
                column: "Nacionalidade",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FilmeAtor_FilmeId",
                table: "FilmeAtor",
                column: "FilmeId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmeGenero_GeneroId",
                table: "FilmeGenero",
                column: "GeneroId");
        }
    }
}
