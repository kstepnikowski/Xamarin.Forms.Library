using System.Collections.Generic;
using Library.DataAccess.Entities;

namespace Library.DataAccess.Services
{
    public interface IBooksService
    {
        void AddBook(BookEntity book);
        void RemoveBook(int id);
        List<BookEntity> GetAll();
    }
}