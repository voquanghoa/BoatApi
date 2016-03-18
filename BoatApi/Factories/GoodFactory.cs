using BoatApi.Models.Communication.Response;
using BoatApi.Models.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoatApi.Factories
{
	public class GoodFactory
	{
		public GoodDTO CreateGoodDTO(Good good)
		{
			return new GoodDTO()
			{
				Id = good.Id,
				ImageUrl = good.ImageUrl,
				Quanlity = (int)good.Quality
			};
		}
	}
}