namespace BookShop.Middlewares
{
    // Why this is in middlewares?
    public class OrderItem
    {
        public int BookId { get; }
        public int Count { get; }
        public int Price { get; }
        public OrderItem(int bookId, int count, int price)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException("Count must be greater than zero");

            BookId = bookId;
            Count = count;
            Price = price;
        }
    }
}
