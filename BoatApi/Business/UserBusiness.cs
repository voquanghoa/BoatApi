using BoatApi.Business.Logic.Common;
using BoatApi.Business.Logic.Helper;
using System;

namespace BoatApi.Business
{
	public class UserBusiness
	{
		private readonly UserHelper userHelper;
		public UserBusiness(IUnitOfWork unitOfWork)
		{
			userHelper = new UserHelper(unitOfWork);
		}
	}
}