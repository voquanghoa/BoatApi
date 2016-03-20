using BoatApi.Models.ServiceModel.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoatApi.Models.ServiceModel
{
	/// <summary>
	/// The User model
	/// </summary>
	[Table("User")]
	public class User : BaseModel
	{
		/// <summary>
		/// User's fullname
		/// </summary>
		[Required]
		public string Name
		{
			get; set;
		}

		/// <summary>
		/// User's email
		/// </summary>
		[Required]
		public string Email
		{
			get; set;
		}

		/// <summary>
		/// User's password
		/// </summary>
		[Required]
		public string Password
		{
			get; set;
		}
	}
}