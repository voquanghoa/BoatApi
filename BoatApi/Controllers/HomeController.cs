using BoatApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

		[HttpGet]
		[Route("getcategory")]
		public User GetCategory()
		{
			return new User()
			{
				Id = Guid.NewGuid(),
				UserName = "123"
			};
		}
	}
}
