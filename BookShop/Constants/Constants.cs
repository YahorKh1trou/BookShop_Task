namespace BookShop.Constants
{
    public class Constants
    {
        public const string BooksAPIController = "Books";
        public const string OrderitemAPIController = "Orderitem";
        public const string OrderAPIController = "Order";
        public const string GetByAuthorString = "Books/getbyauthor";
        // Bettter not to store connections in consts, because in production you'll have more than 1 config
        // such properties should be moved to appsettings.json file 
        public const string APIConnectionURL = "https://localhost:7032/";
    }
}
