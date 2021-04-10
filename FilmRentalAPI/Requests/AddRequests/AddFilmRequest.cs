using System.Collections.Generic;

namespace FilmRentalAPI.Requests.AddRequests
{
	public class AddFilmRequest
	{
		public string FilmTitle { get; set; }
		public string FilmDuration { get; set; }
		public string FilmDescription { get; set; }
		public int ReleaseYear { get; set; }
		public string FilmRating { get; set; }
		public ICollection<int> ActorIDs { get; set; }
	}
}
