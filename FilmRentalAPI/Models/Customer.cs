using System.Collections.Generic;

namespace FilmRentalAPI.Models
{
	public class Customer
	{
		public Customer()
		{
			Rents = new List<Rent>();
		}
		public int CustomerID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public string Adress { get; set; }
		public ICollection<Rent> Rents { get; set; }
	}
}
