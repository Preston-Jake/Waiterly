using Microsoft.EntityFrameworkCore.Migrations;

namespace Waiterly.Migrations
{
    public partial class wageRId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RestaurantUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Wages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Wages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eb7748fc-2c5e-41d4-8a88-02d4f6517234", "AQAAAAEAACcQAAAAEMWdyIuhp9K2eV/REtPXvBkCnWFIALIzFasyfY/M9BoczYtd1fJiylSoIQz/47nIpA==" });

            migrationBuilder.CreateIndex(
                name: "IX_Wages_RestaurantId",
                table: "Wages",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wages_Restaurants_RestaurantId",
                table: "Wages",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wages_Restaurants_RestaurantId",
                table: "Wages");

            migrationBuilder.DropIndex(
                name: "IX_Wages_RestaurantId",
                table: "Wages");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Wages");

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Address", "Name", "Phone", "RestaurantUserId" },
                values: new object[] { 1, "111 Test Address", "TestRestaurant", "16155120998", null });

            migrationBuilder.InsertData(
                table: "Wages",
                columns: new[] { "Id", "Dollars", "Hours", "UserId" },
                values: new object[] { 1, 12.5, 10.0, "00000000-ffff-ffff-ffff-ffffffffffff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "52e4f886-05c5-461c-a751-9c5d8b494176", "AQAAAAEAACcQAAAAELq0NFdENJ0ZxMLdte9sTwQX5qGAWYZ93M2jtWfOlX/GygeXma7+EU9hqdvBqE7QKg==" });

            migrationBuilder.InsertData(
                table: "RestaurantUsers",
                columns: new[] { "Id", "RestaurantId", "UserId" },
                values: new object[] { 1, 1, "00000000-ffff-ffff-ffff-ffffffffffff" });
        }
    }
}
