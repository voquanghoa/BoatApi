using BoatApi.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BoatApi.DataContext
{
	public class ApplicationDBContext : DbContext
	{
		public DbSet<User> Users
		{
			set; get;
		}

		public ApplicationDBContext() : base("DefaultConnection")
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
			base.OnModelCreating(modelBuilder);
		}
	}
}