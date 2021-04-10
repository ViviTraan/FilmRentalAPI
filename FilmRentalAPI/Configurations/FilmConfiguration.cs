using FilmRentalAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmRentalAPI.Configurations
{
	public class FilmConfiguration : IEntityTypeConfiguration<Film>
	{
		public void Configure(EntityTypeBuilder<Film> modelBuilder)
		{
			modelBuilder
				.HasKey(film => film.FilmID);
			modelBuilder
				.Property(film => film.FilmID)
				.UseIdentityColumn(2539, 6);
			modelBuilder
				.HasMany(f => f.Rents)
				.WithOne(r => r.Film);
			modelBuilder
				.HasMany(f => f.Actors)
				.WithMany(a => a.Films);
		}
	}
}
