using BoatApi.Models.ServiceModel;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BoatApi.DataContext
{
	/// <summary>
	/// Application Database Context class
	/// </summary>
	public class ApplicationDBContext : DbContext
	{
		/// <summary>
		/// Link to Users
		/// </summary>
		public DbSet<User> Users
		{
			set; get;
		}

		/// <summary>
		/// Link to Authentications
		/// </summary>
		public DbSet<Authentication> Authentications
		{
			set; get;
		}

		/// <summary>
		/// Link to Boats
		/// </summary>
		public DbSet<Boat> Boats
		{
			set; get;
		}

		/// <summary>
		/// Link to Goods
		/// </summary>
		public DbSet<Good> Good
		{
			set; get;
		}

		/// <summary>
		/// Empty contructor with Default Connection
		/// </summary>
		public ApplicationDBContext() : base("DefaultConnection")
		{
		}

		/// <summary>
		/// Inherit from base
		/// </summary>
		/// <param name="modelBuilder"></param>
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
			base.OnModelCreating(modelBuilder);
		}
	}
}