using System.Runtime.Serialization;

namespace BoatApi.Models.Communication.Request
{
	/// <summary>
	/// The form contains boat's information
	/// </summary>
	[DataContract]
	public class BoatForm
	{
		/// <summary>
		/// Boat's name
		/// </summary>
		[DataMember(Name = "name")]
		public string Name
		{
			get; set;
		}

		/// <summary>
		/// Url to the image
		/// </summary>
		[DataMember(Name = "imageUrl")]
		public string ImageUrl
		{
			get; set;
		}
	}
}