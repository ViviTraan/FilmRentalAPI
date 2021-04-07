using FilmRentalAPI.Configurations;
using FilmRentalAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmRentalAPI
{
	public class FilmRentalAPIDbContext : DbContext
	{
		public FilmRentalAPIDbContext()
		{
		}

		public FilmRentalAPIDbContext(DbContextOptions<FilmRentalAPIDbContext> options) : base(options)
		{

		}

		public DbSet<Film> Films {get; set;}
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Rent> Rents { get; set; }
		public DbSet<Actor> Actors { get; set; }
		


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=DESKTOP-SMG913T;Database=FilmRentalAPIDB;Trusted_Connection=True;");
		}

		//Här använder vi inställningarna ifrån de olika Configurations vi skapar.
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder
				.ApplyConfiguration(new RentConfiguration());

			modelBuilder
				.ApplyConfiguration(new FilmConfiguration());

			modelBuilder
				.ApplyConfiguration(new CustomerConfiguration());

			modelBuilder
				.ApplyConfiguration(new ActorConfiguration());

			
		}

	}
}
