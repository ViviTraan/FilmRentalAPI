using FilmRentalAPI.Models;
using FilmRentalAPI.Requests;
using FilmRentalAPI.Requests.AddRequests;
using FilmRentalAPI.Requests.EditRequests;
using FilmRentalAPI.Requests.ViewAllRequests;
using FilmRentalAPI.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmRentalAPI.Controllers
{
	[ApiController]
	[Route("")]
	public class FilmsController : ControllerBase
	{
		private FilmRentalAPIDbContext _filmRentalAPIDbContext;
		public FilmsController(FilmRentalAPIDbContext filmRentalAPIDbContext)
		{
			_filmRentalAPIDbContext = filmRentalAPIDbContext;
		}

		[HttpGet("Get a List with all Films")]
		public ActionResult<List<Film>> GetFilm()
		{
			var filmsFromDb = _filmRentalAPIDbContext.Films.ToList();
			var filmResponses = new List<FilmResponse>();

			foreach (var film in filmsFromDb)
			{
				var filmResponse = new FilmResponse
				{
					FilmID = film.FilmID,
					FilmTitle = film.FilmTitle,
					FilmDescription = film.FilmDescription,
					FilmDuration = film.FilmDuration,
					ReleaseYear = film.ReleaseYear,
					FilmRating = film.FilmRating
				};
				filmResponses.Add(filmResponse);
			}

			return Ok (filmResponses);

			/*try
			{
				var films = _filmRentalAPIDbContext.Films.ToList();
				return Ok(films);
			}
			catch (Exception ex)
			{
				throw;
			}*/

		}
		[HttpGet("Retrieve Film with Specific ID")]
		public ActionResult<Film> GetFilm(int filmID)
		{
			var film = _filmRentalAPIDbContext
				.Films
				.FirstOrDefault(x => x.FilmID == filmID);

			if (film == null)
			{
				return NotFound($"Could not find film with ID {filmID}");
			}

			return Ok(film);
		}

		//[HttpGet("View actors in Film by ID")]
		//public ActionResult<FilmWithActors> GetFilmWithActorsByID()
		//{
		//	var films = _filmRentalAPIDbContext.Films
		//		.Include(b => b.FilmsActors)
		//		.Where(b => b.FilmsActors.Any(fa => fa.ActorID == ))

			//var filmsWithActors = new FilmWithActors
			//{
			//	ListOfActors = _filmRentalAPIDbContext
			//	.Actors
			//	.ToList(),
			//	Film = _filmRentalAPIDbContext
			//	.Films
			//	.Find(filmID),
			//	ListOfFilmActor = _filmRentalAPIDbContext
			//	.FilmsActors
			//	.ToList()

			//};

			//return Ok(filmsWithActors);
		//}

		[HttpPost("Add Film")]
		public ActionResult<int> AddFilm([FromBody] AddFilmRequest request)
		{
			var film = new Film
			{
				FilmTitle = request.FilmTitle,
				FilmDescription = request.FilmDescription,
				FilmDuration = request.FilmDuration,
				ReleaseYear = request.ReleaseYear,
				FilmRating = request.FilmRating
			};
			_filmRentalAPIDbContext.Films.Add(film);
			_filmRentalAPIDbContext.SaveChanges();
			return Ok(film);
		}

		[HttpPatch("Edit Film Details")]
		public ActionResult<Film> EditFilm (int filmID, [FromBody] EditFilmRequest request)
		{
			var filmToEdit = _filmRentalAPIDbContext.Films.Find(filmID);


			if (request.FilmTitle != null && request.FilmTitle != "string")
			{
				filmToEdit.FilmTitle = request.FilmTitle;
			}
			if (request.FilmDescription != null && request.FilmDescription != "string")
			{
				filmToEdit.FilmDescription = request.FilmDescription;
			}
			if (request.FilmDuration != null && request.FilmDuration != "string")
			{
				filmToEdit.FilmDuration = request.FilmDuration;
			}
			if (request.ReleaseYear != 0)
			{
				filmToEdit.ReleaseYear = request.ReleaseYear;
			}
			if (request.FilmRating != null && request.FilmRating != "string")
			{
				filmToEdit.FilmRating = request.FilmRating;
			}

			_filmRentalAPIDbContext.Films.Update(filmToEdit);
			_filmRentalAPIDbContext.SaveChanges();

			return filmToEdit;
		}



		[HttpDelete("Delete Film with Specific ID")]
		public ActionResult DeleteFilm(int filmID)
		{
			var filmToBeDeleted = _filmRentalAPIDbContext.Films.Find(filmID);
			if (filmToBeDeleted == null)
			{
				return BadRequest($"Could not find film with ID {filmID}");
			}
			_filmRentalAPIDbContext.Films.Remove(filmToBeDeleted);
			_filmRentalAPIDbContext.SaveChanges();
			return Ok($"You have now deleted Film with ID: {filmID}");

		}

	}
}
