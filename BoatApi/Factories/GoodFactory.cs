using BoatApi.Models.Communication.Response;
using BoatApi.Models.ServiceModel;

namespace BoatApi.Factories
{
	/// <summary>
	/// Factory for good
	/// </summary>
	public class GoodFactory
	{
		/// <summary>
		/// Convert a good from the database to a good object DTO
		/// </summary>
		/// <param name="good">The good object from the database</param>
		/// <returns>The good DTO object</returns>
		// ReSharper disable once InconsistentNaming
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