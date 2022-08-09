using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace onBoard.Migrations
{
    public partial class newDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Date_User_UserID",
                table: "Date");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Date",
                table: "Date");

            migrationBuilder.DropIndex(
                name: "IX_Date_UserID",
                table: "Date");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DateID",
                table: "Date");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Date",
                newName: "HourID");

            migrationBuilder.RenameColumn(
                name: "DateButtonPressed",
                table: "Date",
                newName: "HourPressed");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "User",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "HourID",
                table: "Date",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Date",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Date",
                table: "Date",
                column: "HourID");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Date",
                table: "Date");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Date");

            migrationBuilder.RenameColumn(
                name: "HourPressed",
                table: "Date",
                newName: "DateButtonPressed");

            migrationBuilder.RenameColumn(
                name: "HourID",
                table: "Date",
                newName: "UserID");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Date",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "DateID",
                table: "Date",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Date",
                table: "Date",
                column: "DateID");

            migrationBuilder.CreateIndex(
                name: "IX_Date_UserID",
                table: "Date",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Date_User_UserID",
                table: "Date",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
