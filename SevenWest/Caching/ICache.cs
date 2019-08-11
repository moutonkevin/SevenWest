namespace SevenWest.Caching
{
    public interface ICache<TItem>
    {
        TItem Get(string key);
        void Add(string key, TItem item);
    }
}