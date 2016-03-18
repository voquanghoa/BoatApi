using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BoatApi.Models.Communication.Response
{
	[DataContract]
	public class GoodDTO
	{
		[DataMember(Name = "id")]
		public Guid Id
		{
			get; set;
		}

		[DataMember(Name = "quanlity")]
		public int Quanlity
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