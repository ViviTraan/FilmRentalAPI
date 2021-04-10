using System.Collections.Generic;

namespace FilmRentalAPI.Models
{
	public class Actor
	{
		public Actor()
		{
			Films = new List<Film>();
		}
		public int ActorID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string DateOfBirth { get; set; }
		public string MostPopularFilm { get; set; }
		public ICollection<Film> Films { get; set; }
	}
}
