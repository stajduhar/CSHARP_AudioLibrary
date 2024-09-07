namespace AudioLibrary.Models
{
    public class Book: Entitet
    {
        public string? the_title_of_the_book { get; set; } // jel ovo okey?
        public int? author_of_the_book { get; set; }
        public int? book_genre { get; set; }
    }
}
