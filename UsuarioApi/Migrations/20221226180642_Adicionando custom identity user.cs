using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuarioApi.Migrations
{
    public partial class Adicionandocustomidentityuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "ee773404-27b8-4c57-a372-0c35fd10f49f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "eafc9d57-da92-4ddc-b242-20e5505e308c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f000de04-0777-49f8-86e0-9896b6f08750", "AQAAAAEAACcQAAAAEA+WGogQBfz/BgkpclvvKXL8WctkMGCpqxMTyXRLUVJvjRsLmM+L1/l+tlT9vIn9Ow==", "ce489f97-be80-4380-8c25-6fbfc37c8606" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "539e0a64-9d3b-4655-b928-cd723ac24ddc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "4d54d5b7-d553-45a3-8dcc-66c045c45424");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e010071d-803b-4629-95a5-1b85543ddd0e", "AQAAAAEAACcQAAAAEGVwJLo/vzLAkwpNx964nOCqEWeXoBV8yUx4vTqECb2jO4XgwxE3s4fPV/lbllBLcQ==", "535d501f-9863-4b37-87ed-e0a57e633f99" });
        }
    }
}
