using System.Runtime.Serialization;

namespace BoatApi.Models.Communication.Request
{
	[DataContract]
	public class LoginForm
	{
		[DataMember(Name = "email", IsRequired = true)]
		public string Email
		{
			get; set;
		}

		[DataMember(Name = "password", IsRequired = true)]
		public string Password
		{
			get; set;
		}
	}
}