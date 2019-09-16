using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Waiterly.Migrations
{
    public partial class updateusertables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTables_Tables_TableId",
                table: "UserTables");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTables_AspNetUsers_UserId",
                table: "UserTables");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_UserTables_TableId",
                table: "UserTables");

            migrationBuilder.DeleteData(
                table: "UserTables",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "TableId",
                table: "UserTables",
                newName: "TableNumber");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserTables",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "UserTables",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Seats",
                table: "UserTables",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "acd93aa0-b585-417d-8111-51daf7ede1ab", "AQAAAAEAACcQAAAAEAYG3ZuB5k5Zf3Nnc4W47L4LI8y3wtvfY+d/E3qTaFafCGZ1lizp+QHScNJSJzqUjA==" });

            migrationBuilder.CreateIndex(
                name: "IX_UserTables_RestaurantId",
                table: "UserTables",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTables_Restaurants_RestaurantId",
                table: "UserTables",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTables_AspNetUsers_UserId",
                table: "UserTables",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTables_Restaurants_RestaurantId",
                table: "UserTables");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTables_AspNetUsers_UserId",
                table: "UserTables");

            migrationBuilder.DropIndex(
                name: "IX_UserTables_RestaurantId",
                table: "UserTables");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "UserTables");

            migrationBuilder.DropColumn(
                name: "Seats",
                table: "UserTables");

            migrationBuilder.RenameColumn(
                name: "TableNumber",
                table: "UserTables",
                newName: "TableId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserTables",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RestaurantId = table.Column<int>(nullable: false),
                    Seats = table.Column<int>(nullable: false),
                    TableNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tables_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c06d69f4-c9bc-41b2-b1ac-febe6a6d648f", "AQAAAAEAACcQAAAAECaoA1yzGG3VxXoAGcAuoYEJ38fLlv1BRsEijk2DOAy143Fcsu7vz9l4JaXgZ8Bh0w==" });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "RestaurantId", "Seats", "TableNumber" },
                values: new object[] { 1, 1, 2, 1 });

            migrationBuilder.InsertData(
                table: "UserTables",
                columns: new[] { "Id", "TableId", "UserId" },
                values: new object[] { 1, 1, "00000000-ffff-ffff-ffff-ffffffffffff" });

            migrationBuilder.CreateIndex(
                name: "IX_UserTables_TableId",
                table: "UserTables",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_RestaurantId",
                table: "Tables",
                column: "RestaurantId");

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
    }
}
