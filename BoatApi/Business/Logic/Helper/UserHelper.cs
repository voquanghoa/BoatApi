using BoatApi.Business.Logic.Common;
using BoatApi.Models;

namespace BoatApi.Business.Logic.Helper
{
	public class UserHelper : BaseRepository<User>
	{
		public UserHelper(IUnitOfWork unit)
			: base(unit)
		{
		}
	}
}