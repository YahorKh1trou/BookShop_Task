namespace BookShop.Services.Interfaces
{
    public interface IOrderitemmodelDataAccessService<T>
    {
        public Task<T> Post(T obj);
    }
}
