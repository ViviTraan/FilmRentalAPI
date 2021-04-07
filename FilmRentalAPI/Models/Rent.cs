using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmRentalAPI.Models
{
	public class Rent
	{
		public int RentalID { get; set; }
		public DateTime RentalDate { get; set; }
		public DateTime ReturnDate { get; set; }
		public int FilmID { get; set; }
		public int CustomerID { get; set; }
		public Customer Customer { get; set; }
		public Film Film { get; set; }
	}
}
