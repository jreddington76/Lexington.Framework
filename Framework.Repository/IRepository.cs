using System;
using System.Linq;
using System.Linq.Expressions;

namespace Framework.Repository
{
	/// <summary>
	///     Interface for repositories.
	/// </summary>
	/// <typeparam name="T">The entity type that the repository is for.</typeparam>
	public interface IRepository<T> where T : class
	{
		/// <summary>
		///     Gets the by identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		T GetById(object id);

		/// <summary>
		///     Gets all.
		/// </summary>
		/// <returns></returns>
		IQueryable<T> GetAll();

		/// <summary>
		///     Queries the specified filter.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <returns></returns>
		IQueryable<T> Query(Expression<Func<T, bool>> filter);

		/// <summary>
		///     Adds the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		void Add(T entity);

		/// <summary>
		///     Removes the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		void Remove(T entity);

		/// <summary>
		///     Attaches the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		void Attach(T entity);
	}
}