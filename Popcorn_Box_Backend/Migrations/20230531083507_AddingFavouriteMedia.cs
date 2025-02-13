using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Popcorn_Box_Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddingFavouriteMedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavoriteMedia",
                columns: table => new
                {
                    FavId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MediaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteMedia", x => x.FavId);
                    table.ForeignKey(
                        name: "FK_FavoriteMedia_Medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Medias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FavoriteMedia_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteMedia_MediaId",
                table: "FavoriteMedia",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteMedia_UserId",
                table: "FavoriteMedia",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteMedia");
        }
    }
}
