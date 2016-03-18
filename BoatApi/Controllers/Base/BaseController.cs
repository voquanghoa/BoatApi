using BoatApi.Business;
using BoatApi.Business.Logic.Common;
using BoatApi.WebException;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace BoatApi.Controllers.Base
{
	public class BaseController : ApiController
	{
		protected readonly IUnitOfWork unitOfWork;
		protected readonly AuthenticationBusiness authenticationBusiess;

		public BaseController()
		{
			unitOfWork = new UnitOfWork();
			authenticationBusiess = new AuthenticationBusiness(unitOfWork);
		}

		protected IHttpActionResult Unauthorized()
		{
			return StatusCode(System.Net.HttpStatusCode.Unauthorized);
		}

		protected IHttpActionResult ExecuteRequest(Action action)
		{
			return ExecuteRequest(() =>
			{
				action();
				return Ok();
			});
		}

		protected IHttpActionResult ExecuteRequest(Func<IHttpActionResult> action)
		{
			if (authenticationBusiess.VerifyAuthenticated())
			{
				try
				{
					return action();
				}
				catch (NotFoundException)
				{
					return NotFound();
				}
				catch (DbEntityValidationException)
				{
					return BadRequest();
				}
			}

			return Unauthorized();
		}
	}
}