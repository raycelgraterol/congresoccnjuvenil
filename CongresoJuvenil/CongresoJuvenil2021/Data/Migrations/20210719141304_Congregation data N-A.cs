using Microsoft.EntityFrameworkCore.Migrations;

namespace CongresoJuvenil2021.Data.Migrations
{
    public partial class CongregationdataNA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Congregations",
                columns: new[] { "Id", "Direction", "Name" },
                values: new object[] { 107, "", "Ninguna" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 107);
        }
    }
}
