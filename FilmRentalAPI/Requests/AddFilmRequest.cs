using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmRentalAPI.Requests
{
	public class AddFilmRequest
	{
		public string FilmDuration { get; set; }
		public string FilmDescription { get; set; }
		public int ReleaseYear { get; set; }
		public string FilmRating { get; set; }
	}
}
