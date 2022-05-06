using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopbridge_base.Migrations
{
    public partial class DataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "Address", "EmailId", "FlagPwdChange", "LastPwdChangeDate", "Mobile", "OfficeFlag", "Pwd", "PwdChangeOTP", "UserName" },
                values: new object[] { 0, "New Raipur Chhattisgarh", "gyan@gmail.com", null, null, "9691655520", "admin", "gyan@123", null, "Gyan" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 0);
        }
    }
}
