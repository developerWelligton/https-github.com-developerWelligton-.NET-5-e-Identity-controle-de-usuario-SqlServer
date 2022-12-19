using Microsoft.EntityFrameworkCore.Migrations;

namespace filmesAPIalura.Migrations
{
    public partial class AdicionandoClassificacaoEtaria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassificacaoEtaria",
                table: "Filmes",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassificacaoEtaria",
                table: "Filmes");
        }
    }
}
