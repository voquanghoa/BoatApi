using BoatApi.Business;
using BoatApi.Business.Logic.Common;
using BoatApi.Models.ServiceModel;
using BoatApi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace BoatApi.Controllers
{
	public class ValuesController : ApiController
	{
		protected IUnitOfWork unitOfWork;

		public ValuesController()
		{
			unitOfWork = new UnitOfWork();
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
