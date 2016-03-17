using System;
using System.ComponentModel.DataAnnotations;

namespace BoatApi.Models.Base
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