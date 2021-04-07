using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TournamentOrganizer.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "TournamentId", "Category", "Location", "Name", "OrganizedBy", "Time" },
                values: new object[] { 1, "Game", "West Coast", "test1", "JoJo OntheRadio", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "MatchId", "Category", "Format", "Score", "TournamentId" },
                values: new object[] { 1, "Game", "First to 5", "1-1", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 1);
        }
    }
}
