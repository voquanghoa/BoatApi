using System;
using BoatApi.Models.Communication.Request;
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
		public GoodDTO CreateGoodDTO(Good good)
		{
			return new GoodDTO()
			{
				Id = good.Id,
				ImageUrl = good.ImageUrl,
				Quanlity = good.Quality
			};
		}

		/// <summary>
		/// Create a good object
		/// </summary>
		/// <param name="addGoodForm">The form contains good's information</param>
		/// <returns>The created good object</returns>
		public Good CreateGood(GoodForm addGoodForm)
		{
			return new Good()
			{
				Id = Guid.NewGuid(),
				ImageUrl = addGoodForm.ImageUrl,
				Quality = addGoodForm.Quality
			};
		}
	}
}