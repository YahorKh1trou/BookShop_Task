using BookShop.Models;
using System.Text;

namespace BookShop
{
    public static class SessionExtensions
    {
        private const string key = "Cart";

        public static void RemoveCart(this ISession session)
        {
            session.Remove(key);
        }

        public static void Set(this ISession session, Cart value)
        {
            if (value == null)
                return;
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream, Encoding.UTF8, true))
            {
                writer.Write(value.OrderId);
                writer.Write(value.TotalCount);
                writer.Write(value.TotalPrice);
/*
                writer.Write(value.Items.Count);
                foreach (var item in value.Items)
                {
                    writer.Write(item.Key);
                    writer.Write(item.Value);
                }
                writer.Write(value.Amount);
*/
                session.Set(key, stream.ToArray());
            }
        }

        public static bool TryGetCart(this ISession session, out Cart value)
        {
            if (session.TryGetValue(key, out byte[] buffer))
            {
                using (var stream = new MemoryStream(buffer))
                using (var reader = new BinaryReader(stream, Encoding.UTF8, true))
                {
                    var orderId = reader.ReadInt32();
                    var totalCount = reader.ReadInt32();
                    var totalPrice = reader.ReadInt32();

                    value = new Cart(orderId)
                    {
                        TotalCount = totalCount,
                        TotalPrice = totalPrice,

                    };
/*
                    value = new Cart();
                    var length = reader.ReadInt32();
                    for (int i = 0; i < length; i++)
                    {
                        var bookId = reader.ReadInt32();
//                        byte[] bytes = new byte[16];
//                        BitConverter.GetBytes(bookId).CopyTo(bytes, 0);

                        var count = reader.ReadInt32();
                        //                        value.Items.Add(new Guid(bytes), count);
                        value.Items.Add(bookId, count);
                        //                        value.Amount = 17.45;
                    }
                    value.Amount = reader.ReadInt32();
*/
                    return true;
                }
            }
            value = null;
            return false;
        }
    }
}
