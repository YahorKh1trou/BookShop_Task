namespace BookShop.Models
{
    public class OrderItemModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Bookname { get; set; } /// Эти два поля useless, уберутся, как добавится Foreign Key для покупателя
        public string Lastname { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public int OrderId { get; set; }
    }
}
