using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Popcorn_Box_Backend.Migrations
{
    /// <inheritdoc />
    public partial class usermediarequiredatttributeremoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Users_UserId",
                table: "Medias");

            migrationBuilder.DropIndex(
                name: "IX_Medias_UserId",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Medias");

            migrationBuilder.CreateIndex(
                name: "IX_Medias_ClientId",
                table: "Medias",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Users_ClientId",
                table: "Medias",
                column: "ClientId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Users_ClientId",
                table: "Medias");

            migrationBuilder.DropIndex(
                name: "IX_Medias_ClientId",
                table: "Medias");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Medias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medias_UserId",
                table: "Medias",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Users_UserId",
                table: "Medias",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
