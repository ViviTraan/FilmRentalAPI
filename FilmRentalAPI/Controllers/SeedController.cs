using FilmRentalAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmRentalAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class SeedController : ControllerBase
	{

		private FilmRentalAPIDbContext _filmRentalAPIDbContext;
		public SeedController(FilmRentalAPIDbContext filmRentalAPIDbContext)
		{
			_filmRentalAPIDbContext = filmRentalAPIDbContext;
		}

		[HttpGet]
		public ActionResult SeedDb()
		{

			var actor1 = new Actor {  FirstName = "Robert", LastName = "De Niro", DateOfBirth = "1943-08-17", MostPopularFilm = "The Intern" };
			var actor2 = new Actor {  FirstName = "Ray", LastName = "Liotta", DateOfBirth = "1954-12-18", MostPopularFilm = "GoodFellas" };
			var actor3 = new Actor {  FirstName = "Viggo", LastName = "Mortensen", DateOfBirth = "1958-10-20", MostPopularFilm = "Lord Of The Rings" };
			var actor4 = new Actor { FirstName = "Mahershala", LastName = "Ali", DateOfBirth = "1974-02-16", MostPopularFilm = "The Hunger Games" };

			var customer1 = new Customer {FirstName = "Vivi", LastName = "Tran", PhoneNumber = "0708852399", Email = "vivitraan3@gmail.com", Adress = "Liedbergs Väg 1A" };
			var customer2 = new Customer {FirstName = "Simba", LastName = "Tran", PhoneNumber = "0701234567", Email = "simba.katt@hotmail.com", Adress = "Kattvägen 3C" };
			


			var film1 = new Film
			{
				
				FilmTitle = "Goodfellas",
				FilmDescription = "The story of Henry Hill and his life" +
					  " in the mob, covering his relationship with his wife Karen Hill and his mob partners Jimmy Conway and Tommy DeVito in the Italian-American crime syndicate.",
				FilmDuration = "2h 26min",
				ReleaseYear = 1990,
				FilmRating = "8,7/10",
				Actors = new List<Actor> { actor1, actor2 }

			};
			
			var film2 = new Film
			{
				
				FilmTitle = "Green Book",
				FilmDescription = "A working-class Italian-American bouncer becomes the driver of an African-American classical pianist on a tour of venues through the 1960s American South.",
				FilmDuration = "2h 10min",
				ReleaseYear = 2018,
				FilmRating = "8,2/10",
				Actors = new List<Actor> { actor3, actor4 }

			};

			var rent1 = new Rent{Customer = customer1, Film = film1, RentalDate = DateTime.Now, ReturnDate = DateTime.Now};
			var rent2 = new Rent {Customer = customer2, Film = film2, RentalDate = DateTime.Now, ReturnDate = DateTime.Now};


			_filmRentalAPIDbContext.Actors.Add(actor1);
			_filmRentalAPIDbContext.Actors.Add(actor2);
			_filmRentalAPIDbContext.Actors.Add(actor3);
			_filmRentalAPIDbContext.Actors.Add(actor4);
			_filmRentalAPIDbContext.Films.Add(film1);
			_filmRentalAPIDbContext.Films.Add(film2);
			_filmRentalAPIDbContext.Customers.Add(customer1);
			_filmRentalAPIDbContext.Rents.Add(rent1);
			_filmRentalAPIDbContext.Rents.Add(rent2);
			_filmRentalAPIDbContext.SaveChanges();

			return Ok();
		}

	}
}
