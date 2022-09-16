namespace BookShop.Repositories.Interfaces
{
    public interface IOrdermodelRepository<T>
    {
        public Task<T> Create(T order);
    }
}
