using BoatApi.Business;
using BoatApi.Controllers.Base;
using BoatApi.Models.Communication.Request;
using System.Web;
using System.Web.Http;

namespace BoatApi.Controllers
{
	public class AuthenticationController : BaseController
	{
		public IHttpActionResult Post(LoginForm loginForm)
		{
			if (!authenticationBusiess.Authenticate(loginForm))
			{
				HttpContext.Current.Response.StatusDescription = "Unknown user/password";
				return Unauthorized();
			}

			return Ok();
		}
	}
}