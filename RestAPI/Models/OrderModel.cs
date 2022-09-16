using DomainModels = Data.Data.Models;
namespace RestAPI.Models
{
    public class OrderModel
    {
        public OrderModel(DomainModels.OrderItem domainOrder)
        {
            Id = domainOrder.Id;
            BookId = domainOrder.BookId;
            Bookname = domainOrder.Bookname;
            Lastname = domainOrder.Lastname;
            Count = domainOrder.Count;
            Price = domainOrder.Price;
            OrderId = domainOrder.OrderId;
        }
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Bookname { get; set; }
        public string Lastname { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public int OrderId { get; set; }
    }
}
