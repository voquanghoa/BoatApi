using BoatApi.Business;
using BoatApi.Controllers.Base;
using BoatApi.Models.Communication.Request;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BoatApi.Controllers
{
	public class AuthenticationController : BaseController
	{
		/// <summary>
		/// Login with email/password, both email and password will be stored in server. Can be changed this behavior.
		/// We allow multiple login with an account
		/// </summary>
		/// <param name="loginForm">Login form, with email/password</param>
		/// <returns>The response</returns>
		public IHttpActionResult Post(LoginForm loginForm)
		{
			if (!AuthenticationBusiess.Authenticate(loginForm))
			{
				var msg = new HttpResponseMessage(HttpStatusCode.Unauthorized)
				{
					ReasonPhrase = "Unknown user/password"
				};
				throw new HttpResponseException(msg);
			}

			return Ok();
		}

		/// <summary>
		/// Logout
		/// </summary>
		/// <returns>The response</returns>
		public IHttpActionResult Delete()
		{
			return ExecuteAction(() =>
			{
				AuthenticationBusiess.Logout();
			});
		}
	}
}