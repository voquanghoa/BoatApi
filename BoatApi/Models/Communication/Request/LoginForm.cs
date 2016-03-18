using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

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

		[DataMember(Name = "passwordHash", IsRequired = true)]
		public string PasswordHash
		{
			get; set;
		}
	}
}