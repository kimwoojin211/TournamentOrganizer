using Microsoft.EntityFrameworkCore.Migrations;

namespace TournamentOrganizer.Migrations.User
{
    public partial class Fix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name", "Password", "Region", "Token", "Username" },
                values: new object[] { 2, "joebuddy@budd.com", "Joe Buddy", "test2", "Los Angeles, CA, USA", null, "test2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);
        }
    }
}
