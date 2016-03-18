using BoatApi.Models.ServiceModel;
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

		public DbSet<Authentication> Authentications
		{
			set; get;
		}

		public DbSet<Boat> Boats
		{
			set; get;
		}

		public DbSet<Good> Good
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