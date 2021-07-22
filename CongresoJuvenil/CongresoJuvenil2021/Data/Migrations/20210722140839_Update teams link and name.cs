using Microsoft.EntityFrameworkCore.Migrations;

namespace CongresoJuvenil2021.Data.Migrations
{
    public partial class Updateteamslinkandname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Link", "Name" },
                values: new object[] { "https://t.me/joinchat/HZegqf-GylxlMWUx", "M-1 MOXAGUILAS" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Link", "Name" },
                values: new object[] { "https://t.me/joinchat/WHUPm1WLCWZjYjAx", "M-2 Manada Divergente" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Link", "Name" },
                values: new object[] { "https://t.me/joinchat/BmGdsXc_nUU1OTNh", "M-3 LEGENDARIOS" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Link", "Name" },
                values: new object[] { "https://t.me/joinchat/cdnPblmq7C0wMzVh", "M-4 JUVENTUD DIVERGENTE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Link", "Name" },
                values: new object[] { "https://t.me/joinchat/G__8m8vUw8g2ZmJh", "Equipo 1" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Link", "Name" },
                values: new object[] { "https://t.me/joinchat/pUwYBUhKYdg2Njdh", "Equipo 2" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Link", "Name" },
                values: new object[] { "https://t.me/joinchat/FDm8iaeo3JljNTQx", "Equipo 3" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Link", "Name" },
                values: new object[] { "https://t.me/joinchat/YEcjgOYN1OE4Yzg5", "Equipo 4" });
        }
    }
}
