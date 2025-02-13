using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Popcorn_Box_Backend.Migrations
{
    /// <inheritdoc />
    public partial class FavouriteTest1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteMedia_Medias_MediaId",
                table: "FavoriteMedia");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteMedia_Medias_MediaId",
                table: "FavoriteMedia",
                column: "MediaId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteMedia_Medias_MediaId",
                table: "FavoriteMedia");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteMedia_Medias_MediaId",
                table: "FavoriteMedia",
                column: "MediaId",
                principalTable: "Medias",
                principalColumn: "Id");
        }
    }
}
