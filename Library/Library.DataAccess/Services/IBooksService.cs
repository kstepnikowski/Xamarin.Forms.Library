using System.Collections.ObjectModel;
using Library.DataAccess.Entities;

namespace Library.DataAccess.Services
{
    public interface IBooksService
    {
        void AddBook(BookEntity book);
        void RemoveBook(int id);
        ObservableCollection<BookEntity> GetAll();
    }
}