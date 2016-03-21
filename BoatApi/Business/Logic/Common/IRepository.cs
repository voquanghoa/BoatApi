using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace BoatApi.Business.Logic.Common
{
	/// <summary>
	/// Interface for repository
	/// </summary>
	/// <typeparam name="T">The database model inhenrit from BaseModel</typeparam>
	public interface IRepository<T> : IDisposable where T : class
	{
		/// <summary>
		/// Gets all objects from database
		/// </summary>
		/// <returns>The queryable of all objects</returns>
		IQueryable<T> All(string[] includes = null);

		/// <summary>
		/// Get the object by id
		/// </summary>
		/// <param name="id">The object's id</param>
		/// <returns>The object if found or an exception will throw if not found</returns>
		T GetById(Guid id);

		/// <summary>
		/// Find one object(s) by a predicate
		/// </summary>
		/// <param name="predicate">The predicate</param>
		/// <param name="includes">The list of field's name should include</param>
		/// <returns>The object if found, null if not found</returns>
		T FindOne(Expression<Func<T, bool>> predicate, string[] includes = null);


		/// <summary>
		/// Create a queryable for object(s) which match a predicate
		/// </summary>
		/// <param name="predicate">The predicate</param>
		/// <param name="includes">The list of field's name should include</param>
		/// <returns>The queryable for the given filter</returns>
		IQueryable<T> Filter(Expression<Func<T, bool>> predicate, string[] includes = null);

		/// <summary>
		/// Gets the object(s) is exists in database by specified filter.
		/// </summary>
		/// <param name="predicate">Specified the filter expression</param>
		/// <returns>true if the object(s) exist, false if not</returns>
		bool Contains(Expression<Func<T, bool>> predicate);

		/// <summary>
		/// Create a new object to database.
		/// </summary>
		/// <param name="t">Specified a new object to create.</param>
		/// <returns></returns>
		T Create(T t);

		/// <summary>
		/// Delete the object from database.
		/// </summary>
		/// <param name="t">Specified a existing object to delete.</param>
		int Delete(T t);

		/// <summary>
		/// Delete objects from database by specified filter expression.
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		int Delete(Expression<Func<T, bool>> predicate);

		/// <summary>
		/// Update object changes and save to database.
		/// </summary>
		/// <param name="t">Specified the object to save.</param>
		/// <returns>Number of effected objects</returns>
		int Update(T t);

		/// <summary>
		/// Saves the changes.
		/// </summary>
		void SaveChanges();
	}
}