using FilmRentalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmRentalAPI.Requests.JoinRequests
{
	public class RentWithCustomerAndFilmRequest
	{
		public Rent Rent { get; set; }
		public Customer Customer { get; set; }
		public List<Film> Films { get; set; }
	}
}
