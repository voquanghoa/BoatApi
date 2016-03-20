using BoatApi.Models.ServiceModel.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoatApi.Models.ServiceModel
{
	/// <summary>
	/// The boat model
	/// </summary>
	[Table("Boat")]
	public class Boat : BaseModel
	{
		/// <summary>
		/// Name of the boat
		/// </summary>
		[Required]
		public string Name
		{
			get; set;
		}

		/// <summary>
		/// Url to the image
		/// </summary>
		[Required]
		public string ImageUrl
		{
			get; set;
		}
	}
}