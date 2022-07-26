using Microsoft.EntityFrameworkCore.Migrations;

namespace CongresoJuvenil2021.Migrations
{
    public partial class NewCCN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Congregations",
                columns: new[] { "Id", "Direction", "Name" },
                values: new object[] { 113, "", "Sotillo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 113);
        }
    }
}
