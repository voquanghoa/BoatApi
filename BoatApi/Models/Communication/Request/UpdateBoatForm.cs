using System;
using System.Runtime.Serialization;

namespace BoatApi.Models.Communication.Request
{
	[DataContract]
	public class UpdateBoatForm
	{
		[DataMember(Name = "name", IsRequired = false)]
		public string Name
		{
			get; set;
		}

		[DataMember(Name = "imageUrl", IsRequired = false)]
		public string ImageUrl
		{
			get; set;
		}
	}
}