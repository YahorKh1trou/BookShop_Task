namespace BookShop.Services.Interfaces
{
    public interface IDataAccessService<T>
    {
        public Task<IEnumerable<T>> GetList();

        public Task<IEnumerable<T>> Get(string bookname);

        public Task<IEnumerable<T>> GetListByAuthor(string lastname);

        public Task<T> Get(int id);

        public Task<T> Post(T obj);

        public Task<string> GetSingleBook(int id);
    }
}
