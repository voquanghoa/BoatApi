using System;
using BoatApi.Models.ServiceModel.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoatApi.Models.ServiceModel
{
	[Table("Authentication")]
	public class Authentication : BaseModel
	{
		[Required]
		public User User
		{
			get; set;
		}

		[Required]
		public Guid SessionHash
		{
			get; set;
		}
	}
}