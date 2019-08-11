using Newtonsoft.Json;

namespace SevenWest.IFormatters
{
    public class JsonFormatter<TItem> : IFormat<TItem>
    {
        public TItem Format(string value)
        {
            return JsonConvert.DeserializeObject<TItem>(value);
        }
    }
}
