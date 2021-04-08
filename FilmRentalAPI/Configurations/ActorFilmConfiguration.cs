using FilmRentalAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmRentalAPI.Configurations
{
	public class ActorFilmConfiguration : IEntityTypeConfiguration<ActorFilm>
	{
		public void Configure(EntityTypeBuilder<ActorFilm> modelBuilder)
		{
			modelBuilder
				.HasKey(f => new {f.Film.FilmID, f.Actor.ActorID });
			modelBuilder
				.HasOne(x => x.Actor)
				.WithMany(af => af.ActorFilms);
			modelBuilder
				.HasOne(f => f.Film)
				.WithMany(af => af.ActorFilms);
				
		}
	}
}
