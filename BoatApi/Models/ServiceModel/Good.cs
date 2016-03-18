using BoatApi.Models.ServiceModel.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoatApi.Models.ServiceModel
{
	public enum Quality
	{
		Unknown = -1,
		Bad = 0,
		Normal = 1,
		Good = 2,
		Excellent = 3
	}

	[Table("Good")]
	public class Good : BaseModel
	{
		[Required]
		public Boat Boat
		{
			get; set;
		}

		[Required]
		public Quality Quality
		{
			get; set;
		}

		public string ImageUrl
		{
			get; set;
		}
	}
}