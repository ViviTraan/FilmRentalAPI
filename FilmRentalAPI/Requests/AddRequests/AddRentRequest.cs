﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmRentalAPI.Requests.AddRequests
{
	public class AddRentRequest
	{
		
		//public int RentalID { get; set; }
		public int CustomerID { get; set; }
		public int FilmID { get; set; }
		public DateTime RentalDate { get; set; }
		public DateTime ReturnDate { get; set; }
	}
}
