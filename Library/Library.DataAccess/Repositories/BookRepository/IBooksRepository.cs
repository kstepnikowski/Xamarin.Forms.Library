using System.Collections.Generic;
using System.Threading.Tasks;
using Library.DataAccess.Entities;

namespace Library.DataAccess.Repositories.BookRepository
{
    public interface IBooksRepository
    {
        Task Add(BookEntity book);
        Task Remove(int id);
        Task<List<BookEntity>> GetAll();
    }
}
