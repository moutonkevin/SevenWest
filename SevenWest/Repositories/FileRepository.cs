using System.IO;
using SevenWest.Caching;
using SevenWest.DataSources;
using SevenWest.IFormatters;

namespace SevenWest.Repositories
{
    public class FileRepository<TItem> : IRepository<TItem>
    {
        private readonly IDataSource _dataSource;
        private readonly ICache<TItem> _cache;
        private readonly IFormat<TItem> _formatter;

        public FileRepository(IDataSource dataSource, ICache<TItem> cache, IFormat<TItem> formatter)
        {
            _dataSource = dataSource;
            _cache = cache;
            _formatter = formatter;
        }

        public TItem GetAllData()
        {
            var cacheKey = "all_data";

            var cachedData = _cache.Get(cacheKey);
            if (cachedData == null)
            {
                var filePath = _dataSource.GetDataSource();
                var fileContent = File.ReadAllText(filePath);
                var formattedData = _formatter.Format(fileContent);

                _cache.Add(cacheKey, formattedData);

                return formattedData;
            }

            return cachedData;
        }
    }
}
