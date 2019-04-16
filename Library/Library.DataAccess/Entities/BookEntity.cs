using SQLite;

namespace Library.DataAccess.Entities
{
    public class BookEntity
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public BookEntity(string title, string author)
        {
            Title = title;
            Author = author;
        }

        public BookEntity()
        {
            
        }
    }
}
