using BoatApi.Business.Logic.Common;
using BoatApi.Models.Communication.Request;
using BoatApi.Models.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;

namespace BoatApi.Business
{
	public class BoatBusiness
	{
		private BaseRepository<Boat> boatRepository;


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
			return boatRepository.FindOne(x => boatId == x.Id);
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

		public bool Delete(Guid? boatId)
		{
			return (boatRepository.Delete(x => x.Id == boatId) > 0);
		}

		public bool Update(Guid? boatId, UpdateBoatForm updateBoatForm)
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

				return boatRepository.Update(boat) > 0;
			}
			return false;
		}

	}
}