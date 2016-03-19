﻿using BoatApi.Business.Logic.Common;
using BoatApi.Models.ServiceModel;

namespace BoatApi.Business.Logic
{
	public class UserRepository: BaseRepository<User>
	{
		public UserRepository(IUnitOfWork unitOfWork):base(unitOfWork)
		{
		}

		public User FindUser(string email, string password)
		{
			return FindOne(x => x.Email == email && x.Password == password);
		}
	}
}