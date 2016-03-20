using System.Runtime.Serialization;

namespace BoatApi.Models.Communication.Request
{
	/// <summary>
	/// The form to login
	/// </summary>
	[DataContract]
	public class LoginForm
	{
		/// <summary>
		/// User's email
		/// </summary>
		[DataMember(Name = "email", IsRequired = true)]
		public string Email
		{
			get; set;
		}

		/// <summary>
		/// User's password
		/// </summary>
		[DataMember(Name = "password", IsRequired = true)]
		public string Password
		{
			get; set;
		}
	}
}