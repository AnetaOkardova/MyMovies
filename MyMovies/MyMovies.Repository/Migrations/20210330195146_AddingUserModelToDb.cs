using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMovies.Repository.Migrations
{
    public partial class AddingUserModelToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(maxLength: 50, nullable: false),
                    Username = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
