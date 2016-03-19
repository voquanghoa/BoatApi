using BoatApi.Business.Logic.Common;
using BoatApi.Models.Communication.Request;
using BoatApi.Models.ServiceModel;
using BoatApi.WebException;
using System;
using System.Collections.Generic;

namespace BoatApi.Business
{
	/// <summary>
	/// The business layer class to manage boat
	/// </summary>
	public class BoatBusiness
	{
		private readonly BaseRepository<Boat> boatRepository;

		/// <summary>
		/// Contructor with the unitOfWork
		/// </summary>
		/// <param name="unitOfWork">The object unitOfWork</param>
		public BoatBusiness(IUnitOfWork unitOfWork)
		{
			boatRepository = new BaseRepository<Boat>(unitOfWork);
		}

		/// <summary>
		/// Get all boats
		/// </summary>
		/// <returns></returns>
		public IList<Boat> GetAll()
		{
			return boatRepository.GetAll();
		}

		/// <summary>
		/// Find a boat by id
		/// </summary>
		/// <param name="boatId">The boat id</param>
		/// <returns>The boat if found</returns>
		/// <exception cref="NotFoundException">If the databse does not contain any boat with the given id</exception>
		public Boat GetOne(Guid? boatId)
		{
			var boat = boatRepository.FindOne(boatId);

			if (boatId == null)
			{
				throw new NotFoundException();
			}

			return boat;
		}

		/// <summary>
		/// Create a new boat and save to database
		/// </summary>
		/// <param name="addBoatForm">The form contains boat's information</param>
		/// <returns>Id of the new boat</returns>
		public Guid CreateOne(AddBoatForm addBoatForm)
		{
			var newBoat = boatRepository.Create(new Boat()
			{
				Id = Guid.NewGuid(),
				ImageUrl = addBoatForm.ImageUrl,
				Name = addBoatForm.Name
			});

			return newBoat.Id;
		}

		/// <summary>
		/// Delete an existing boat with id
		/// </summary>
		/// <param name="boatId">Id of the boat</param>
		/// <exception cref="NotFoundException">If not found</exception>
		public void Delete(Guid? boatId)
		{
			if (boatRepository.Delete(x => x.Id == boatId) == 0)
			{
				throw new NotFoundException();
			}
		}

		/// <summary>
		/// Update information of an existing boat
		/// </summary>
		/// <param name="boatId">Id of the boat</param>
		/// <param name="updateBoatForm">The form contains boat's information</param>
		/// <exception cref="NotFoundException">If not found</exception>
		public void Update(Guid? boatId, UpdateBoatForm updateBoatForm)
		{
			var boat = boatRepository.FindOne(x=>x.Id == boatId);

			if (boat == null)
			{
				throw new NotFoundException();
			}

			if (!string.IsNullOrEmpty(updateBoatForm.ImageUrl))
			{
				boat.ImageUrl = updateBoatForm.ImageUrl;
			}

			if (!string.IsNullOrEmpty(updateBoatForm.Name))
			{
				boat.Name = updateBoatForm.Name;
			}

			boatRepository.Update(boat);
		}

	}
}