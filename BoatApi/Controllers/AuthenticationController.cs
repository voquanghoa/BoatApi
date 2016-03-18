using BoatApi.Business;
using BoatApi.Controllers.Base;
using BoatApi.Models.Communication.Request;
using BoatApi.Models.ServiceModel;
using BoatApi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BoatApi.Controllers
{
	public class AuthenticationController : BaseController
	{
		private readonly AuthenticationBusiness authenticationBusiess;

		public AuthenticationController()
		{
			authenticationBusiess = new AuthenticationBusiness(unitOfWork);
		}

		public void Post(LoginForm loginForm)
		{
			authenticationBusiess.Authenticate(loginForm);
		}
	}
}