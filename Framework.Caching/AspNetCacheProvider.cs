using System;
using System.Web;
using System.Web.Caching;

namespace Framework.Caching
{
	public class AspNetCacheProvider : ICacheProvider
	{
		private readonly Cache _cache;

		public AspNetCacheProvider()
		{
			_cache = HttpRuntime.Cache;
		}

		public void Add(string key, object item, int duration)
		{
			_cache.Insert(key, item, null, DateTime.UtcNow.AddMilliseconds(duration), Cache.NoSlidingExpiration);
		}

		public void Add(string key, object item)
		{
			_cache.Insert(key, item);
		}

		public T Get<T>(string key) where T : class
		{
			return _cache[key] as T;
		}

		public void Remove(string key)
		{
			_cache.Remove(key);
		}
	}
}