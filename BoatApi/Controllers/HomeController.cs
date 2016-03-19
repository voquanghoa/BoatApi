using System.Web.Mvc;

namespace BoatApi.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Title = "Home Page";
			return View();
		}
	}
}
