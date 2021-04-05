using FilmRentalAPI.Models;
using FilmRentalAPI.Requests.AddRequests;
using FilmRentalAPI.Requests.EditRequests;
using FilmRentalAPI.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmRentalAPI.Controllers
{
	[ApiController]
	[Route("")]
	public class ActorsController : ControllerBase
	{
		private FilmRentalAPIDbContext _filmRentalDbContext;
		
		public ActorsController(FilmRentalAPIDbContext filmRentalAPIDbContext)
		{
			_filmRentalDbContext = filmRentalAPIDbContext;
		}

		[HttpGet("Get a List of All Actors")]
		public ActionResult<List<Actor>> GetActors()
		{
			var actorsFromDb = _filmRentalDbContext.Actors.ToList();
			var actorResponses = new List<ActorResponse>();

			foreach (var actor in actorsFromDb)
			{
				var actorResponse = new ActorResponse
				{
					ActorID = actor.ActorID,
					FirstName = actor.FirstName,
					LastName = actor.LastName,
					DateOfBirth = actor.DateOfBirth,
					MostPopularFilm = actor.MostPopularFilm
				};

				actorResponses.Add(actorResponse);
			}
			return Ok(actorResponses);
		}

		[HttpGet("Retrieve Actor with Specific ID")]
		public ActionResult<Actor> GetActor(int actorID)
		{
			var actor = _filmRentalDbContext
				.Actors
				.FirstOrDefault(a => a.ActorID == actorID);

			if (actor == null)
			{
				return NotFound($"Could not find actor with id: {actorID}");
			}
			return Ok(actor);
		}

		[HttpPost("Add Actor")]
		public ActionResult<int> AddActor([FromBody] AddActorRequest request)
		{
			var actor = new Actor
			{
				FirstName = request.FirstName,
				LastName = request.LastName,
				DateOfBirth = request.DateOfBirth,
				MostPopularFilm = request.MostPopularFilm
			};

			_filmRentalDbContext.Actors.Add(actor);
			_filmRentalDbContext.SaveChanges();
			return Ok(actor);
		}

		[HttpPatch("Edit Actor Details")]
		public ActionResult<Actor> EditActor(int actorID, [FromBody] EditActorRequest request)
		{
			var actorToEdit = _filmRentalDbContext.Actors.Find(actorID);
			
			if(request.FirstName != null && request.FirstName != "string")
			{
				actorToEdit.FirstName = request.FirstName;
			}
			if (request.LastName != null && request.LastName != "string")
			{
				actorToEdit.LastName = request.LastName;
			}
			if (request.DateOfBirth != null && request.DateOfBirth != "string")
			{
				actorToEdit.DateOfBirth = request.DateOfBirth;
			}
			if (request.MostPopularFilm != null && request.MostPopularFilm != "string")
			{
				actorToEdit.MostPopularFilm = request.MostPopularFilm;
			}

			_filmRentalDbContext.Actors.Update(actorToEdit);
			_filmRentalDbContext.SaveChanges();

			return actorToEdit;
		}
		[HttpDelete("Delete Actor with Specific ID")]
		public ActionResult DeleteActor(int actorID)
		{
			var actorToBeDeleted = _filmRentalDbContext.Actors.Find(actorID);
			if (actorToBeDeleted == null)
			{
				return BadRequest($"Could not find actor with Id {actorID}");
			}
			_filmRentalDbContext.Actors.Remove(actorToBeDeleted);
			_filmRentalDbContext.SaveChanges();
			return Ok($"You have now deleted actor with ID: {actorID}");
		}
	}
}
