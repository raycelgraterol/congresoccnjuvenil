using Microsoft.EntityFrameworkCore.Migrations;

namespace CongresoJuvenil2021.Data.Migrations
{
    public partial class Congregationdatafixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 46,
                column: "Name",
                value: "Barinitas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 46,
                column: "Name",
                value: "");
        }
    }
}
