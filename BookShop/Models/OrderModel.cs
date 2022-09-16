namespace BookShop.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public OrderItemModel[] Items { get; set; } = new OrderItemModel[0];
        public int TotalCount { get; set; }
        public int TotalPrice { get; set; }
    }
}
