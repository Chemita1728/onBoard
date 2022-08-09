using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace onBoard.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Date",
                columns: table => new
                {
                    HourID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HourPressed = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Date", x => x.HourID);
                    table.ForeignKey(
                        name: "FK_Date_User_UserName",
                        column: x => x.UserName,
                        principalTable: "User",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Date_UserName",
                table: "Date",
                column: "UserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Date");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
