using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Filmes_API.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoFluentMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmeGenero_Filmes_FilmesId",
                table: "FilmeGenero");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmeGenero_Generos_GenerosId",
                table: "FilmeGenero");

            migrationBuilder.DropTable(
                name: "AtorFilme");

            migrationBuilder.RenameColumn(
                name: "GenerosId",
                table: "FilmeGenero",
                newName: "GeneroId");

            migrationBuilder.RenameColumn(
                name: "FilmesId",
                table: "FilmeGenero",
                newName: "FilmeId");

            migrationBuilder.RenameIndex(
                name: "IX_FilmeGenero_GenerosId",
                table: "FilmeGenero",
                newName: "IX_FilmeGenero_GeneroId");

            migrationBuilder.AlterColumn<string>(
                name: "NomeGenero",
                table: "Generos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Filmes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Plot",
                table: "Filmes",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UltimoNome",
                table: "Diretores",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PrimeiroNome",
                table: "Diretores",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nacionalidade",
                table: "Diretores",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UltimoNome",
                table: "Atores",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PrimeiroNome",
                table: "Atores",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nacionalidade",
                table: "Atores",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
                name: "IX_Generos_NomeGenero",
                table: "Generos",
                column: "NomeGenero",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diretores_Nacionalidade",
                table: "Diretores",
                column: "Nacionalidade",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Atores_Nacionalidade",
                table: "Atores",
                column: "Nacionalidade",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FilmeAtor_FilmeId",
                table: "FilmeAtor",
                column: "FilmeId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmeGenero_Filmes_GeneroId",
                table: "FilmeGenero",
                column: "GeneroId",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmeGenero_Generos_FilmeId",
                table: "FilmeGenero",
                column: "FilmeId",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmeGenero_Filmes_GeneroId",
                table: "FilmeGenero");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmeGenero_Generos_FilmeId",
                table: "FilmeGenero");

            migrationBuilder.DropTable(
                name: "FilmeAtor");

            migrationBuilder.DropIndex(
                name: "IX_Generos_NomeGenero",
                table: "Generos");

            migrationBuilder.DropIndex(
                name: "IX_Diretores_Nacionalidade",
                table: "Diretores");

            migrationBuilder.DropIndex(
                name: "IX_Atores_Nacionalidade",
                table: "Atores");

            migrationBuilder.RenameColumn(
                name: "GeneroId",
                table: "FilmeGenero",
                newName: "GenerosId");

            migrationBuilder.RenameColumn(
                name: "FilmeId",
                table: "FilmeGenero",
                newName: "FilmesId");

            migrationBuilder.RenameIndex(
                name: "IX_FilmeGenero_GeneroId",
                table: "FilmeGenero",
                newName: "IX_FilmeGenero_GenerosId");

            migrationBuilder.AlterColumn<string>(
                name: "NomeGenero",
                table: "Generos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Filmes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Plot",
                table: "Filmes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(400)",
                oldMaxLength: 400);

            migrationBuilder.AlterColumn<string>(
                name: "UltimoNome",
                table: "Diretores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "PrimeiroNome",
                table: "Diretores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Nacionalidade",
                table: "Diretores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "UltimoNome",
                table: "Atores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "PrimeiroNome",
                table: "Atores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Nacionalidade",
                table: "Atores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.CreateTable(
                name: "AtorFilme",
                columns: table => new
                {
                    AtoresId = table.Column<int>(type: "int", nullable: false),
                    FilmesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtorFilme", x => new { x.AtoresId, x.FilmesId });
                    table.ForeignKey(
                        name: "FK_AtorFilme_Atores_AtoresId",
                        column: x => x.AtoresId,
                        principalTable: "Atores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtorFilme_Filmes_FilmesId",
                        column: x => x.FilmesId,
                        principalTable: "Filmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtorFilme_FilmesId",
                table: "AtorFilme",
                column: "FilmesId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmeGenero_Filmes_FilmesId",
                table: "FilmeGenero",
                column: "FilmesId",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmeGenero_Generos_GenerosId",
                table: "FilmeGenero",
                column: "GenerosId",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
