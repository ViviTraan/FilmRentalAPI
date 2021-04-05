using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmRentalAPI.Requests.AddRequests
{
	public class AddFilmRequest
	{
		public string FilmTitle { get; set; }
		public string FilmDuration { get; set; }
		public string FilmDescription { get; set; }
		public int ReleaseYear { get; set; }
		public string FilmRating { get; set; }
	}
}
