using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Transactions;
using System.Data.Entity;
using BoatApi.DataContext;

namespace BoatApi.Business.Logic.Common
{
	public class UnitOfWork : IUnitOfWork
	{
		private TransactionScope _transaction;
		public DbContext DbContext
		{
			get; set;
		}

		public UnitOfWork()
		{
			DbContext = new ApplicationDBContext();
			DbContext.Configuration.ProxyCreationEnabled = false;
			DbContext.Configuration.LazyLoadingEnabled = false;
		}

		public void Dispose()
		{
		}

		public void StartTransaction()
		{
			_transaction = new TransactionScope();
		}

		public void Commit()
		{
			DbContext.SaveChanges();
			_transaction.Complete();
		}
	}
}