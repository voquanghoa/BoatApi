using BoatApi.Models.ServiceModel.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace BoatApi.Business.Logic.Common
{
	public class BaseRepository<T> : IRepository<T> where T : BaseModel
	{
		protected readonly IUnitOfWork UnitOfWork;
		protected DbSet<T> DbSet;
		protected string[] Includes
		{
			get; set;
		}

		public BaseRepository(IUnitOfWork unitOfWork)
		{
			if (unitOfWork == null)
			{
				throw new ArgumentNullException("unitOfWork is null");
			}
				
			UnitOfWork = unitOfWork;
			DbSet = UnitOfWork.DbContext.Set<T>();
		}

		public T GetById(Guid id)
		{
			return DbSet.Find(id);
		}

		public List<T> GetAll()
		{
			return All().ToList();
		}

		public IQueryable<T> All(string[] includes = null)
		{
			if (includes != null && includes.Any())
			{
				var query = DbSet.Include(includes.First());

				query = includes.Skip(1).Aggregate(query, (current, include) => current.Include(include));

				return query.AsQueryable();
			}

			return DbSet.AsQueryable();
		}

		public virtual T FindOne(Expression<Func<T, bool>> predicate, string[] includes = null)
		{
			if (includes != null && includes.Any())
			{
				var query = DbSet.Include(includes.First());

				query = includes.Skip(1).Aggregate(query, (current, include) => current.Include(include));
			}

			return DbSet.FirstOrDefault(predicate);
		}

		public virtual IQueryable<T> Filter(Expression<Func<T, bool>> predicate, string[] includes = null)
		{
			if (includes != null && includes.Any())
			{
				var query = DbSet.Include(includes.First());

				query = includes.Skip(1).Aggregate(query, (current, include) => current.Include(include));

				return query.Where(predicate).AsQueryable();
			}

			return DbSet.Where(predicate).AsQueryable();
		}

		public virtual IQueryable<T> Filter(Expression<Func<T, bool>> predicate, out int total, int index = 0, int size = 50, string[] includes = null)
		{
			int skipCount = index * size;

			IQueryable<T> resetSet;

			if (includes != null && includes.Any())
			{
				var query = DbSet.Include(includes.First());

				query = includes.Skip(1).Aggregate(query, (current, include) => current.Include(include));

				resetSet = predicate != null ? query.Where(predicate).AsQueryable() : query.AsQueryable();
			}
			else
			{
				resetSet = predicate != null ? DbSet.Where(predicate).AsQueryable() : DbSet.AsQueryable();
			}

			resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);

			total = resetSet.Count();

			return resetSet.AsQueryable();
		}

		public virtual T Create(T TObject)
		{
			var newEntry = DbSet.Add(TObject);

			UnitOfWork.DbContext.SaveChanges();

			return newEntry;
		}

		public virtual int Delete(T TObject)
		{
			DbSet.Remove(TObject);
			return UnitOfWork.DbContext.SaveChanges();
		}

		public virtual int Update(T TObject)
		{
			DbSet.Attach(TObject);
			UnitOfWork.DbContext.Entry(TObject).State = EntityState.Modified;
			return UnitOfWork.DbContext.SaveChanges();
		}

		public virtual int Delete(Expression<Func<T, bool>> predicate)
		{
			DbSet.RemoveRange(Filter(predicate));
			return UnitOfWork.DbContext.SaveChanges();
		}

		public bool Contains(Expression<Func<T, bool>> predicate)
		{
			return DbSet.Any(predicate);
		}

		public virtual void ExecuteProcedure(String procedureCommand, params SqlParameter[] sqlParams)
		{
			UnitOfWork.DbContext.Database.ExecuteSqlCommand(procedureCommand, sqlParams);
		}

		public virtual void SaveChanges()
		{
			UnitOfWork.DbContext.SaveChanges();
		}

		public void Dispose()
		{
			if (UnitOfWork.DbContext != null)
			{
				UnitOfWork.DbContext.Dispose();
			}
		}
	}
}