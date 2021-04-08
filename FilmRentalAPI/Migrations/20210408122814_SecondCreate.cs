using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmRentalAPI.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "ActorID", "DateOfBirth", "FirstName", "LastName", "MostPopularFilm" },
                values: new object[] { 1, "1943-08-17", "Robert", "De Niro", "The Intern" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "ActorID", "DateOfBirth", "FirstName", "LastName", "MostPopularFilm" },
                values: new object[] { 2, "1954-12-18", "Ray", "Liotta", "GoodFellas" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "ActorID", "DateOfBirth", "FirstName", "LastName", "MostPopularFilm" },
                values: new object[] { 3, "1958-10-20", "Viggo", "Mortensen", "Lord Of The Rings" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorID",
                keyValue: 3);
        }
    }
}
