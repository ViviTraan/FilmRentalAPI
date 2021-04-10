namespace FilmRentalAPI.Requests.EditRequests
{
	public class EditFilmRequest
	{
		public string FilmTitle { get; set; }
		public string FilmDuration { get; set; }
		public string FilmDescription { get; set; }
		public int ReleaseYear { get; set; }
		public string FilmRating { get; set; }
	}
}
