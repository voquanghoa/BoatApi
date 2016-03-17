using BoatApi.Business.Logic.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BoatApi.Controllers.Base
{
	public class BaseController : ApiController
	{
		protected IUnitOfWork unitOfWork;

		public BaseController()
		{
			unitOfWork = new UnitOfWork();
		}
	}
}