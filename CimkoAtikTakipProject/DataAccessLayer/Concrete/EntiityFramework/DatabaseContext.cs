using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer.Concrete.EntiityFramework
{
	public sealed partial class DatabaseContext : DbContext
	{
		public DatabaseContext()
		{

		}
		public DatabaseContext(DbContextOptions<DbContext> options) : base(options)
		{

		}
		public DbSet<City> City { get; set; }
		public DbSet<District> District { get; set; }
		public DbSet<Factory> Factory { get; set; }
		public DbSet<User> User { get; set; }
		public DbSet<WasteCode> WasteCode { get; set; }
		public DbSet<WasteForm> WasteForm { get; set; }
		public DbSet<WasteFormImage> WasteFormImage { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			Microsoft.Extensions.Configuration.IConfigurationRoot configuration = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
				.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
				.AddJsonFile("appsettings.json")
				.Build();
			optionsBuilder.UseSqlServer(configuration.GetConnectionString("SqlServer"));
		}
	}
}
