using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace Framework.Repository
{
	/// <summary>
	///     Base unit if work class (implementation for Entity Framework).
	/// </summary>
	public abstract class UnitOfWork : IUnitOfWork
	{
		private bool _disposed;

		private ObjectContext ObjectContext
		{
			get { return ((IObjectContextAdapter) Context).ObjectContext; }
		}

		/// <summary>
		///     Gets the context.
		/// </summary>
		/// <value>
		///     The context.
		/// </value>
		protected internal DbContext Context { get; private set; }


		/// <summary>
		///     Commits the specified detach all.
		/// </summary>
		/// <param name="detachAll">if set to <c>true</c> [detach all].</param>
		public void Commit(bool detachAll = true)
		{
			CheckContextIsNotNull();

			Context.SaveChanges();

			if (detachAll)
			{
				DetachAll();
			}
		}


		/// <summary>
		///     Detaches the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		public void Detach(object entity)
		{
			if (entity != null)
			{
				ObjectContext.Detach(entity);
			}
		}

		/// <summary>
		///     Detaches all.
		/// </summary>
		public void DetachAll()
		{
			var entries =
				ObjectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Deleted |
				                                                       EntityState.Modified | EntityState.Unchanged);

			foreach (var entry in entries)
			{
				Detach(entry.Entity);
			}
		}

		/// <summary>
		///     Dispose.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		///     Sets the context.
		/// </summary>
		/// <param name="context">The context.</param>
		protected void SetContext(DbContext context)
		{
			Context = context;
			CheckContextIsNotNull();
		}

		/// <summary>
		///     Checks the context is not null.
		/// </summary>
		/// <exception cref="System.ArgumentNullException">context was not supplied.</exception>
		private void CheckContextIsNotNull()
		{
			if (Context == null)
			{
				throw new ArgumentNullException("context was not supplied.");
			}
		}

		/// <summary>
		///     Creates the repository.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="repository">The repository.</param>
		/// <param name="callback">The callback.</param>
		/// <returns></returns>
		protected T CreateRepository<T>(ref T repository, Func<DbContext, T> callback)
		{
			CheckContextIsNotNull();
			if (repository == null)
			{
				repository = callback(Context);
			}
			return repository;
		}

		/// <summary>
		///     Dispose.
		/// </summary>
		/// <param name="disposing"></param>
		protected virtual void Dispose(bool disposing)
		{
			if (_disposed)
			{
				return;
			}

			if (disposing)
			{
				if (Context != null)
				{
					Context.Dispose();
				}
			}

			_disposed = true;
		}
	}
}