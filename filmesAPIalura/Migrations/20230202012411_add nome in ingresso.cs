using Microsoft.EntityFrameworkCore.Migrations;

namespace filmesAPIalura.Migrations
{
    public partial class addnomeiningresso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Ingressos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Ingressos");
        }
    }
}
