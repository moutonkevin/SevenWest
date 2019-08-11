using Microsoft.Extensions.Caching.Memory;

namespace SevenWest.Caching
{
    public class InMemoryCache<TItem> : ICache<TItem>
    {
        private readonly MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

        public TItem Get(string key)
        {
            return _cache.TryGetValue(key, out TItem cacheEntry) ? cacheEntry : default(TItem);
        }

        public void Add(string key, TItem item)
        {
            _cache.Set(key, item);
        }
    }
}
