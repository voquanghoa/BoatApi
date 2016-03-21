using BoatApi.Business.Logic.Common;
using BoatApi.Models.ServiceModel;

namespace BoatApi.Business.Logic
{
	/// <summary>
	/// Repository for users
	/// </summary>
	public class UserRepository: BaseRepository<User>
	{
		/// <summary>
		/// Contructor with UnitOfWork
		/// </summary>
		/// <param name="unitOfWork">UnitOfWork object</param>
		public UserRepository(IUnitOfWork unitOfWork):base(unitOfWork)
		{
		}

		/// <summary>
		/// Find a user has a specific email and password
		/// </summary>
		/// <param name="email">User's email</param>
		/// <param name="password">User's password</param>
		/// <returns></returns>
		public User FindUser(string email, string password)
		{
			return FindOne(x => x.Email == email && x.Password == password);
		}
	}
}