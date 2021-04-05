using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmRentalAPI.Requests.EditRequests
{
	public class EditActorRequest
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string DateOfBirth { get; set; }
		public string MostPopularFilm { get; set; }
	}
}
