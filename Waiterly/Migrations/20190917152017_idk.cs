using Microsoft.EntityFrameworkCore.Migrations;

namespace Waiterly.Migrations
{
    public partial class idk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "44a50709-07e9-4729-abc0-9a59cdbb0e61", "AQAAAAEAACcQAAAAECtKgbyCBktOUMiBswy9duno5X5z00/3wC9+etnr6dwMHOjvA8e39dF6m7q3uAkHpQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "57b6bb04-68a2-4eb5-ad54-ea5208cd5667", "AQAAAAEAACcQAAAAED4M5e1/FvYo6Y2DuBhJB33j6szXbKoV4EkuKWH+KIM/zNtxDi4pPv1Z0279EEDf3Q==" });
        }
    }
}
