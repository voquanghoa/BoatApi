using System;
using System.ComponentModel.DataAnnotations;

namespace BoatApi.Models.ServiceModel.Base
{
	public class BaseModel
	{
		[Key]
		public Guid Id
		{
			get; set;
		}
	}
}