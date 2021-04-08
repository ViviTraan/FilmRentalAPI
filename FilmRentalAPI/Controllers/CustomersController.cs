using FilmRentalAPI.Requests.EditRequests;
using FilmRentalAPI.Models;
using FilmRentalAPI.Requests;
using FilmRentalAPI.Requests.AddRequests;
using FilmRentalAPI.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FilmRentalAPI.Controllers
{
	[ApiController]
	[Route("")]
	public class CustomersController : ControllerBase
	{

		//Skapa en variabel så att du kommer åt din databas som heter "_filmRentalDbContext"
		private FilmRentalAPIDbContext _filmRentalAPIDbContext;

		//Efter raderna nedan har man möjlighet att använda databasen
		public CustomersController(FilmRentalAPIDbContext filmRentalAPIDbContext)
		{
			_filmRentalAPIDbContext = filmRentalAPIDbContext;
		}

		[HttpGet("List_Of_Customers")]
		//Hämta en lista med alla customers från databasen 
		public ActionResult<List<Customer>> GetCustomers()
		{
			var customersFromDb = _filmRentalAPIDbContext.Customers.ToList();
			var customerResponses = new List<CustomerResponse>();

			foreach (var customer in customersFromDb)
			{
				var customerResponse = new CustomerResponse
				{
					CustomerID = customer.CustomerID,
					FirstName = customer.FirstName,
					LastName = customer.LastName,
					PhoneNumber = customer.PhoneNumber,
					Email = customer.Email,
					Adress = customer.Adress
				};
				customerResponses.Add(customerResponse);
			}

			return Ok (customerResponses);

		}

		[HttpGet("Retrieve_Customer_By_ID")]

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

		[HttpGet("Get_Rental_Details_By_CustomerID")]
		public ActionResult<Customer> GetRentalInformation(int customerID)
		{
			var customer = _filmRentalAPIDbContext
				.Customers
				.Include(x => x.Rents)
				.ThenInclude(x => x.Film)
				.FirstOrDefault(x => x.CustomerID == customerID);


			return Ok(customer);

			//var rent = _filmRentalAPIDbContext
			//	.Rents
			//	.Include(x => x.Film)
			//	.Include(y => y.Customer)
			//	.FirstOrDefault(x => x.RentalID == rentalID);

			//return Ok(rent);
		}

		[HttpPost("Add_Customer")]
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

		[HttpPatch("Edit_Customer")]
		public ActionResult<Customer> EditCustomer(int customerID, [FromBody] EditCustomerRequest request)
		{
			var customerToEdit = _filmRentalAPIDbContext.Customers.Find(customerID);
			
			if (request.FirstName != null && request.FirstName != "string")
			{
				customerToEdit.FirstName = request.FirstName;
			}
			if (request.LastName != null && request.LastName != "string")
			{
				customerToEdit.LastName = request.LastName;
			}
			if (request.PhoneNumber != null && request.PhoneNumber != "string")
			{
				customerToEdit.PhoneNumber = request.PhoneNumber;
			}
			if (request.Email != null && request.Email != "string")
			{
				customerToEdit.Email = request.Email;
			}
			if (request.Adress != null && request.Adress != "string")
			{
				customerToEdit.Adress = request.Adress;
			}

			_filmRentalAPIDbContext.Customers.Update(customerToEdit);
			_filmRentalAPIDbContext.SaveChanges();

			return customerToEdit;
		}

		[HttpDelete("Delete_Customer_By_ID")]
		public ActionResult DeleteCustomer(int customerID)
		{
			var customerToBeDeleted = _filmRentalAPIDbContext.Customers.Find(customerID);
			if (customerToBeDeleted == null)
			{
				return BadRequest($"Could not find customer with Id {customerID}");
			}
			_filmRentalAPIDbContext.Customers.Remove(customerToBeDeleted);
			_filmRentalAPIDbContext.SaveChanges();
			return Ok($"You have now deleted customer with ID: {customerID}");

		}

	}
}
