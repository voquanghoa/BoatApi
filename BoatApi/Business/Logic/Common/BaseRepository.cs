using BoatApi.Models.ServiceModel.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace BoatApi.Business.Logic.Common
{
	/// <summary>
	/// Base repository for all model (should inherit from BaseModel)
	/// </summary>
	/// <typeparam name="T">The class of model</typeparam>
	public class BaseRepository<T> : IRepository<T> where T : BaseModel
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly DbSet<T> dbSet;

		/// <summary>
		/// Contructor with unitOfWork
		/// </summary>
		/// <param name="unitOfWork">UnitOfWork object</param>
		/// <exception cref="ArgumentNullException">When unitOfWork is null</exception>
		public BaseRepository(IUnitOfWork unitOfWork)
		{
			if (unitOfWork == null)
			{
				throw new ArgumentNullException("unitOfWork is null");
			}
				
			this.unitOfWork = unitOfWork;
			dbSet = this.unitOfWork.DbContext.Set<T>();
		}

		/// <summary>
		/// Get the object by id
		/// </summary>
		/// <param name="id">The object's id</param>
		/// <returns>The object if found or an exception will throw if not found</returns>
		public T GetById(Guid id)
		{
			return dbSet.Find(id);
		}

		/// <summary>
		/// Get all object(s) from database
		/// </summary>
		/// <returns>The list of object(s)</returns>
		public List<T> GetAll()
		{
			return All().ToList();
		}

		/// <summary>
		/// Get the queryable for all object(s)
		/// </summary>
		/// <param name="includes">List of field's name should be included innned</param>
		/// <returns>The queryable for all object(s)</returns>
		public IQueryable<T> All(string[] includes = null)
		{
			if (includes != null && includes.Any())
			{
				var query = dbSet.Include(includes.First());

				query = includes.Skip(1).Aggregate(query, (current, include) => current.Include(include));

				return query.AsQueryable();
			}

			return dbSet.AsQueryable();
		}

		/// <summary>
		/// Find an object by id
		/// </summary>
		/// <param name="id">The object's id</param>
		/// <returns>The object if found or a Null object if not found</returns>
		public T FindOne(Guid id)
		{
			return FindOne((Guid?)id);
		}

		/// <summary>
		/// Find an object by id
		/// </summary>
		/// <param name="id">The object's id, id can be null</param>
		/// <returns>The object if found or a Null object if not found</returns>
		public T FindOne(Guid? id)
		{
			return dbSet.FirstOrDefault(x => x.Id == id);
		}

		/// <summary>
		/// Find an object by a predicate
		/// </summary>
		/// <param name="predicate">The predicate</param>
		/// <param name="includes">The list of field's name should include</param>
		/// <returns>The object if found, null if not found</returns>
		public T FindOne(Expression<Func<T, bool>> predicate, string[] includes = null)
		{
			if (includes != null && includes.Any())
			{
				var query = dbSet.Include(includes.First());

				query = includes.Skip(1).Aggregate(query, (current, include) => current.Include(include));

				return query.FirstOrDefault(predicate);
			}

			return dbSet.FirstOrDefault(predicate);
		}

		/// <summary>
		/// Create a queryable for object(s) which match a predicate
		/// </summary>
		/// <param name="predicate">The predicate</param>
		/// <param name="includes">The list of field's name should include</param>
		/// <returns>The queryable for the given filter</returns>
		public virtual IQueryable<T> Filter(Expression<Func<T, bool>> predicate, string[] includes = null)
		{
			if (includes != null && includes.Any())
			{
				var query = dbSet.Include(includes.First());

				query = includes.Skip(1).Aggregate(query, (current, include) => current.Include(include));

				return query.Where(predicate).AsQueryable();
			}

			return dbSet.Where(predicate).AsQueryable();
		}

		/// <summary>
		/// Create a new object to database.
		/// </summary>
		/// <param name="TObject">Specified a new object to create.</param>
		/// <returns>The created object</returns>
		public virtual T Create(T TObject)
		{
			var newEntry = dbSet.Add(TObject);

			unitOfWork.DbContext.SaveChanges();

			return newEntry;
		}

		/// <summary>
		/// Delete the object from database.
		/// </summary>
		/// <param name="TObject">Specified a existing object to delete.</param>
		/// <returns>1 if success, 0 if failed</returns>
		public virtual int Delete(T TObject)
		{
			dbSet.Remove(TObject);
			return unitOfWork.DbContext.SaveChanges();
		}

		/// <summary>
		/// Update object changes and save to database.
		/// </summary>
		/// <param name="TObject">Specified the object to save.</param>
		/// <returns>Number of effected objects</returns>
		public virtual int Update(T TObject)
		{
			dbSet.Attach(TObject);
			unitOfWork.DbContext.Entry(TObject).State = EntityState.Modified;
			return unitOfWork.DbContext.SaveChanges();
		}

		/// <summary>
		/// Delete objects from database by specified filter expression.
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns>Number of deleted objects</returns>
		public virtual int Delete(Expression<Func<T, bool>> predicate)
		{
			dbSet.RemoveRange(Filter(predicate));
			return unitOfWork.DbContext.SaveChanges();
		}

		/// <summary>
		/// Check if we have some object(s) is exists in database by specified filter.
		/// </summary>
		/// <param name="predicate">Specified the filter expression</param>
		/// <returns>true if the object(s) exist, false if not</returns>
		public bool Contains(Expression<Func<T, bool>> predicate)
		{
			return dbSet.Any(predicate);
		}

		/// <summary>
		/// Saves the changes.
		/// </summary>
		public virtual void SaveChanges()
		{
			unitOfWork.DbContext.SaveChanges();
		}

		/// <summary>
		/// Dispose the data context
		/// </summary>
		public void Dispose()
		{
			unitOfWork.DbContext?.Dispose();
		}
	}
}