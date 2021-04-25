using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMovies.Repository.Migrations
{
    public partial class AddedMovieGenreModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieGenreId",
                table: "Movies",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MovieGenres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenres", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_MovieGenreId",
                table: "Movies",
                column: "MovieGenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_MovieGenres_MovieGenreId",
                table: "Movies",
                column: "MovieGenreId",
                principalTable: "MovieGenres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_MovieGenres_MovieGenreId",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "MovieGenres");

            migrationBuilder.DropIndex(
                name: "IX_Movies_MovieGenreId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "MovieGenreId",
                table: "Movies");
        }
    }
}
