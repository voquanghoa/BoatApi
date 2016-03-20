using System;
using BoatApi.Models.ServiceModel.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoatApi.Models.ServiceModel
{
	/// <summary>
	/// Authentication model
	/// </summary>
	[Table("Authentication")]
	public class Authentication : BaseModel
	{
		/// <summary>
		/// The user
		/// </summary>
		[Required]
		public User User
		{
			get; set;
		}

		/// <summary>
		/// The session hash
		/// </summary>
		[Required]
		public Guid SessionHash
		{
			get; set;
		}
	}
}