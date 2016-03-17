using BoatApi.Business;
using BoatApi.Business.Logic.Common;
using BoatApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BoatApi.Controllers
{
	public class ValuesController : ApiController
	{
		private UserBusiness userBusiness;
		protected IUnitOfWork unitOfWork;

		public ValuesController()
		{
			unitOfWork = new UnitOfWork();
			userBusiness = new UserBusiness(unitOfWork);
		}
		// GET api/values
		public IEnumerable<User> Get()
		{
			return new List<User>()
			{
				new User()
				{
					Id = Guid.NewGuid(),
					UserName= "Vo Quang Hoa",
					Email = "voquanghoa@gmail.com"
				}
			};
		}

		// GET api/values/5
		public string Get(int id)
		{
			return "value";
		}

		// POST api/values
		public void Post([FromBody]string value)
		{
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/values/5
		public void Delete(int id)
		{
		}
	}
}
