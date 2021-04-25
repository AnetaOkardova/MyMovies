using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMovies.Repository.Migrations
{
    public partial class RemovedNullableMovieGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_MovieGenres_MovieGenreId",
                table: "Movies");

            migrationBuilder.AlterColumn<int>(
                name: "MovieGenreId",
                table: "Movies",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_MovieGenres_MovieGenreId",
                table: "Movies",
                column: "MovieGenreId",
                principalTable: "MovieGenres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_MovieGenres_MovieGenreId",
                table: "Movies");

            migrationBuilder.AlterColumn<int>(
                name: "MovieGenreId",
                table: "Movies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_MovieGenres_MovieGenreId",
                table: "Movies",
                column: "MovieGenreId",
                principalTable: "MovieGenres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
