namespace BookShop.Repositories.Interfaces
{
    public interface IOrderitemmodelRepository<T>
    {
        public Task<T> Create(T item);
    }
}
