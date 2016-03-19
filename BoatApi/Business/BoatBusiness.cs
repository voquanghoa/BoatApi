using BoatApi.Business.Logic.Common;
using BoatApi.Models.Communication.Request;
using BoatApi.Models.ServiceModel;
using BoatApi.WebException;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BoatApi.Business
{
	public class BoatBusiness
	{
		private readonly BaseRepository<Boat> boatRepository;

		public BoatBusiness(IUnitOfWork unitOfWork)
		{
			boatRepository = new BaseRepository<Boat>(unitOfWork);
		}

		public IList<Boat> GetAll()
		{	
			return boatRepository.All().ToList();
		}

		public Boat GetOne(Guid? boatId)
		{
			var boat = boatRepository.FindOne(boatId);

			if (boatId == null)
			{
				throw new NotFoundException();
			}

			return boat;
		}

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

		public void Delete(Guid? boatId)
		{
			if (boatRepository.Delete(x => x.Id == boatId) == 0)
			{
				throw new NotFoundException();
			}
		}

		public void Update(Guid? boatId, UpdateBoatForm updateBoatForm)
		{
			var boat = boatRepository.FindOne(x=>x.Id == boatId);
			if (boat != null)
			{
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
			throw new NotFoundException();
		}

	}
}