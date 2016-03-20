using System.Runtime.Serialization;

namespace BoatApi.Models.Communication.Request
{
	[DataContract]
	public class BoatForm
	{
		[DataMember(Name = "name")]
		public string Name
		{
			get; set;
		}

		[DataMember(Name = "imageUrl")]
		public string ImageUrl
		{
			get; set;
		}
	}
}