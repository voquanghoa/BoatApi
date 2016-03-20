using BoatApi.Controllers.Base;
using BoatApi.Models.Communication.Request;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BoatApi.WebException;

namespace BoatApi.Controllers
{
	/// <summary>
	/// Authentication Controller
	/// </summary>
	public class AuthenticationController : BaseController
	{
		/// <summary>
		/// Login with email/password, both email and password will be stored in server.
		/// We allow multiple login with an account
		/// </summary>
		/// <param name="loginForm">Login form, with email/password</param>
		/// <returns>The status code is 200 if success, 401 if failed</returns>
		public IHttpActionResult Post(LoginForm loginForm)
		{
			try
			{
				AuthenticationBusiess.Authenticate(loginForm);
				return Ok();
			}
			catch (NotFoundException)
			{
				var msg = new HttpResponseMessage(HttpStatusCode.Unauthorized)
				{
					ReasonPhrase = "Unknown user/password"
				};
				throw new HttpResponseException(msg);
			}
		}

		/// <summary>
		/// Logout
		/// </summary>
		/// <returns>The status code is 200 if success, 401 if failed</returns>
		public IHttpActionResult Delete()
		{
			return ExecuteAction(() => AuthenticationBusiess.Logout());
		}
	}
}