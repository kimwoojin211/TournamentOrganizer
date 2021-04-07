using Microsoft.EntityFrameworkCore.Migrations;

namespace TournamentOrganizer.Migrations.User
{
    public partial class fix9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchUsers_Match_MatchId",
                table: "MatchUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchUsers_Users_UserId",
                table: "MatchUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentUsers_Tournament_TournamentId",
                table: "TournamentUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentUsers_Users_UserId",
                table: "TournamentUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TournamentUsers",
                table: "TournamentUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MatchUsers",
                table: "MatchUsers");

            migrationBuilder.RenameTable(
                name: "TournamentUsers",
                newName: "TournamentUser");

            migrationBuilder.RenameTable(
                name: "MatchUsers",
                newName: "MatchUser");

            migrationBuilder.RenameIndex(
                name: "IX_TournamentUsers_UserId",
                table: "TournamentUser",
                newName: "IX_TournamentUser_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TournamentUsers_TournamentId",
                table: "TournamentUser",
                newName: "IX_TournamentUser_TournamentId");

            migrationBuilder.RenameIndex(
                name: "IX_MatchUsers_UserId",
                table: "MatchUser",
                newName: "IX_MatchUser_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_MatchUsers_MatchId",
                table: "MatchUser",
                newName: "IX_MatchUser_MatchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TournamentUser",
                table: "TournamentUser",
                column: "TournamentUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MatchUser",
                table: "MatchUser",
                column: "MatchUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_TournamentId",
                table: "Match",
                column: "TournamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Tournament_TournamentId",
                table: "Match",
                column: "TournamentId",
                principalTable: "Tournament",
                principalColumn: "TournamentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchUser_Match_MatchId",
                table: "MatchUser",
                column: "MatchId",
                principalTable: "Match",
                principalColumn: "MatchId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchUser_Users_UserId",
                table: "MatchUser",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentUser_Tournament_TournamentId",
                table: "TournamentUser",
                column: "TournamentId",
                principalTable: "Tournament",
                principalColumn: "TournamentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentUser_Users_UserId",
                table: "TournamentUser",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_Tournament_TournamentId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchUser_Match_MatchId",
                table: "MatchUser");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchUser_Users_UserId",
                table: "MatchUser");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentUser_Tournament_TournamentId",
                table: "TournamentUser");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentUser_Users_UserId",
                table: "TournamentUser");

            migrationBuilder.DropIndex(
                name: "IX_Match_TournamentId",
                table: "Match");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TournamentUser",
                table: "TournamentUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MatchUser",
                table: "MatchUser");

            migrationBuilder.RenameTable(
                name: "TournamentUser",
                newName: "TournamentUsers");

            migrationBuilder.RenameTable(
                name: "MatchUser",
                newName: "MatchUsers");

            migrationBuilder.RenameIndex(
                name: "IX_TournamentUser_UserId",
                table: "TournamentUsers",
                newName: "IX_TournamentUsers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TournamentUser_TournamentId",
                table: "TournamentUsers",
                newName: "IX_TournamentUsers_TournamentId");

            migrationBuilder.RenameIndex(
                name: "IX_MatchUser_UserId",
                table: "MatchUsers",
                newName: "IX_MatchUsers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_MatchUser_MatchId",
                table: "MatchUsers",
                newName: "IX_MatchUsers_MatchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TournamentUsers",
                table: "TournamentUsers",
                column: "TournamentUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MatchUsers",
                table: "MatchUsers",
                column: "MatchUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchUsers_Match_MatchId",
                table: "MatchUsers",
                column: "MatchId",
                principalTable: "Match",
                principalColumn: "MatchId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchUsers_Users_UserId",
                table: "MatchUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentUsers_Tournament_TournamentId",
                table: "TournamentUsers",
                column: "TournamentId",
                principalTable: "Tournament",
                principalColumn: "TournamentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentUsers_Users_UserId",
                table: "TournamentUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
