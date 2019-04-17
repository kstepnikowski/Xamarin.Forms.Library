using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Library.DataAccess.Entities;

namespace Library.DataAccess.Services
{
    public class MockBooksService : IBooksService
    {
        private readonly ObservableCollection<BookEntity> _books;

        public MockBooksService()
        {
            _books = new ObservableCollection<BookEntity>
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
            var book = _books.First(x => x.Id == id);
            _books.Remove(book);

        }

        public ObservableCollection<BookEntity> GetAll()
        {
            return _books;
        }
    }
}
