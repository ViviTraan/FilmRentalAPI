using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmRentalAPI.Requests.EditRequests
{
	public class EditRentRequest
	{	
		public DateTime RentalDate { get; set; }
		public DateTime ReturnDate { get; set; }
	}
}
