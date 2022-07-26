using Microsoft.EntityFrameworkCore.Migrations;

namespace CongresoJuvenil2021.Migrations
{
    public partial class NewCCN25julio2022agregadascongregaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 36,
                column: "Name",
                value: "Curiepe");

            migrationBuilder.UpdateData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 39,
                column: "Name",
                value: "San Juan de los Morros");

            migrationBuilder.InsertData(
                table: "Congregations",
                columns: new[] { "Id", "Direction", "Name" },
                values: new object[,]
                {
                    { 114, "", "23 de enero" },
                    { 115, "", "Carayaca" },
                    { 116, "", "Caucaguita" },
                    { 117, "", "Santa Lucía" },
                    { 118, "", "Palo Negro" },
                    { 119, "", "Pijiguaos" },
                    { 120, "", "San felix" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.UpdateData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 36,
                column: "Name",
                value: "CT Curiepe");

            migrationBuilder.UpdateData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 39,
                column: "Name",
                value: "Guárico");
        }
    }
}
