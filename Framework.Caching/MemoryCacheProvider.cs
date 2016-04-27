using System;
using System.Runtime.Caching;

namespace Framework.Caching
{
	public class MemoryCacheProvider : ICacheProvider, IDisposable
	{
		private readonly MemoryCache _cache;
		private bool _disposed;

		public MemoryCacheProvider(string name)
		{
			_cache = new MemoryCache(name);
		}

		public void Add(string key, object item, int duration)
		{
			_cache.Add(key, item, new DateTimeOffset(DateTime.UtcNow.AddMilliseconds(duration)));
		}

		public void Add(string key, object item)
		{
			_cache.Add(key, item, null);
		}

		public T Get<T>(string key) where T : class
		{
			return _cache[key] as T;
		}

		public void Remove(string key)
		{
			_cache.Remove(key);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_disposed)
			{
				return;
			}

			if (disposing)
			{
				try
				{
					_cache.Dispose();
				}
				catch
				{
				} // Consume exception.
			}

			_disposed = true;
		}
	}
}