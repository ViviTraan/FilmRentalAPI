using FilmRentalAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmRentalAPI.Configurations
{
	public class RentConfiguration : IEntityTypeConfiguration<Rent>
	{
		public void Configure(EntityTypeBuilder<Rent> modelBuilder)
		{
			modelBuilder
				.HasKey(rent => rent.RentalID);
			modelBuilder
				.Property(rent => rent.RentalID)
				.UseIdentityColumn(3455, 3);
			modelBuilder
				.HasOne(r => r.Customer)
				.WithMany(c => c.Rents)
				.HasForeignKey(x => x.CustomerID);
			modelBuilder
				.HasOne(r => r.Film)
				.WithMany(f => f.Rents)
				.HasForeignKey(x => x.FilmID);
		}
	}
}
