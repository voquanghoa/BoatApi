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
			boatBusiess = new BoatBusiness(unitOfWork);
		}

		public IHttpActionResult Get()
		{
			return RunIfAuthenticated(() => Ok(boatBusiess.GetAll()));
		}

		public IHttpActionResult Get(Guid? boatId)
		{
			return RunIfAuthenticated(() => Ok(boatBusiess.GetOne(boatId)));
		}

		public IHttpActionResult Post([FromBody]AddBoatForm boat)
		{
			return RunIfAuthenticated(() =>
			{
				try
				{
					return Ok(boatBusiess.CreateOne(boat));
				}
				catch (DbEntityValidationException)
				{
					return BadRequest();
				}
			});
		}

		public IHttpActionResult Put(Guid? boatId, [FromBody]UpdateBoatForm updateBoatForm)
		{
			return RunIfAuthenticated(() =>
			{
				if (boatBusiess.Update(boatId, updateBoatForm))
				{
					return Ok();
				}
				else
				{
					return NotFound();
				}
			});
		}

		public IHttpActionResult Delete(Guid? boatId)
		{
			return RunIfAuthenticated(() =>
			{
				if (boatBusiess.Delete(boatId))
				{
					return Ok();
				}
				else
				{
					return NotFound();
				}
			});
		}
	}
}