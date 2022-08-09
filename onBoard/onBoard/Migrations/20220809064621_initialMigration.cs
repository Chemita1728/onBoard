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
                name: "Date",
                columns: table => new
                {
                    HourID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HourPressed = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Date", x => x.HourID);
                });

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
                name: "HourUser",
                columns: table => new
                {
                    HoursHourID = table.Column<int>(type: "int", nullable: false),
                    UsersName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HourUser", x => new { x.HoursHourID, x.UsersName });
                    table.ForeignKey(
                        name: "FK_HourUser_Date_HoursHourID",
                        column: x => x.HoursHourID,
                        principalTable: "Date",
                        principalColumn: "HourID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HourUser_User_UsersName",
                        column: x => x.UsersName,
                        principalTable: "User",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HourUser_UsersName",
                table: "HourUser",
                column: "UsersName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HourUser");

            migrationBuilder.DropTable(
                name: "Date");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
