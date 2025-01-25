using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace papierowyRPG_API.Migrations
{
    /// <inheritdoc />
    public partial class fixed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Games_GameId",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Character_Stats_StatsId",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Character_Users_UserId",
                table: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Skills_StatsId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Items_StatsId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Character_StatsId",
                table: "Character");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Character",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "StatsId",
                table: "Character",
                newName: "StatsID");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Character",
                newName: "GameID");

            migrationBuilder.RenameIndex(
                name: "IX_Character_UserId",
                table: "Character",
                newName: "IX_Character_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Character_GameId",
                table: "Character",
                newName: "IX_Character_GameID");

            migrationBuilder.AddColumn<int>(
                name: "GameMasterID",
                table: "Games",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_StatsId",
                table: "Skills",
                column: "StatsId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_StatsId",
                table: "Items",
                column: "StatsId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_GameMasterID",
                table: "Games",
                column: "GameMasterID");

            migrationBuilder.CreateIndex(
                name: "IX_Character_StatsID",
                table: "Character",
                column: "StatsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Games_GameID",
                table: "Character",
                column: "GameID",
                principalTable: "Games",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Stats_StatsID",
                table: "Character",
                column: "StatsID",
                principalTable: "Stats",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Users_UserID",
                table: "Character",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Users_GameMasterID",
                table: "Games",
                column: "GameMasterID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Games_GameID",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Character_Stats_StatsID",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Character_Users_UserID",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Users_GameMasterID",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Skills_StatsId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Items_StatsId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Games_GameMasterID",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Character_StatsID",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "GameMasterID",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Character",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "StatsID",
                table: "Character",
                newName: "StatsId");

            migrationBuilder.RenameColumn(
                name: "GameID",
                table: "Character",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Character_UserID",
                table: "Character",
                newName: "IX_Character_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Character_GameID",
                table: "Character",
                newName: "IX_Character_GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_StatsId",
                table: "Skills",
                column: "StatsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_StatsId",
                table: "Items",
                column: "StatsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Character_StatsId",
                table: "Character",
                column: "StatsId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Games_GameId",
                table: "Character",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Stats_StatsId",
                table: "Character",
                column: "StatsId",
                principalTable: "Stats",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Users_UserId",
                table: "Character",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
