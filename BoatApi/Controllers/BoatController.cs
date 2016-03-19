using BoatApi.Business;
using BoatApi.Controllers.Base;
using BoatApi.Models.Communication.Request;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using BoatApi.Models.ServiceModel;

namespace BoatApi.Controllers
{
	/// <summary>
	/// Boat controller
	/// </summary>
	public class BoatController : BaseController
	{
		private readonly BoatBusiness boatBusiess;

		/// <summary>
		/// The empty contructor
		/// </summary>
		public BoatController()
		{
			boatBusiess = new BoatBusiness(UnitOfWork);
		}

		/// <summary>
		/// Get the list of boats
		/// </summary>
		/// <returns>The list of boats</returns>
		[ResponseType(typeof (IEnumerable<Boat>))]
		public IHttpActionResult Get()
		{
			return ExecuteAction(() => Ok(boatBusiess.GetAll()));
		}

		/// <summary>
		/// Get a boat by a specific id
		/// </summary>
		/// <param name="boatId">The id of boat</param>
		/// <returns>The boat</returns>
		[ResponseType(typeof(Boat))]
		public IHttpActionResult Get(Guid? boatId)
		{
			return ExecuteAction(() => Ok(boatBusiess.GetOne(boatId)));
		}

		/// <summary>
		/// Create a new boat
		/// </summary>
		/// <param name="addBoatForm"></param>
		/// <returns></returns>
		[ResponseType(typeof(Guid))]
		public IHttpActionResult Post([FromBody]AddBoatForm addBoatForm)
		{
			return ExecuteAction(() => Ok(boatBusiess.CreateOne(addBoatForm)));
		}

		/// <summary>
		/// Update an existing boat
		/// </summary>
		/// <param name="boatId"></param>
		/// <param name="updateBoatForm"></param>
		/// <returns></returns>
		public IHttpActionResult Put(Guid? boatId, [FromBody]UpdateBoatForm updateBoatForm)
		{
			return ExecuteAction(() => boatBusiess.Update(boatId, updateBoatForm));
		}

		/// <summary>
		/// Delete an existing boat
		/// </summary>
		/// <param name="boatId"></param>
		/// <returns></returns>
		public IHttpActionResult Delete(Guid? boatId)
		{
			return ExecuteAction(() => boatBusiess.Delete(boatId));
		}
	}
}