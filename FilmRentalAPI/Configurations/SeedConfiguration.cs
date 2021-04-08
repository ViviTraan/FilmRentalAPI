namespace FilmRentalAPI.Configurations
{
	using FilmRentalAPI.Models;
	using Microsoft.EntityFrameworkCore;
	using System.Collections.Generic;

	/// <summary>
	/// Defines the <see cref="SeedConfiguration" />.
	/// </summary>
	public static class SeedConfiguration 
	{
		/// <summary>
		/// The Seed.
		/// </summary>
		/// <param name="modelBuilder">The modelBuilder<see cref="ModelBuilder"/>.</param>
		public static ModelBuilder Seed(ModelBuilder modelBuilder)
		{


			var actor1 = new Actor { ActorID = 1, FirstName = "Robert", LastName = "De Niro", DateOfBirth = "1943-08-17", MostPopularFilm = "The Intern" };
			var actor2 = new Actor { ActorID = 2, FirstName = "Ray", LastName = "Liotta", DateOfBirth = "1954-12-18", MostPopularFilm = "GoodFellas" };
			var actor3 = new Actor { ActorID = 3, FirstName = "Viggo", LastName = "Mortensen", DateOfBirth = "1958-10-20", MostPopularFilm = "Lord Of The Rings" };


			var film1 = new Film
				{
					FilmID = 2539,
					FilmTitle = "Goodfellas",
					FilmDescription = "The story of Henry Hill and his life" +
					  " in the mob, covering his relationship with his wife Karen Hill and his mob partners Jimmy Conway and Tommy DeVito in the Italian-American crime syndicate.",
					FilmDuration = "2h 26min",
					ReleaseYear = 1990,
					FilmRating = "8,7/10",
					Actors = new List<Actor> {actor1, actor2 }
				
				};
			//	new Film {
			//		FilmID = 2545,
			//		FilmTitle = "Green Book",
			//		FilmDescription = "A working-class Italian-American bouncer becomes the driver of an African-American classical pianist on a tour of venues through the 1960s American South.",
			//		FilmDuration = "2h 10min",
			//		ReleaseYear = 2018,
			//		FilmRating = "8,2/10",
			//		Actors = new[] {new Actor {ActorID = 3, FirstName = "Viggo", LastName = "Mortensen", DateOfBirth = "1958-10-20", MostPopularFilm = "Lord Of The Rings" } }
			//	} };

			actor1.Films.Add(film1);
			actor2.Films.Add(film1);
			modelBuilder.Entity<Actor>().HasData(actor1, actor2, actor3);
			modelBuilder.Entity<Film>().HasData(film1);
			//modelBuilder.Entity<StudentGrade>().HasData(studentGrades[0], studentGrades[1], studentGrades[2]);


			return modelBuilder;

		}
		}
	}

