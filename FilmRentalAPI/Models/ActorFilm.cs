using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmRentalAPI.Models
{
	public class ActorFilm
	{
		public Actor Actor { get; set; }
		public Film Film { get; set; }
	}
}
