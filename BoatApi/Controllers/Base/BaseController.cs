using BoatApi.Business;
using BoatApi.Business.Logic.Common;
using BoatApi.WebException;
using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Web.Http;

namespace BoatApi.Controllers.Base
{
	/// <summary>
	/// Base controller
	/// </summary>
	public class BaseController : ApiController
	{
		protected readonly IUnitOfWork UnitOfWork;
		protected readonly AuthenticationBusiness AuthenticationBusiess;

		/// <summary>
		/// Default contructor, create unitOfWork and authenticationBusiness
		/// </summary>
		public BaseController()
		{
			UnitOfWork = new UnitOfWork();
			AuthenticationBusiess = new AuthenticationBusiness(UnitOfWork);
		}

		/// <summary>
		/// Execute a specific action
		/// </summary>
		/// <param name="action">The action to be executed</param>
		/// <returns></returns>
		protected IHttpActionResult ExecuteAction(Action action)
		{
			return ExecuteAction(() =>
			{
				action();
				return Ok();
			});
		}

		/// <summary>
		/// Execute a specific action
		/// </summary>
		/// <param name="action">The action to be executed</param>
		/// <returns></returns>
		protected IHttpActionResult ExecuteAction(Func<IHttpActionResult> action)
		{
			if (AuthenticationBusiess.IsUserLoggedIn())
			{
				try
				{
					return action();
				}
				catch (RecordNotFoundException)
				{
					return NotFound();
				}
				catch (DbEntityValidationException)
				{
					return BadRequest();
				}
				catch (DbUpdateException)
				{
					return BadRequest();
				}
			}
			return StatusCode(System.Net.HttpStatusCode.Unauthorized);
		}
	}
}