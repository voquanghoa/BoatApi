using BoatApi.DataContext;
using System.Data.Entity.Migrations;

namespace BoatApi.Migrations
{
	/// <summary>
	/// The configuration for entity framework
	/// </summary>
	public class Configuration : DbMigrationsConfiguration<ApplicationDBContext>
	{
		/// <summary>
		/// The empty contructor
		/// </summary>
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}
	}
}