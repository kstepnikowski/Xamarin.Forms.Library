using System.Collections.Generic;
using Library.DataAccess.Entities;

namespace Library.DataAccess.Services
{
    public class MockBooksService : IBooksService
    {
        private readonly List<BookEntity> _books;

        public MockBooksService()
        {
            _books = new List<BookEntity>
            {
                new BookEntity("Pan Tadeusz","Adam Mickiewicz"),
                new BookEntity("Potop","Henryk Sienkiewicz"),
                new BookEntity("Przedwiośnie","Stefan Żeromski"),
            };
        }
        public void AddBook(BookEntity book)
        {
            _books.Add(book);
        }

        public void RemoveBook(int id)
        {
            var book = _books.Find(x => x.Id == id);
            _books.Remove(book);

        }

        public List<BookEntity> GetAll()
        {
            return _books;
        }
    }
}
