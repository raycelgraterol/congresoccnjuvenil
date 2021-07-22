using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CongresoJuvenil2021.Data.Migrations
{
    public partial class AddTestPodCasts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PodCasts",
                columns: new[] { "Id", "Description", "Link", "Name", "TransmissionDate" },
                values: new object[] { 1, null, "https://google.com", "Empresarios", new DateTime(2021, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "PodCasts",
                columns: new[] { "Id", "Description", "Link", "Name", "TransmissionDate" },
                values: new object[] { 2, null, "https://google.com", "Matrimonios", new DateTime(2021, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PodCasts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PodCasts",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
