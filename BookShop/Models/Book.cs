namespace BookShop.Models
{
    public class Book
    {
        public int Id { get; set; } // менял на int, т.к на тот момент были проблемы с добавлением guid в сессию, попробую поменять обратно 
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Patro { get; set; }
        public string Birthdate { get; set; }
        public string Bookname { get; set; }
        public int? Year { get; set; }
        public int Counter { get; set; } //Не использую пока, может нужно будет убрать
        public int Price { get; set; } //поменяю на decimal
    }
}
