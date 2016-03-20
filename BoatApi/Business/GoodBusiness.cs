using System;
using System.Collections.Generic;
using System.Linq;
using BoatApi.Business.Logic.Common;
using BoatApi.Factories;
using BoatApi.Models.Communication.Request;
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

			var goods = goodRepository.Filter(x => x.Boat.Id == boat.Id).ToList();

			return goods.Select(x => goodFactory.CreateGoodDTO(x)).ToList();
		}

		/// <summary>
		/// Create a new Good
		/// </summary>
		/// <param name="addBoatForm">The form contains the new good's information</param>
		/// <returns>Guid of the new good</returns>
		public Guid CreateOne(GoodForm addBoatForm)
		{
			var boat = boatRepository.FindOne(addBoatForm.BoatId);

			if (boat == null)
			{
				throw new NotFoundException();
			}

			var good = goodFactory.CreateGood(addBoatForm);

			good.Boat = boat;

			return goodRepository.Create(good).Id;
		}

		/// <summary>
		/// Delete a good record from database
		/// </summary>
		/// <param name="goodId">id of the good</param>
		public void Delete(Guid? goodId)
		{
			if (goodRepository.Delete(x => x.Id == goodId) == 0)
			{
				throw new NotFoundException();
			}
		}

		/// <summary>
		/// Update information of an existing Good
		/// </summary>
		/// <param name="goodId">The id of good</param>
		/// <param name="goodForm">The form contains good's information</param>
		/// <exception cref="NotFoundException">When we can not found the good or the new boat</exception>
		public void Update(Guid? goodId, GoodForm goodForm)
		{
			var good = goodRepository.FindOne(x => x.Id == goodId, new [] {"Boat"});

			if (good == null)
			{
				throw new NotFoundException();
			}

			good.Quality = (Quality)goodForm.Quality;
			good.ImageUrl = goodForm.ImageUrl;

			if (good.Boat.Id != goodForm.BoatId)
			{
				var newBoat = boatRepository.FindOne(goodForm.BoatId);
				if (newBoat == null)
				{
					throw new NotFoundException();
				}
				good.Boat = newBoat;
			}

			goodRepository.Update(good);
		}

		/// <summary>
		/// Get a good record by id
		/// </summary>
		/// <param name="goodId">Id of the record</param>
		/// <returns>The good record</returns>
		/// <exception cref="NotFoundException">If not found</exception>
		public Good GetOne(Guid? goodId)
		{
			var good = goodRepository.FindOne(goodId);

			if (goodId == null)
			{
				throw new NotFoundException();
			}

			return good;
		}
	}
}