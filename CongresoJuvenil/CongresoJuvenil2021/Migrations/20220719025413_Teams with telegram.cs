using Microsoft.EntityFrameworkCore.Migrations;

namespace CongresoJuvenil2021.Migrations
{
    public partial class Teamswithtelegram : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "Link",
                value: "https://t.me/+lb3zWHUEX_RlZDlh");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                column: "Link",
                value: "https://t.me/+scShTrVhdJ1kMjJh");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                column: "Link",
                value: "https://t.me/+igdFNnHL5k5iMTNh");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 4,
                column: "Link",
                value: "https://t.me/+YFa4bjX2QD43M2Zh");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 5,
                column: "Link",
                value: "https://t.me/+1KPM9wahKmw1NTEx");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 6,
                column: "Link",
                value: "https://t.me/+64zUs09alEg5NzYx");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "Link",
                value: "https://t.me/joinchat/HZegqf-GylxlMWUx");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                column: "Link",
                value: "https://t.me/joinchat/WHUPm1WLCWZjYjAx");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                column: "Link",
                value: "https://t.me/joinchat/BmGdsXc_nUU1OTNh");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 4,
                column: "Link",
                value: "https://t.me/joinchat/cdnPblmq7C0wMzVh");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 5,
                column: "Link",
                value: "https://t.me/joinchat/cdnPblmq7C0wMzVh");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 6,
                column: "Link",
                value: "https://t.me/joinchat/cdnPblmq7C0wMzVh");
        }
    }
}
