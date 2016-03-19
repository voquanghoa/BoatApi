using BoatApi.Business;
using BoatApi.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using BoatApi.Models.ServiceModel;

namespace BoatApi.Controllers
{
	/// <summary>
	/// Good controller
	/// </summary>
	public class GoodController : BaseController
	{
		private readonly GoodBusiness goodBusiness;

		/// <summary>
		/// The empty controller
		/// </summary>
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
			return ExecuteAction(() => Ok(goodBusiness.GetAll()));
		}

		/// <summary>
		/// Get the list of good contained in a boat
		/// </summary>
		/// <param name="id">The boat's id</param>
		/// <returns>The list of good contained in a boat</returns>
		[HttpGet]
		[Route("api/good/byboat")]
		[ResponseType(typeof(IEnumerable<Good>))]
		public IHttpActionResult GetByBoat(Guid? id)
		{
			return ExecuteAction(() => Ok(goodBusiness.GetByBoat(id)));
		}
	}
}