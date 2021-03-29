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
	[Route("customers")]
	public class CustomersController : ControllerBase
	{

		//Skapa en variabel så att du kommer åt din databas som heter "_filmRentalDbContext"
		private FilmRentalAPIDbContext _filmRentalAPIDbContext;

		//Efter raderna nedan har man möjlighet att använda databasen
		public CustomersController(FilmRentalAPIDbContext filmRentalAPIDbContext)
		{
			_filmRentalAPIDbContext = filmRentalAPIDbContext;
		}

		[HttpGet]
		//Hämta en lista men alla customers från databasen 
		public ActionResult<List<Customer>> GetCustomer()
		{
			try
			{
				var customers = _filmRentalAPIDbContext.Customers.ToList();
				return Ok(customers);
			}

			//Logga att något har gått fel, står att den inte används men när man väl debuggar så får man mer information om ett fel uppstår.
			catch (Exception ex)
			{
				throw;
			}

		}

		[HttpGet("{customerID:int}")]

		//Hämtar all information som customerID är kopplad till
		public ActionResult<Customer> GetCustomer(int customerID)
		{
			var customer = _filmRentalAPIDbContext
				  .Customers
				  .FirstOrDefault(x => x.CustomerID == customerID);

			if (customer == null)
			{
				return NotFound($"Could not find customer with id: {customerID}");
			}

			return Ok(customer);
		}

		[HttpPost]
		public ActionResult<int> AddCustomer([FromBody] AddCustomerRequest request)
		{
			var customer = new Customer
			{
				FirstName = request.FirstName,
				LastName = request.LastName,
				PhoneNumber = request.PhoneNumber,
				Email = request.Email,
				Adress = request.Adress
			};

			_filmRentalAPIDbContext.Customers.Add(customer);
			_filmRentalAPIDbContext.SaveChanges();
			return Ok(customer);
		}

		[HttpDelete("{customerID:int}")]
		public ActionResult DeleteCustomer(int customerID)
		{
			var customerToBeDeleted = _filmRentalAPIDbContext.Customers.Find(customerID);
			if (customerToBeDeleted == null)
			{
				return BadRequest($"Could not find customer with Id {customerID}");
			}
			_filmRentalAPIDbContext.Customers.Remove(customerToBeDeleted);
			_filmRentalAPIDbContext.SaveChanges();
			return NoContent();

		}

	}
}
