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
	public class RentsController : ControllerBase
	{

		private FilmRentalAPIDbContext _filmRentalAPIDbContext;
		public RentsController(FilmRentalAPIDbContext filmRentalAPIDbContext)
		{
			_filmRentalAPIDbContext = filmRentalAPIDbContext;
		}

		[HttpGet("List_Of_Rentals")]
		public ActionResult<List<Rent>> GetRent()
		{
			var rentsFromDb = _filmRentalAPIDbContext.Rents.ToList();
			var rentResponses = new List<RentResponse>();

			foreach (var rent in rentsFromDb)
			{
				var rentResponse = new RentResponse
				{
					RentalID = rent.RentalID,
					CustomerID = rent.CustomerID,
					FilmID = rent.FilmID,
					RentalDate = rent.RentalDate,
					ReturnDate = rent.ReturnDate
				};
				rentResponses.Add(rentResponse);
			}

			return Ok(rentResponses);
		}

		[HttpGet("Retrieve_Rental_By_ID")]
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

		[HttpGet("Get_Rental_Details_By_ID")]
		public ActionResult<Rent> GetRentalInformation(int rentalID)
		{
			var rent = _filmRentalAPIDbContext
				.Rents
				.Include(x => x.Film)
				.Include(y => y.Customer)
				.FirstOrDefault(x => x.RentalID == rentalID);

			return Ok(rent);
		}


		[HttpPost("Add_Rental")]
		public ActionResult<int> AddRent([FromBody] AddRentRequest request)
		{
			try
			{
				var customer = _filmRentalAPIDbContext.Customers.Find(request.CustomerID);
				var film = _filmRentalAPIDbContext.Films.Find(request.FilmID);
				var rent = new Rent

				{
					Customer = customer,
					Film = film,
					RentalDate = request.RentalDate,
					ReturnDate = request.ReturnDate
				};

				_filmRentalAPIDbContext.Rents.Add(rent);
				_filmRentalAPIDbContext.SaveChanges();

				return Ok(rent);
			}

			catch (Exception ex)
			{
				return NotFound($"MAYDAY MAYDAY SOMETHING WENT SHITSHOW {ex}");
			}
		}

		[HttpPatch("Edit_Rental")]
		public ActionResult<Rent> EditRent(int rentalID, [FromBody] EditRentRequest request)
		{
			try
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

			catch (Exception ex)
			{
				return NotFound($"MAYDAY MAYDAY SOMETHING WENT SHITSHOW {ex}");
			}

		}

		[HttpDelete("Delete_Rental")]

		public ActionResult DeleteRent(int rentalID)
		{
			try
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

			catch (Exception ex)
			{
				return NotFound($"MAYDAY MAYDAY SOMETHING WENT SHITSHOW {ex}");
			}

		}
	}
}
