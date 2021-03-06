using FilmRentalAPI.Models;
using FilmRentalAPI.Requests.AddRequests;
using FilmRentalAPI.Requests.EditRequests;
using FilmRentalAPI.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmRentalAPI.Controllers
{
	[ApiController]
	[Route("controller")]
	public class FilmsController : ControllerBase
	{
		private FilmRentalAPIDbContext _filmRentalAPIDbContext;
		public FilmsController(FilmRentalAPIDbContext filmRentalAPIDbContext)
		{
			_filmRentalAPIDbContext = filmRentalAPIDbContext;
		}

		[HttpGet("List_Of_Films")]
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

			return Ok(filmResponses);

		}
		[HttpGet("Retrieve_Film_By_ID")]
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

		[HttpGet("View_Actors_in_Film_by_ID")]
		public ActionResult<FilmWithActorsResponse> GetFilmWithActorsByID(int ID)
		{
			var film = _filmRentalAPIDbContext.Films.Include(x => x.Actors).FirstOrDefault(x => x.FilmID == ID);
			return Ok(film);
		}

		[HttpPost("Add_Film")]
		public ActionResult<int> AddFilm([FromBody] AddFilmRequest request)
		{
			try
			{
				var actors = _filmRentalAPIDbContext.Actors.Where(x => request.ActorIDs.Contains(x.ActorID));
				var film = new Film
				{
					FilmTitle = request.FilmTitle,
					FilmDescription = request.FilmDescription,
					FilmDuration = request.FilmDuration,
					ReleaseYear = request.ReleaseYear,
					FilmRating = request.FilmRating,
					Actors = actors.ToList()
				};
				_filmRentalAPIDbContext.Films.Add(film);
				_filmRentalAPIDbContext.SaveChanges();
				return Ok(film.FilmID);
			}

			catch (Exception ex)
			{
				return NotFound($"MAYDAY MAYDAY SOMETHING WENT SHITSHOW {ex}");
			}
		}

		[HttpPatch("Edit_Film")]
		public ActionResult<Film> EditFilm(int filmID, [FromBody] EditFilmRequest request)
		{
			try
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

			catch (Exception ex)
			{
				return NotFound($"MAYDAY MAYDAY SOMETHING WENT SHITSHOW {ex}");
			}
		}



		[HttpDelete("Delete_Film")]
		public ActionResult DeleteFilm(int filmID)
		{
			try
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

			catch (Exception ex)
			{
				return NotFound($"MAYDAY MAYDAY SOMETHING WENT SHITSHOW {ex}");
			}

		}

	}
}
