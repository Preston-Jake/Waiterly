using Microsoft.EntityFrameworkCore.Migrations;

namespace Waiterly.Migrations
{
    public partial class updateRestaurant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Restaurants",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1c4fe5e8-bbdc-4fb8-89ba-1e5a96ef1150", "AQAAAAEAACcQAAAAEA7gwbNX98v52CI7hwf6fvXCFTahGEnk6KEf1FKe+1bmQqKDpLMeEcNMNpx3ubvJ0g==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Restaurants");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "44a50709-07e9-4729-abc0-9a59cdbb0e61", "AQAAAAEAACcQAAAAECtKgbyCBktOUMiBswy9duno5X5z00/3wC9+etnr6dwMHOjvA8e39dF6m7q3uAkHpQ==" });
        }
    }
}
