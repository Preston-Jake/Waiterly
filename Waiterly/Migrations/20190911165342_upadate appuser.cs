using Microsoft.EntityFrameworkCore.Migrations;

namespace Waiterly.Migrations
{
    public partial class upadateappuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Wages_WageId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "12a12388-1aa8-450f-9d6e-148db5883e9c", "AQAAAAEAACcQAAAAEMLuw3VF5aPzaikGpHVfhxCOsXNgTLo8P2m4j/kZSxUZhNqSPHM2iCMntQmfhlSsng==" });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Wages_WageId",
                table: "AspNetUsers",
                column: "WageId",
                principalTable: "Wages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Wages_WageId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "aa0fe42d-bb4e-4640-8c82-8dc2f251f75a", "AQAAAAEAACcQAAAAEBH0NK6ClAEJxFI5cvtdsAmh3LjYjs9/XaLVoeEi7OHcarzXrJci73wfavBxnyluBA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Wages_WageId",
                table: "AspNetUsers",
                column: "WageId",
                principalTable: "Wages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
