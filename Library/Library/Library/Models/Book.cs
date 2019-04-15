namespace Library.Core.Models
{
    public class Book
    {
        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }

        public string Title { get; }
        public string Author { get; }
    }
}
