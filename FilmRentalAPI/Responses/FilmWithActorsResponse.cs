using System.Collections.Generic;

namespace FilmRentalAPI.Responses
{
	public class FilmWithActorsResponse
	{
		public int FilmID { get; set; }
		public string FilmTitle { get; set; }
		public string FilmDescription { get; set; }
		public string FilmDuration { get; set; }
		public int ReleaseYear { get; set; }
		public string FilmRating { get; set; }

		public ICollection<ActorResponse> Actors { get; set; }
	}
}
