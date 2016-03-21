using System.Transactions;
using System.Data.Entity;
using BoatApi.DataContext;

namespace BoatApi.Business.Logic.Common
{
	/// <summary>
	/// Unit Of Work
	/// </summary>
	public class UnitOfWork : IUnitOfWork
	{
		private TransactionScope transaction;
		/// <summary>
		/// The databse context
		/// </summary>
		public DbContext DbContext
		{
			get; set;
		}

		/// <summary>
		/// Default contructor
		/// </summary>
		public UnitOfWork()
		{
			DbContext = new ApplicationDBContext();
			DbContext.Configuration.ProxyCreationEnabled = false;
			DbContext.Configuration.LazyLoadingEnabled = false;
		}
		/// <summary>
		/// Dispose the object
		/// </summary>
		public void Dispose()
		{
		}

		/// <summary>
		/// Create transaction scope
		/// </summary>
		public void StartTransaction()
		{
			transaction = new TransactionScope();
		}

		/// <summary>
		/// Commit the changes to the database
		/// </summary>
		public void Commit()
		{
			DbContext.SaveChanges();
			transaction.Complete();
		}
	}
}