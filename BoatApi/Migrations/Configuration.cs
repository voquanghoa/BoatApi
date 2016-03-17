using BoatApi.DataContext;
using System.Data.Entity.Migrations;

namespace BoatApi.Migrations
{
	public class Configuration : DbMigrationsConfiguration<ApplicationDBContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}
	}
}