using BoatApi.Business;
using BoatApi.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using BoatApi.Models.Communication.Request;
using BoatApi.Models.Communication.Response;
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
		[ResponseType(typeof(IEnumerable<GoodDTO>))]
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
		[ResponseType(typeof(IEnumerable<GoodDTO>))]
		public IHttpActionResult GetByBoat(Guid? id)
		{
			return ExecuteAction(() => Ok(goodBusiness.GetByBoat(id)));
		}

		/// <summary>
		/// Create new a good record
		/// </summary>
		/// <param name="addGoodForm">The form contains the good's information</param>
		/// <returns>Guid of the new good</returns>
		[ResponseType(typeof(Guid))]
		public IHttpActionResult Post([FromBody]GoodForm addGoodForm)
		{
			return ExecuteAction(() => Ok(goodBusiness.CreateOne(addGoodForm)));
		}

		/// <summary>
		/// Delete an existing good record
		/// </summary>
		/// <param name="goodId">Id of the good record</param>
		/// <returns>The status code is 200 if success</returns>
		public IHttpActionResult Delete(Guid? goodId)
		{
			return ExecuteAction(() => goodBusiness.Delete(goodId));
		}

		/// <summary>
		/// Update information of an existing Good
		/// </summary>
		/// <param name="goodId">Id of the Good</param>
		/// <param name="updateGoodForm">The form contains Good's information</param>
		/// <returns>The status code is 200 if success</returns>
		public IHttpActionResult Put(Guid? goodId, [FromBody]GoodForm updateGoodForm)
		{
			return ExecuteAction(() => goodBusiness.Update(goodId, updateGoodForm));
		}

		/// <summary>
		/// Get a good by a specific id
		/// </summary>
		/// <param name="goodId">The id of good</param>
		/// <returns>The record found</returns>
		[ResponseType(typeof(GoodDTO))]
		public IHttpActionResult Get(Guid? goodId)
		{
			return ExecuteAction(() => Ok(goodBusiness.GetOne(goodId)));
		}
	}
}