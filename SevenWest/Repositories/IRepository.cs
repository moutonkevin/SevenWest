namespace SevenWest.Repositories
{
    public interface IRepository<TItem>
    {
        TItem GetAllData();
    }
}
