using System;

namespace Framework.Repository
{
	/// <summary>
	///     Interface for unit of work.
	/// </summary>
	public interface IUnitOfWork : IDisposable
	{
		/// <summary>
		///     Commits the specified detach all.
		/// </summary>
		/// <param name="detachAll">if set to <c>true</c> [detach all].</param>
		void Commit(bool detachAll = true);

		/// <summary>
		///     Detaches the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		void Detach(object entity);

		/// <summary>
		///     Detaches all.
		/// </summary>
		void DetachAll();
	}
}