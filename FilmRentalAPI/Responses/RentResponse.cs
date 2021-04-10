using System;

namespace FilmRentalAPI.Responses
{
	public class RentResponse
	{

		public int RentalID { get; set; }
		public int CustomerID { get; set; }
		public int FilmID { get; set; }

		public DateTime RentalDate { get; set; }
		public DateTime ReturnDate { get; set; }

	}
}
