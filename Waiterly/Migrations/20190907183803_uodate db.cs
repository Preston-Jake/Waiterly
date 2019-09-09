using Microsoft.EntityFrameworkCore.Migrations;

namespace Waiterly.Migrations
{
    public partial class uodatedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "LastName", "RestaurantId", "WageId" },
                values: new object[] { "00000000-ffff-ffff-ffff-ffffffffffff", 0, "cf813189-c41c-4f68-a18c-13cf2a3263df", "ApplicationUser", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEPtSNhfcshHiTMor01pmVaWEIyFBcalmm+zPOTnUBvE3B+A1nWeNsr0Cgbk1hABHrQ==", null, false, "7f434309-a4d9-48e9-9ebb-8803db794577", false, "admin@admin.com", "admin", "admin", 1, 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Type" },
                values: new object[] { 1, "TestFood" });

            migrationBuilder.InsertData(
                table: "RestaurantUsers",
                columns: new[] { "Id", "RestaurantId", "UserId" },
                values: new object[] { 1, 1, "00000000-ffff-ffff-ffff-ffffffffffff" });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Address", "CategoryId", "Name", "Phone" },
                values: new object[] { 1, "111 Test Address", 1, "TestRestaurant", "16155120998" });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "RestaurantId", "Seats", "TableNumber" },
                values: new object[] { 1, 1, 2, 1 });

            migrationBuilder.InsertData(
                table: "UserTables",
                columns: new[] { "Id", "TableId", "UserId" },
                values: new object[] { 1, 1, "00000000-ffff-ffff-ffff-ffffffffffff" });

            migrationBuilder.InsertData(
                table: "Wages",
                columns: new[] { "Id", "Dollars", "Hours", "UserId" },
                values: new object[] { 1, 12.5, 10.0, "00000000-ffff-ffff-ffff-ffffffffffff" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RestaurantUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserTables",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Wages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1", null, "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2", null, "Host", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3", null, "Waiter", null });
        }
    }
}
