using FilmRentalAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
				.WithMany(c => c.Rents);
			modelBuilder
				.HasOne(r => r.Film)
				.WithMany(f => f.Rents);

		}
	}
}
