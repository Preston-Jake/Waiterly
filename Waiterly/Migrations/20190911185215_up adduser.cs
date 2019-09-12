using Microsoft.EntityFrameworkCore.Migrations;

namespace Waiterly.Migrations
{
    public partial class upadduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "17adada3-57bd-4530-a492-f9ade1944c56", "AQAAAAEAACcQAAAAEDwikwkFId7O9t5IUNpQTgMagBYhujMrBHMJMmU9JduR7lI24IA1gS9+NSTL81gbyA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RestaurantId" },
                values: new object[] { "12a12388-1aa8-450f-9d6e-148db5883e9c", "AQAAAAEAACcQAAAAEMLuw3VF5aPzaikGpHVfhxCOsXNgTLo8P2m4j/kZSxUZhNqSPHM2iCMntQmfhlSsng==", 1 });
        }
    }
}
