using System.Runtime.Serialization;

namespace BoatApi.Models.Communication.Request
{
	[DataContract]
	public class AddBoatForm
	{
		[DataMember(Name = "name", IsRequired = true)]
		public string Name
		{
			get; set;
		}

		[DataMember(Name = "imageUrl", IsRequired = true)]
		public string ImageUrl
		{
			get; set;
		}
	}
}