using System;
using System.Collections.Generic;
using System.Linq;
using BoatApi.Business.Logic.Common;
using BoatApi.Factories;
using BoatApi.Models.Communication.Response;
using BoatApi.Models.ServiceModel;
using BoatApi.WebException;

namespace BoatApi.Business
{
	/// <summary>
	/// The business layer class to manage good
	/// </summary>
	public class GoodBusiness
	{
		private readonly GoodFactory goodFactory;

		private readonly BaseRepository<Boat> boatRepository;
		private readonly BaseRepository<Good> goodRepository;

		/// <summary>
		/// Contructor with the unitOfWork
		/// </summary>
		/// <param name="unitOfWork">The object unitOfWork</param>
		public GoodBusiness(IUnitOfWork unitOfWork)
		{
			goodFactory = new GoodFactory();

			boatRepository = new BaseRepository<Boat>(unitOfWork);
			goodRepository = new BaseRepository<Good>(unitOfWork);
		}

		/// <summary>
		/// Get all good
		/// </summary>
		/// <returns>The list of good</returns>
		public IEnumerable<GoodDTO> GetAll()
		{
			var goods = goodRepository.GetAll();
			return goods.Select(x => goodFactory.CreateGoodDTO(x)).ToList();
		}

		/// <summary>
		/// Get all goods contained in a boat
		/// </summary>
		/// <param name="boatId">Id of the boat</param>
		/// <returns>The list of good contained in the boat</returns>
		public IEnumerable<GoodDTO> GetByBoat(Guid? boatId)
		{
			var boat = boatRepository.FindOne(boatId);

			if (boat == null)
			{
				throw new NotFoundException();
			}

			var goods = goodRepository.Filter(x => x.Boat == boat).ToList();

			return goods.Select(x => goodFactory.CreateGoodDTO(x)).ToList();
		}
	}
}