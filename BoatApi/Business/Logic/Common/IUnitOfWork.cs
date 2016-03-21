using System;
using System.Data.Entity;

namespace BoatApi.Business.Logic.Common
{
	/// <summary>
	/// Unit Of Work
	/// </summary>
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