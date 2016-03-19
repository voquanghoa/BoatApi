using BoatApi.Business;
using BoatApi.Controllers.Base;
using BoatApi.Models.Communication.Request;
using BoatApi.Models.ServiceModel;
using System;
using System.Data.Entity.Validation;
using System.Web.Http;

namespace BoatApi.Controllers
{
	public class BoatController : BaseController
	{
		private readonly BoatBusiness boatBusiess;

		public BoatController()
		{
			boatBusiess = new BoatBusiness(UnitOfWork);
		}

		/// <summary>
		/// Get the list of boats
		/// </summary>
		/// <returns>The list of boats</returns>
		public IHttpActionResult Get()
		{
			return ExecuteAction(() => Ok(boatBusiess.GetAll()));
		}

		/// <summary>
		/// Get a boat by a specific id
		/// </summary>
		/// <param name="boatId">The id of boat</param>
		/// <returns>The boat</returns>
		public IHttpActionResult Get(Guid? boatId)
		{
			return ExecuteAction(() => Ok(boatBusiess.GetOne(boatId)));
		}

		/// <summary>
		/// Create a new boat
		/// </summary>
		/// <param name="addBoatForm"></param>
		/// <returns></returns>
		public IHttpActionResult Post([FromBody]AddBoatForm addBoatForm)
		{
			return ExecuteAction(() =>
			{
				return Ok(boatBusiess.CreateOne(addBoatForm));
			});
		}

		/// <summary>
		/// Update an existing boat
		/// </summary>
		/// <param name="boatId"></param>
		/// <param name="updateBoatForm"></param>
		/// <returns></returns>
		public IHttpActionResult Put(Guid? boatId, [FromBody]UpdateBoatForm updateBoatForm)
		{
			return ExecuteAction(() =>
			{
				boatBusiess.Update(boatId, updateBoatForm);
			});
		}

		/// <summary>
		/// Delete an existing boat
		/// </summary>
		/// <param name="boatId"></param>
		/// <returns></returns>
		public IHttpActionResult Delete(Guid? boatId)
		{
			return ExecuteAction(() =>
			{
				boatBusiess.Delete(boatId);
			});
		}
	}
}