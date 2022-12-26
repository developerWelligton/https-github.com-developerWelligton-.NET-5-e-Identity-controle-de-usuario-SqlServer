using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuarioApi.Migrations
{
    public partial class Criandoroleregular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "4d54d5b7-d553-45a3-8dcc-66c045c45424");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99997, "539e0a64-9d3b-4655-b928-cd723ac24ddc", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e010071d-803b-4629-95a5-1b85543ddd0e", "AQAAAAEAACcQAAAAEGVwJLo/vzLAkwpNx964nOCqEWeXoBV8yUx4vTqECb2jO4XgwxE3s4fPV/lbllBLcQ==", "535d501f-9863-4b37-87ed-e0a57e633f99" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "5c7f75cb-f37e-4472-8cce-28ff4515f798");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6313b89f-f554-4193-921a-c0ada5ca98a5", "AQAAAAEAACcQAAAAEP0j3yrchFhr+OHiNwzRGdRE0agqizuhHvILAyrge8aeaSOn9/l1lRgmqjZrC2mYKQ==", "7541c5d3-76a2-4a79-b75f-be0216a86e86" });
        }
    }
}
