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
			goodBusiness = new GoodBusiness(unitOfWork);
		}

		public IHttpActionResult Get()
		{
			return ExecuteRequest(() =>
			{
				return Ok(goodBusiness.GetAll());
			});
		}

		[HttpGet]
		[Route("api/good/byboat")]
		public IHttpActionResult GetByBoat(Guid? id)
		{
			return ExecuteRequest(() =>
			{
				return Ok(goodBusiness.GetByBoat(id));
			});
		}
	}
}