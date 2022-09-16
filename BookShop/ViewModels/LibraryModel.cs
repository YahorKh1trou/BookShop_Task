namespace BookShop.ViewModels
{
    public class LibraryModel
    {
        public LibraryModel() { }

        public LibraryModel(int id, string name, string lastname, string patro, string birthdate, string bookname, int? year, int counter)
        {
            Id = id;
            Name = name;
            Lastname = lastname;
            Patro = patro;
            Birthdate = birthdate;
            Bookname = bookname;
            Year = year;
            Counter = counter;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Patro { get; set; }
        public string Birthdate { get; set; }
        public string Bookname { get; set; }
        public int? Year { get; set; }
        public int Counter { get; set; }
/*
        public override string ToString()
        {
            return $"{Id}{Constants.Delimeter}" +
                   $"{FirstName}{Constants.Delimeter}" +
                   $"{LastName}{Constants.Delimeter}" +
                   $"{SurName}{Constants.Delimeter}" +
                   $"{DateOnly.FromDateTime(DateOfBirth)}{Constants.Delimeter}" +
                   $"{BookId}{Constants.Delimeter}" +
                   $"{Title}{Constants.Delimeter}" +
                   $"{WrittenOnYear}{Constants.Delimeter}";
        }
*/
    }
}
