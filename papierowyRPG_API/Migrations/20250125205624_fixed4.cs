using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace papierowyRPG_API.Migrations
{
    /// <inheritdoc />
    public partial class fixed4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK_Items_Character_CharacterId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Character_CharacterId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Character_CharacterId",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Character",
                table: "Character");

            migrationBuilder.RenameTable(
                name: "Character",
                newName: "Characters");

            migrationBuilder.RenameIndex(
                name: "IX_Character_UserID",
                table: "Characters",
                newName: "IX_Characters_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Character_StatsID",
                table: "Characters",
                newName: "IX_Characters_StatsID");

            migrationBuilder.RenameIndex(
                name: "IX_Character_GameID",
                table: "Characters",
                newName: "IX_Characters_GameID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Characters",
                table: "Characters",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Games_GameID",
                table: "Characters",
                column: "GameID",
                principalTable: "Games",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Stats_StatsID",
                table: "Characters",
                column: "StatsID",
                principalTable: "Stats",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Users_UserID",
                table: "Characters",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Characters_CharacterId",
                table: "Items",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Characters_CharacterId",
                table: "Notes",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Characters_CharacterId",
                table: "Skills",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Games_GameID",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Stats_StatsID",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Users_UserID",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Characters_CharacterId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Characters_CharacterId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Characters_CharacterId",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Characters",
                table: "Characters");

            migrationBuilder.RenameTable(
                name: "Characters",
                newName: "Character");

            migrationBuilder.RenameIndex(
                name: "IX_Characters_UserID",
                table: "Character",
                newName: "IX_Character_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Characters_StatsID",
                table: "Character",
                newName: "IX_Character_StatsID");

            migrationBuilder.RenameIndex(
                name: "IX_Characters_GameID",
                table: "Character",
                newName: "IX_Character_GameID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Character",
                table: "Character",
                column: "ID");

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
                name: "FK_Items_Character_CharacterId",
                table: "Items",
                column: "CharacterId",
                principalTable: "Character",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Character_CharacterId",
                table: "Notes",
                column: "CharacterId",
                principalTable: "Character",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Character_CharacterId",
                table: "Skills",
                column: "CharacterId",
                principalTable: "Character",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
