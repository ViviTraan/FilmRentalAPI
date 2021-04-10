using FilmRentalAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmRentalAPI.Configurations
{
	public class ActorConfiguration : IEntityTypeConfiguration<Actor>
	{
		public void Configure(EntityTypeBuilder<Actor> modelBuilder)
		{
			modelBuilder
				.HasKey(actor => actor.ActorID);
			modelBuilder
				.Property(actor => actor.ActorID)
				.UseIdentityColumn(1, 1);
			modelBuilder
				.HasMany(a => a.Films)
				.WithMany(f => f.Actors);

		}
	}
}
