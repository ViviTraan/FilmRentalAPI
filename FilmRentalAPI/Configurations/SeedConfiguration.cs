namespace FilmRentalAPI.Configurations
{
	using FilmRentalAPI.Models;
	using Microsoft.EntityFrameworkCore;

	/// <summary>
	/// Defines the <see cref="SeedConfiguration" />.
	/// </summary>
	public static class SeedConfiguration
	{
		/// <summary>
		/// The Seed.
		/// </summary>
		/// <param name="modelBuilder">The modelBuilder<see cref="ModelBuilder"/>.</param>
		public static void Seed(ModelBuilder modelBuilder)
		{

			var actors = new[]
			{
					new Actor{ActorID = 1, FirstName = "Robert", LastName = "De Niro", DateOfBirth = "1943-08-17", MostPopularFilm = "The Intern"},
					new Actor { ActorID = 2, FirstName = "Ray", LastName = "Liotta", DateOfBirth = "1954-12-18", MostPopularFilm = "GoodFellas" },
					new Actor{ActorID = 3, FirstName = "Viggo", LastName = "Mortensen", DateOfBirth = "1958-10-20", MostPopularFilm = "Lord Of The Rings" }
			};


			var films = new[]

			{ new Film {
					FilmID = 2539,
					FilmTitle = "Goodfellas",
					FilmDescription = "The story of Henry Hill and his life in the mob, covering his relationship with his wife Karen Hill and his mob partners Jimmy Conway and Tommy DeVito in the Italian-American crime syndicate.",
					FilmDuration = "2h 26min",
					ReleaseYear = 1990,
					FilmRating = "8,7/10",
					
				},
				new Film {
					FilmID = 2545,
					FilmTitle = "Green Book",
					FilmDescription = "A working-class Italian-American bouncer becomes the driver of an African-American classical pianist on a tour of venues through the 1960s American South.",
					FilmDuration = "2h 10min",
					ReleaseYear = 2018,
					FilmRating = "8,2/10"
				}
		};
		}
	}
}
