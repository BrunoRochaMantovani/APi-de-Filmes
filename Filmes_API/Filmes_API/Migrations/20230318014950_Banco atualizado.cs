using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Filmes_API.Migrations
{
    /// <inheritdoc />
    public partial class Bancoatualizado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Papeis_PapelId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PapelId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PapelId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "UserPapel",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPapel", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserPapel_Papeis_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Papeis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPapel_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPapel_UserId",
                table: "UserPapel",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPapel");

            migrationBuilder.AddColumn<int>(
                name: "PapelId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PapelId",
                table: "Users",
                column: "PapelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Papeis_PapelId",
                table: "Users",
                column: "PapelId",
                principalTable: "Papeis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
