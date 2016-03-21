using BoatApi.Business.Logic;
using BoatApi.Business.Logic.Common;
using BoatApi.Models.Communication.Request;
using BoatApi.Models.ServiceModel;
using BoatApi.Utils;
using System;
using BoatApi.WebException;

namespace BoatApi.Business
{
	/// <summary>
	/// The business layer class to manage user
	/// </summary>
	public class AuthenticationBusiness
	{
		private const string SessonHashCookieName = "SESSONHASH";

		private readonly UserRepository userRepository;
		private readonly BaseRepository<Authentication> authenticationRepository;

		/// <summary>
		/// Contructor with the unitOfWork
		/// </summary>
		/// <param name="unitOfWork">The object unitOfWork</param>
		public AuthenticationBusiness(IUnitOfWork unitOfWork)
		{
			authenticationRepository = new BaseRepository<Authentication>(unitOfWork);
			userRepository = new UserRepository(unitOfWork);
		}

		/// <summary>
		/// Logout the current logged user
		/// </summary>
		public void Logout()
		{
			var sessonHashCookie = CookieUtil.GetCookie(SessonHashCookieName);
			if (sessonHashCookie != null)
			{
				var sessonGuid = Guid.Parse(sessonHashCookie);
				authenticationRepository.Delete(x => x.SessionHash == sessonGuid);
				CookieUtil.ClearCookie();
			}
		}

		/// <summary>
		/// Authenticate user with email and password in a form
		/// </summary>
		/// <param name="loginForm">The form contains email/password</param>
		public void Authenticate(LoginForm loginForm)
		{
			var user = userRepository.FindUser(loginForm.Email, loginForm.Password);

			if (user == null)
			{
				throw  new RecordNotFoundException();
			}

			var authentication = new Authentication()
			{
				Id = Guid.NewGuid(),
				SessionHash = Guid.NewGuid(),
				User = user
			};

			CookieUtil.SetCookie(SessonHashCookieName, authentication.SessionHash.ToString());
			authenticationRepository.Create(authentication);
		}

		private User GetCurrentLoggedInUser()
		{
			var sessonHashCookie = CookieUtil.GetCookie(SessonHashCookieName);
			if (sessonHashCookie != null)
			{
				var sessonGuid = Guid.Parse(sessonHashCookie);
				var sesson = authenticationRepository.FindOne(x => x.SessionHash == sessonGuid,new []{"User"});
				if (sesson != null)
				{
					return sesson.User;
				}
			}
			return null;
		}

		/// <summary>
		/// Check user logged in or not
		/// </summary>
		/// <returns>true if user logged in, otherwise, return false</returns>
		public bool IsUserLoggedIn()
		{
			return GetCurrentLoggedInUser() != null;
		}
	}
}