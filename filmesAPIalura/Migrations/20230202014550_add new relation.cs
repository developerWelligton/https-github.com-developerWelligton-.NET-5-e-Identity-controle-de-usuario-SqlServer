using Microsoft.EntityFrameworkCore.Migrations;

namespace filmesAPIalura.Migrations
{
    public partial class addnewrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ingressos_SessaoId",
                table: "Ingressos");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Ingressos");

            migrationBuilder.CreateIndex(
                name: "IX_Ingressos_SessaoId",
                table: "Ingressos",
                column: "SessaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ingressos_SessaoId",
                table: "Ingressos");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Ingressos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingressos_SessaoId",
                table: "Ingressos",
                column: "SessaoId",
                unique: true);
        }
    }
}
