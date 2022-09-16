namespace BookShop.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        public Task<T> GetObject(int id);
        public Task<T> Create(T item);
        public Task<IEnumerable<T>> GetObjectListAsync();
        public Task<IEnumerable<T>> GetObjectByNameAsync(string bookname);
        public Task<IEnumerable<T>> GetObjectByAuthorAsync(string lastname);
    }
}
