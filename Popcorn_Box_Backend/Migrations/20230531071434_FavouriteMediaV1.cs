using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Popcorn_Box_Backend.Migrations
{
    /// <inheritdoc />
    public partial class FavouriteMediaV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavouriteMedia",
                columns: table => new
                {
                    MediaId = table.Column<int>(type: "int", nullable: false),
                    FavId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteMedia", x => x.MediaId);
                    table.ForeignKey(
                        name: "FK_FavouriteMedia_Medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Medias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FavouriteMedia_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteMedia_UserId",
                table: "FavouriteMedia",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavouriteMedia");
        }
    }
}
