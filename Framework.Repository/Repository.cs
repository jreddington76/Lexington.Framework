using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Framework.Repository
{
	/// <summary>
	///     Base repository class (Implementation for Entity Framework).
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class Repository<T> : IRepository<T> where T : class
	{
		/// <summary>
		///     Gets the entity set.
		/// </summary>
		/// <value>
		///     The entity set.
		/// </value>
		protected DbSet<T> EntitySet { get; }

		/// <summary>
		///     Initializes a new instance of the <see cref="Repository{T}" /> class.
		/// </summary>
		/// <param name="context">The context.</param>
		/// <exception cref="System.ArgumentNullException">
		///     No context was supplied.
		///     or
		///     No logger was supplied.
		/// </exception>
		protected internal Repository(DbContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException("No context was supplied.");
			}

			EntitySet = context.Set<T>();
		}

		/// <summary>
		///     Gets the by identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public virtual T GetById(object id)
		{
			return EntitySet.Find(id);
		}

		/// <summary>
		///     Gets all.
		/// </summary>
		/// <returns></returns>
		public IQueryable<T> GetAll()
		{
			return EntitySet;
		}

		/// <summary>
		///     Queries the specified filter.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <returns></returns>
		public IQueryable<T> Query(Expression<Func<T, bool>> filter)
		{
			return EntitySet.Where(filter);
		}

		/// <summary>
		///     Adds the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		public void Add(T entity)
		{
			ThrowExceptionIfEntityNull(entity);
			EntitySet.Add(entity);
		}

		/// <summary>
		///     Removes the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		public void Remove(T entity)
		{
			ThrowExceptionIfEntityNull(entity);
			EntitySet.Remove(entity);
		}

		/// <summary>
		///     Attaches the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		public void Attach(T entity)
		{
			ThrowExceptionIfEntityNull(entity);
			EntitySet.Attach(entity);
		}


		/// <summary>
		///     Throws the exception if entity null.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <exception cref="System.ArgumentNullException">No entity was supplied.</exception>
		private static void ThrowExceptionIfEntityNull(T entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException("No entity was supplied.");
			}
		}
	}
}