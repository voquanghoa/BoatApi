using BoatApi.Business;
using BoatApi.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BoatApi.Controllers
{
	public class GoodController : BaseController
	{
		private readonly GoodBusiness goodBusiness;

		public GoodController()
		{
			goodBusiness = new GoodBusiness(UnitOfWork);
		}

		/// <summary>
		/// Get the list of good
		/// </summary>
		/// <returns>The list of good</returns>
		public IHttpActionResult Get()
		{
			return ExecuteAction(() =>
			{
				return Ok(goodBusiness.GetAll());
			});
		}

		/// <summary>
		/// Get the list of good contained in a boat
		/// </summary>
		/// <param name="id">The boat's id</param>
		/// <returns>The list of good contained in a boat</returns>
		[HttpGet]
		[Route("api/good/byboat")]
		public IHttpActionResult GetByBoat(Guid? id)
		{
			return ExecuteAction(() =>
			{
				return Ok(goodBusiness.GetByBoat(id));
			});
		}
	}
}