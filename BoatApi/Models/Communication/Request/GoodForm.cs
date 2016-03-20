using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BoatApi.Models.Communication.Request
{
	/// <summary>
	/// The form contains good's information when we update or create a Good record
	/// </summary>
	[DataContract]
	public class GoodForm
	{
		/// <summary>
		/// Id of the boat contains good
		/// </summary>
		[DataMember(Name = "boatId", IsRequired = true)]
		public Guid BoatId { get; set; }

		/// <summary>
		/// Name of good
		/// </summary>
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }

		/// <summary>
		/// The url to good's photo
		/// </summary>
		[DataMember(Name = "imageUrl", IsRequired = true)]
		public string ImageUrl { get; set; }

		/// <summary>
		/// The quality of good
		/// </summary>
		[Range(-1, 4)]
		[DataMember(Name = "quality", IsRequired = true)]
		public int Quality {get; set; }
	}
}