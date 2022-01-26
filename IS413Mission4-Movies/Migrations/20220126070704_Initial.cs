using Microsoft.EntityFrameworkCore.Migrations;

namespace IS413Mission4_Movies.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: false),
                    Director = table.Column<string>(nullable: false),
                    Category = table.Column<string>(nullable: false),
                    Rating = table.Column<string>(nullable: false),
                    Edited = table.Column<bool>(nullable: false),
                    LentTo = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies", x => x.MovieId);
                });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "MovieId", "Category", "Director", "Edited", "LentTo", "Notes", "Rating", "Title" },
                values: new object[] { 1, "Meme", "Andrew Adamson", false, null, null, "PG", "Shrek" });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "MovieId", "Category", "Director", "Edited", "LentTo", "Notes", "Rating", "Title" },
                values: new object[] { 2, "Idk", "Steve Binder", true, null, "Really good movie", "PG", "Star Wars Holiday Special" });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "MovieId", "Category", "Director", "Edited", "LentTo", "Notes", "Rating", "Title" },
                values: new object[] { 3, "Action", "Himself", false, "Fred", "Do not watch under any circumstances", "R", "Big Chungus" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movies");
        }
    }
}
