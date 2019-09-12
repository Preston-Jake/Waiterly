using Microsoft.EntityFrameworkCore.Migrations;

namespace Waiterly.Migrations
{
    public partial class addlisttoRUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantUserId",
                table: "Restaurants",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantUserId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c06d69f4-c9bc-41b2-b1ac-febe6a6d648f", "AQAAAAEAACcQAAAAECaoA1yzGG3VxXoAGcAuoYEJ38fLlv1BRsEijk2DOAy143Fcsu7vz9l4JaXgZ8Bh0w==" });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_RestaurantUserId",
                table: "Restaurants",
                column: "RestaurantUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RestaurantUserId",
                table: "AspNetUsers",
                column: "RestaurantUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_RestaurantUsers_RestaurantUserId",
                table: "AspNetUsers",
                column: "RestaurantUserId",
                principalTable: "RestaurantUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_RestaurantUsers_RestaurantUserId",
                table: "Restaurants",
                column: "RestaurantUserId",
                principalTable: "RestaurantUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_RestaurantUsers_RestaurantUserId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_RestaurantUsers_RestaurantUserId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_RestaurantUserId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RestaurantUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RestaurantUserId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "RestaurantUserId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "17adada3-57bd-4530-a492-f9ade1944c56", "AQAAAAEAACcQAAAAEDwikwkFId7O9t5IUNpQTgMagBYhujMrBHMJMmU9JduR7lI24IA1gS9+NSTL81gbyA==" });
        }
    }
}
