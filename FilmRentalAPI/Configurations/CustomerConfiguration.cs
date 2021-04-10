using FilmRentalAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmRentalAPI.Configurations
{
	public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
	{
		public void Configure(EntityTypeBuilder<Customer> modelBuilder)
		{
			modelBuilder
				.HasKey(customer => customer.CustomerID);
			modelBuilder
				.Property(customer => customer.CustomerID)
				.UseIdentityColumn(63490, 1);
			modelBuilder
				.HasMany(c => c.Rents)
				.WithOne(r => r.Customer)
				.HasForeignKey(x => x.CustomerID);

		}
	}
}
