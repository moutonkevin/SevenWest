namespace SevenWest.DataSources
{
    public class FileDataSource : IDataSource
    {
        public string GetDataSource()
        {
            return "./example_data.json";
        }
    }
}
