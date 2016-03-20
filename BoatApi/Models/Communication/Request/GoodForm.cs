using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BoatApi.Models.Communication.Request
{
	[DataContract]
	public class GoodForm
	{
		[DataMember(Name = "boatId", IsRequired = true)]
		public Guid BoatId { get; set; }

		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }

		[DataMember(Name = "imageUrl", IsRequired = true)]
		public string ImageUrl { get; set; }

		[DataMember(Name = "quality", IsRequired = true)]
		public int Quality {get; set; }
	}
}