using BoatApi.Models.ServiceModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoatApi.Models.ServiceModel
{
	[Table("Boat")]
	public class Boat : BaseModel
	{
		[Required]
		public string Name
		{
			get; set;
		}

		[Required]
		public string ImageUrl
		{
			get; set;
		}
	}
}