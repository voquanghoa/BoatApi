using System;
using System.Runtime.Serialization;
using BoatApi.Models.Common;

namespace BoatApi.Models.Communication.Response
{
	/// <summary>
	/// Good model
	/// </summary>
	[DataContract]
	public class GoodDTO
	{
		/// <summary>
		/// The id from database
		/// </summary>
		[DataMember(Name = "id")]
		public Guid Id
		{
			get; set;
		}

		/// <summary>
		/// The quality of good
		/// </summary>
		[DataMember(Name = "quanlity")]
		public Quality Quanlity
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