using System;
using System.ComponentModel.DataAnnotations;

namespace BoatApi.Models.ServiceModel.Base
{
	/// <summary>
	/// The base model for every model
	/// </summary>
	public class BaseModel
	{
		/// <summary>
		/// The key of model
		/// </summary>
		[Key]
		public Guid Id
		{
			get; set;
		}
	}
}