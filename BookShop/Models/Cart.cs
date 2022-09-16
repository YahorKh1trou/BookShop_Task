using System.Collections.Generic;

namespace BookShop.Models
{
    public class Cart
    {
        public int OrderId { get; }
        public int TotalCount { get; set; }
        public int TotalPrice { get; set; }
        public Cart(int orderId)
        {
            OrderId = orderId;
            TotalCount = 0;
            TotalPrice = 0;
        }

        /*
                public IDictionary<int, int> Items { get; set; } = new Dictionary<int, int>();
                public int Amount { get; set; }
        */
    }
}
