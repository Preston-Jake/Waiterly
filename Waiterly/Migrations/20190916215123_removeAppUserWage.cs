using Microsoft.EntityFrameworkCore.Migrations;

namespace Waiterly.Migrations
{
    public partial class removeAppUserWage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Wages_WageId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_WageId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WageId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Wages",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "57b6bb04-68a2-4eb5-ad54-ea5208cd5667", "AQAAAAEAACcQAAAAED4M5e1/FvYo6Y2DuBhJB33j6szXbKoV4EkuKWH+KIM/zNtxDi4pPv1Z0279EEDf3Q==" });

            migrationBuilder.CreateIndex(
                name: "IX_Wages_UserId",
                table: "Wages",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wages_AspNetUsers_UserId",
                table: "Wages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wages_AspNetUsers_UserId",
                table: "Wages");

            migrationBuilder.DropIndex(
                name: "IX_Wages_UserId",
                table: "Wages");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Wages",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "WageId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "WageId" },
                values: new object[] { "eb7748fc-2c5e-41d4-8a88-02d4f6517234", "AQAAAAEAACcQAAAAEMWdyIuhp9K2eV/REtPXvBkCnWFIALIzFasyfY/M9BoczYtd1fJiylSoIQz/47nIpA==", 1 });

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
                onDelete: ReferentialAction.Restrict);
        }
    }
}
