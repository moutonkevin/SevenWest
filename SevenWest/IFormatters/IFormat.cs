namespace SevenWest.IFormatters
{
    public interface IFormat<TItem>
    {
        TItem Format(string value);
    }
}
