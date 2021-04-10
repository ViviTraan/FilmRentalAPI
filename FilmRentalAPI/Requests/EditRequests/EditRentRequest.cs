using System;

namespace FilmRentalAPI.Requests.EditRequests
{
	public class EditRentRequest
	{
		public DateTime RentalDate { get; set; }
		public DateTime ReturnDate { get; set; }
	}
}
