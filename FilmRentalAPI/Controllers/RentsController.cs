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
using Microsoft.EntityFrameworkCore;
using FilmRentalAPI.Requests.JoinRequests;

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

		[HttpGet("List_Of_Rentals")]
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
					CustomerID = rent.CustomerID,
					FilmID = rent.FilmID,
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

		[HttpPatch("Edit_Rental")]
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

		[HttpDelete("Delete_Rental")]

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
