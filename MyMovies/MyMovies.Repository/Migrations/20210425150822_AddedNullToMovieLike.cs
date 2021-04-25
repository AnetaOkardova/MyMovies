using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMovies.Repository.Migrations
{
    public partial class AddedNullToMovieLike : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieLikes_Movies_MovieId",
                table: "MovieLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieLikes_Users_UserId",
                table: "MovieLikes");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "MovieLikes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "MovieLikes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieLikes_Movies_MovieId",
                table: "MovieLikes",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieLikes_Users_UserId",
                table: "MovieLikes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieLikes_Movies_MovieId",
                table: "MovieLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieLikes_Users_UserId",
                table: "MovieLikes");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "MovieLikes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "MovieLikes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieLikes_Movies_MovieId",
                table: "MovieLikes",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieLikes_Users_UserId",
                table: "MovieLikes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
