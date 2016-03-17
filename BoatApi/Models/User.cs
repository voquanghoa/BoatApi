using BoatApi.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoatApi.Models
{
	[Table("User")]
	public class User : BaseModel
	{
		[Required]
		public string UserName
		{
			get; set;
		}

		[Required]
		public string Email
		{
			get; set;
		}
	}
}