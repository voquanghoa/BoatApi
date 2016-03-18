using BoatApi.Business;
using BoatApi.Business.Logic.Common;
using System;
using System.Collections.Generic;
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

		protected IHttpActionResult RunIfAuthenticated(Func<IHttpActionResult> action)
		{
			if (authenticationBusiess.VerifyAuthenticated())
			{
				return action();
			}

			return Unauthorized();
		}
	}
}