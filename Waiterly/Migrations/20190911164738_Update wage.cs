using Microsoft.EntityFrameworkCore.Migrations;

namespace Waiterly.Migrations
{
    public partial class Updatewage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserTables",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "RestaurantUsers",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "aa0fe42d-bb4e-4640-8c82-8dc2f251f75a", "AQAAAAEAACcQAAAAEBH0NK6ClAEJxFI5cvtdsAmh3LjYjs9/XaLVoeEi7OHcarzXrJci73wfavBxnyluBA==" });

            migrationBuilder.CreateIndex(
                name: "IX_UserTables_TableId",
                table: "UserTables",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTables_UserId",
                table: "UserTables",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_RestaurantId",
                table: "Tables",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantUsers_RestaurantId",
                table: "RestaurantUsers",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantUsers_UserId",
                table: "RestaurantUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_WageId",
                table: "AspNetUsers",
                column: "WageId",
                unique: true,
                filter: "[WageId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Wages_WageId",
                table: "AspNetUsers",
                column: "WageId",
                principalTable: "Wages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantUsers_Restaurants_RestaurantId",
                table: "RestaurantUsers",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantUsers_AspNetUsers_UserId",
                table: "RestaurantUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Restaurants_RestaurantId",
                table: "Tables",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTables_Tables_TableId",
                table: "UserTables",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTables_AspNetUsers_UserId",
                table: "UserTables",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Wages_WageId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantUsers_Restaurants_RestaurantId",
                table: "RestaurantUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantUsers_AspNetUsers_UserId",
                table: "RestaurantUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Restaurants_RestaurantId",
                table: "Tables");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTables_Tables_TableId",
                table: "UserTables");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTables_AspNetUsers_UserId",
                table: "UserTables");

            migrationBuilder.DropIndex(
                name: "IX_UserTables_TableId",
                table: "UserTables");

            migrationBuilder.DropIndex(
                name: "IX_UserTables_UserId",
                table: "UserTables");

            migrationBuilder.DropIndex(
                name: "IX_Tables_RestaurantId",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantUsers_RestaurantId",
                table: "RestaurantUsers");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantUsers_UserId",
                table: "RestaurantUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_WageId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserTables",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "RestaurantUsers",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "aae7bac8-6adb-4536-b79a-9c4b565cbe1a", "AQAAAAEAACcQAAAAEJSZvxkqAW5Xd/PSruvHdbTvt6rWWpJSuD1pJOgGoD0U23oD8gtkGbUTZQhV1qDJgw==" });
        }
    }
}
