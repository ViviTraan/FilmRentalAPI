using FilmRentalAPI.Requests.EditRequests;
using FilmRentalAPI.Models;
using FilmRentalAPI.Requests;
using FilmRentalAPI.Requests.AddRequests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmRentalAPI.Responses;

namespace FilmRentalAPI.Controllers
{
	[ApiController]
	[Route("")]
	public class RentsController : ControllerBase
	{

		private FilmRentalAPIDbContext _filmRentalAPIDbContext;

		public RentsController(FilmRentalAPIDbContext filmRentalAPIDbContext)
		{
			_filmRentalAPIDbContext = filmRentalAPIDbContext;
		}

		[HttpGet("A List with all Rental Details")]
		//Hämta en lista på alla uthyrningsinfo
		public ActionResult<List<Rent>> GetRent()
		{
			var rentsFromDb = _filmRentalAPIDbContext.Rents.ToList();
			var rentResponses = new List<RentResponse>();

			foreach (var rent in rentsFromDb)
			{
				var rentResponse = new RentResponse
				{
					RentalID = rent.RentalID,
					RentalDate = rent.RentalDate,
					ReturnDate = rent.ReturnDate
				};
				rentResponses.Add(rentResponse);
			}

			return Ok(rentResponses);
			
			/*try
			{
				var rents = _filmRentalAPIDbContext.Rents.ToList();
				return Ok(rents);
			}
			catch (Exception ex)
			{
				throw;
			}*/
		}

		//Hämtar infon för utvalt ID
		[HttpGet("Retrieve Rental Details from Specific ID")]
		public ActionResult<Rent> GetRent(int rentalID)
		{
			var rent = _filmRentalAPIDbContext
				.Rents
				.FirstOrDefault(x => x.RentalID == rentalID);

			if (rent == null)
			{
				return NotFound($"Could not find info on ID {rentalID}");
			}
			return Ok(rent);
		}

		[HttpPost("Add Rental Details")]
		public ActionResult<int> AddRent([FromBody] AddRentRequest request)
		{
			var rent = new Rent
			{
				RentalDate = request.RentalDate,
				ReturnDate = request.ReturnDate
			};

			_filmRentalAPIDbContext.Rents.Add(rent);
			_filmRentalAPIDbContext.SaveChanges();

			return Ok(rent);
		}

		[HttpPatch("Edit Rental Details")]
		public ActionResult<Rent> EditRent(int rentalID, [FromBody] EditRentRequest request)
		{
			var rentToEdit = _filmRentalAPIDbContext.Rents.Find(rentalID);
			if (request.RentalDate < request.ReturnDate)
			{
				rentToEdit.RentalDate = request.RentalDate;
				rentToEdit.ReturnDate = request.ReturnDate;

				_filmRentalAPIDbContext.Rents.Update(rentToEdit);
				_filmRentalAPIDbContext.SaveChanges();

			}

			return rentToEdit;
		
		}

		[HttpDelete("Delete Rental Details")]

		public ActionResult DeleteRent(int rentalID)
		{
			var rentToBeDeleted = _filmRentalAPIDbContext.Rents.Find(rentalID);
			if (rentToBeDeleted == null)
			{
				return BadRequest($"Could not get info on rentalID {rentalID}");
			}
			_filmRentalAPIDbContext.Rents.Remove(rentToBeDeleted);
			_filmRentalAPIDbContext.SaveChanges();

			return Ok($"You have now deleted ID:{rentalID}");


		}
	}
}
