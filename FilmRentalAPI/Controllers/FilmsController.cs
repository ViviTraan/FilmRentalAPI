using FilmRentalAPI.Models;
using FilmRentalAPI.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmRentalAPI.Controllers
{
	[ApiController]
	[Route("films")]
	public class FilmsController : ControllerBase
	{
		private FilmRentalAPIDbContext _filmRentalAPIDbContext;
		public FilmsController(FilmRentalAPIDbContext filmRentalAPIDbContext)
		{
			_filmRentalAPIDbContext = filmRentalAPIDbContext;
		}

		[HttpGet]
		public ActionResult<List<Film>> GetFilm()
		{
			try
			{
				var films = _filmRentalAPIDbContext.Films.ToList();
				return Ok(films);
			}
			catch (Exception ex)
			{
				throw;
			}

		}
		[HttpGet("{filmID:int}")]
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

		[HttpPost]
		public ActionResult<int> AddFilm([FromBody] AddFilmRequest request)
		{
			var film = new Film
			{
				FilmDuration = request.FilmDuration,
				FilmDescription = request.FilmDescription,
				ReleaseYear = request.ReleaseYear,
				FilmRating = request.FilmRating
			};
			_filmRentalAPIDbContext.Films.Add(film);
			_filmRentalAPIDbContext.SaveChanges();
			return Ok(film);
		}

		[HttpDelete("{filmID:int}")]
		public ActionResult DeleteFilm(int filmID)
		{
			var filmToBeDeleted = _filmRentalAPIDbContext.Films.Find(filmID);
			if (filmToBeDeleted == null)
			{
				return BadRequest($"Could not find film with ID {filmID}");
			}
			_filmRentalAPIDbContext.Films.Remove(filmToBeDeleted);
			_filmRentalAPIDbContext.SaveChanges();
			return NoContent();

		}

	}
}
