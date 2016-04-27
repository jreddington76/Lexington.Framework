namespace Framework.Caching
{
	public interface ICacheProvider
	{
		void Add(string key, object item, int duration);
		void Add(string key, object item);
		T Get<T>(string key) where T : class;
		void Remove(string key);
	}
}