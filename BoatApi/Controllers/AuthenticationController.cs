using BoatApi.Business;
using BoatApi.Controllers.Base;
using BoatApi.Models.Communication.Request;
using System.Web.Http;

namespace BoatApi.Controllers
{
	public class AuthenticationController : BaseController
	{
		public IHttpActionResult Post(LoginForm loginForm)
		{
			if (!authenticationBusiess.Authenticate(loginForm))
			{
				return Unauthorized();
			}

			return Ok();
		}
	}
}