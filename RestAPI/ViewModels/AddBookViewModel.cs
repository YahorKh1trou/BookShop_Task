using Data.Data.Models;

namespace RestAPI.ViewModels
{
    public class AddBookViewModel
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Patro { get; set; }
        public string Birthdate { get; set; }
        public string Bookname { get; set; }
        public int? Year { get; set; }
        public int Price { get; set; }

        public DateTime ConvertedDate;

        public bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return false;
            }
            if (!DateTime.TryParse(Birthdate, out ConvertedDate))
            {
                return false;
            }
            return true;
        }

        public Book ToDomainBook(AddBookViewModel addBook)
        {
            return new Book
            {
                Name = addBook.Name,
                Lastname = addBook.Lastname,
                Patro = addBook.Patro,
                Birthdate = ConvertedDate,
                Bookname = addBook.Bookname,
                Year = addBook.Year,
                Price = addBook.Price,
            };
        }
    }
}
