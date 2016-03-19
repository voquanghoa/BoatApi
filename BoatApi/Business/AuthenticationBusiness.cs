using BoatApi.Business.Logic;
using BoatApi.Business.Logic.Common;
using BoatApi.Models.Communication.Request;
using BoatApi.Models.ServiceModel;
using BoatApi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace BoatApi.Business
{
	public class AuthenticationBusiness
	{
		private const string SessonHashCookieName = "SESSONHASH";

		private readonly UserRepository userRepository;
		private readonly BaseRepository<Authentication> authenticationRepository;

		public AuthenticationBusiness(IUnitOfWork unitOfWork)
		{
			authenticationRepository = new BaseRepository<Authentication>(unitOfWork);
			userRepository = new UserRepository(unitOfWork);
		}

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

		public bool Authenticate(LoginForm loginForm)
		{
			var user = userRepository.FindUser(loginForm.Email, loginForm.Password);

			if (user == null)
			{
				return false;
			}

			var authentication = new Authentication()
			{
				Id = Guid.NewGuid(),
				SessionHash = Guid.NewGuid(),
				User = user
			};

			CookieUtil.SetCookie(SessonHashCookieName, authentication.SessionHash.ToString());
			authenticationRepository.Create(authentication);

			return true;
		}

		public bool VerifyAuthenticated()
		{
			var sessonHashCookie = CookieUtil.GetCookie(SessonHashCookieName);
			if (sessonHashCookie != null)
			{
				var sessonGuid = Guid.Parse(sessonHashCookie);
				if (authenticationRepository.Contains(x => x.SessionHash == sessonGuid))
				{
					return true;
				}
			}

			return false;
		}
	}
}