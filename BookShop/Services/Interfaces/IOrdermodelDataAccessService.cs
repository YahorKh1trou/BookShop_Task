namespace BookShop.Services.Interfaces
{
    public interface IOrdermodelDataAccessService<T>
    {
        public Task<T> Post(T obj);
    }
}
