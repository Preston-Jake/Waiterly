using Microsoft.EntityFrameworkCore.Migrations;

namespace Waiterly.Migrations
{
    public partial class addusertables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "52e4f886-05c5-461c-a751-9c5d8b494176", "AQAAAAEAACcQAAAAELq0NFdENJ0ZxMLdte9sTwQX5qGAWYZ93M2jtWfOlX/GygeXma7+EU9hqdvBqE7QKg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "acd93aa0-b585-417d-8111-51daf7ede1ab", "AQAAAAEAACcQAAAAEAYG3ZuB5k5Zf3Nnc4W47L4LI8y3wtvfY+d/E3qTaFafCGZ1lizp+QHScNJSJzqUjA==" });
        }
    }
}
