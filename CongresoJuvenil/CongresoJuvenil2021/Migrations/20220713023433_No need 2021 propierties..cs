using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CongresoJuvenil2021.Migrations
{
    public partial class Noneed2021propierties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PodCasts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PodCasts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PodCasts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PodCasts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "IsReferred",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ReferredBy",
                table: "User");

            migrationBuilder.UpdateData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 107,
                column: "Name",
                value: "Guanare");

            migrationBuilder.UpdateData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "Direction", "Name" },
                values: new object[] { "Otra congregación", "" });

            migrationBuilder.UpdateData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 112,
                column: "Name",
                value: "Ninguna");

            migrationBuilder.UpdateData(
                table: "PodCasts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "TransmissionDate" },
                values: new object[] { "Jueves - Día 1", new DateTime(2022, 8, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "PodCasts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "TransmissionDate" },
                values: new object[] { "Viernes - Día 2", new DateTime(2022, 8, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "PodCasts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "TransmissionDate" },
                values: new object[] { "Sabado - Día 3", new DateTime(2022, 8, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Equipo 1 Guardianes");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Equipo-2 Transformados");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Equipo-3 Trascendentes");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Equipo-4 Titanes");

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Link", "Name" },
                values: new object[,]
                {
                    { 5, "https://t.me/joinchat/cdnPblmq7C0wMzVh", "Equipo-5 Rompetechos" },
                    { 6, "https://t.me/joinchat/cdnPblmq7C0wMzVh", "Equipo-6 Centinelas" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AddColumn<bool>(
                name: "IsReferred",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ReferredBy",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 107,
                column: "Name",
                value: "Ninguna");

            migrationBuilder.UpdateData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "Direction", "Name" },
                values: new object[] { "", "Guanare" });

            migrationBuilder.UpdateData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 112,
                column: "Name",
                value: "Otra congregación");

            migrationBuilder.UpdateData(
                table: "PodCasts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "TransmissionDate" },
                values: new object[] { "Alabanza y adoración", new DateTime(2021, 8, 25, 14, 50, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "PodCasts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "TransmissionDate" },
                values: new object[] { "Vocación, visión, llamado y productividad", new DateTime(2021, 8, 25, 15, 50, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "PodCasts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "TransmissionDate" },
                values: new object[] { "Pandemia de Amor", new DateTime(2021, 8, 25, 16, 50, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "PodCasts",
                columns: new[] { "Id", "Description", "Link", "Name", "TransmissionDate" },
                values: new object[,]
                {
                    { 4, null, "#", "Desenmascarando la ideología de género", new DateTime(2021, 8, 25, 17, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 5, null, "#", "Visión, emprendimiento y libertad financiera", new DateTime(2021, 8, 26, 14, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 6, null, "#", "¿Y cómo funciona esto? Especial para novios", new DateTime(2021, 8, 26, 15, 55, 0, 0, DateTimeKind.Unspecified) },
                    { 7, null, "#", "Porque estar solo, nunca será mejor. Especial para solteros", new DateTime(2021, 8, 26, 16, 55, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "M-1 MOXAGUILAS");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "M-2 Manada Divergente");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "M-3 LEGENDARIOS");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "M-4 JUVENTUD DIVERGENTE");
        }
    }
}
