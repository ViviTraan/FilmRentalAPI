using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmRentalAPI.Models
{
	public class Film
	{

		public Film()
		{
			Rents = new List<Rent>();
			ActorFilms = new List<ActorFilm>();
		}

		public int FilmID { get; set; }
		public string FilmTitle { get; set; }
		public string FilmDescription { get; set; }
		public string FilmDuration { get; set; }
		public int ReleaseYear { get; set; }
		public string FilmRating { get; set; }

		public ICollection<Rent> Rents { get; set; }
		public ICollection <ActorFilm> ActorFilms { get; set; }
	}
}
