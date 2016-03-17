using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BoatApi.Business.Logic.Common
{
	public interface IUnitOfWork : IDisposable
	{
		/// <summary>
		/// Call this to commit the unit of work
		/// </summary>
		void Commit();

		/// <summary>
		/// Return the database reference for this UOW
		/// </summary>
		DbContext DbContext
		{
			get; set;
		}

		/// <summary>
		/// Starts a transaction on this unit of work
		/// </summary>
		void StartTransaction();
	}
}