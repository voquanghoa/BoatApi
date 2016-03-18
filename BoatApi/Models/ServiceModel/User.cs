using BoatApi.Models.ServiceModel.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoatApi.Models.ServiceModel
{
	[Table("User")]
	public class User : BaseModel
	{
		[Required]
		public string Name
		{
			get; set;
		}

		[Required]
		public string Email
		{
			get; set;
		}

		[Required]
		public string PasswordHash
		{
			get; set;
		}
	}
}