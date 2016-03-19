using BoatApi.Models.Communication.Response;
using BoatApi.Models.ServiceModel;

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