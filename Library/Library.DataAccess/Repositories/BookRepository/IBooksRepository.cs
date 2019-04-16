using System.Collections.Generic;
using Library.DataAccess.Entities;

namespace Library.DataAccess.Repositories.BookRepository
{
    public interface IBooksRepository
    {
        void Add(BookEntity book);
        void Remove(int id);
        List<BookEntity> GetAll();
    }
}
