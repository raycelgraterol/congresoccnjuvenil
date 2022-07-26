using Microsoft.EntityFrameworkCore.Migrations;

namespace CongresoJuvenil2021.Migrations
{
    public partial class Fixederroranothercongregations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "Direction", "Name" },
                values: new object[] { "", "Otra congregación" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "Direction", "Name" },
                values: new object[] { "Otra congregación", "" });
        }
    }
}
