using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EUNOIA.Migrations
{
    /// <inheritdoc />
    public partial class Emotions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emotion_EmotionSessions_SessionId",
                table: "Emotion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Emotion",
                table: "Emotion");

            migrationBuilder.RenameTable(
                name: "Emotion",
                newName: "Emotions");

            migrationBuilder.RenameIndex(
                name: "IX_Emotion_SessionId",
                table: "Emotions",
                newName: "IX_Emotions_SessionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emotions",
                table: "Emotions",
                column: "EmotionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emotions_EmotionSessions_SessionId",
                table: "Emotions",
                column: "SessionId",
                principalTable: "EmotionSessions",
                principalColumn: "SessionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emotions_EmotionSessions_SessionId",
                table: "Emotions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Emotions",
                table: "Emotions");

            migrationBuilder.RenameTable(
                name: "Emotions",
                newName: "Emotion");

            migrationBuilder.RenameIndex(
                name: "IX_Emotions_SessionId",
                table: "Emotion",
                newName: "IX_Emotion_SessionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emotion",
                table: "Emotion",
                column: "EmotionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emotion_EmotionSessions_SessionId",
                table: "Emotion",
                column: "SessionId",
                principalTable: "EmotionSessions",
                principalColumn: "SessionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
