using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopbridge_base.Migrations
{
    public partial class userModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficeFlag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pwd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastPwdChangeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FlagPwdChange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PwdChangeOTP = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
