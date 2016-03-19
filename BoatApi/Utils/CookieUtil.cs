using System.Linq;
using System.Web;

namespace BoatApi.Utils
{
	public class CookieUtil
	{
		/// <summary>
		/// Set cookie value for the current request
		/// </summary>
		/// <param name="cookieName">The cookie name</param>
		/// <param name="cookieValue">The cookie value</param>
		public static void SetCookie(string cookieName, string cookieValue)
		{
			HttpCookie cookie = new HttpCookie(cookieName, cookieValue);
			HttpContext.Current.Response.Cookies.Add(cookie);
		}

		/// <summary>
		/// Get the cookie value if presented, otherwise, return null
		/// </summary>
		/// <param name="cookieName">The cookie name</param>
		/// <returns>The value of cookie</returns>
		public static string GetCookie(string cookieName)
		{
			var cookies = HttpContext.Current.Request.Cookies;
			if (cookies.AllKeys.Contains(cookieName))
			{
				return cookies[cookieName].Value;
			}
			return null;
		}

		/// <summary>
		/// Clear cookie for the current request
		/// </summary>
		public static void ClearCookie()
		{
			HttpContext.Current.Request.Cookies.Clear();
		}
	}
}