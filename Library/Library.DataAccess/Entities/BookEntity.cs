using Realms;

namespace Library.DataAccess.Entities
{
    public class BookEntity : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public BookEntity(string title, string author)
        {
            Title = title;
            Author = author;
        }
    }
}
