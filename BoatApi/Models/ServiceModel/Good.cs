using BoatApi.Models.ServiceModel.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BoatApi.Models.Common;

namespace BoatApi.Models.ServiceModel
{
	/// <summary>
	/// Good model
	/// </summary>
	[Table("Good")]
	public class Good : BaseModel
	{
		/// <summary>
		/// The boat contains this good
		/// </summary>
		[Required]
		public Boat Boat
		{
			get; set;
		}

		/// <summary>
		/// The quality of good
		/// </summary>
		[Required]
		public Quality Quality
		{
			get; set;
		}

		/// <summary>
		/// Url to the image
		/// </summary>
		public string ImageUrl
		{
			get; set;
		}
	}
}