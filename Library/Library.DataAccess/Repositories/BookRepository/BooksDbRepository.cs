using System.Collections.Generic;
using System.Threading.Tasks;
using Library.DataAccess.Entities;
using Library.DataAccess.Repositories.Base;
using SQLite;

namespace Library.DataAccess.Repositories.BookRepository
{
    public class BooksDbRepository : BaseDbRepository, IBooksRepository
    {
        public BooksDbRepository(SQLiteConnection dbConnection) : base(dbConnection)
        {
        }

        public Task Add(BookEntity book)
        {
            return Task.Run(() =>
            {
                lock (databaseLock)
                {
                    DbConnection.Insert(book);
                }
            });
        }

        public Task Remove(int id)
        {
            return Task.Run(() =>
            {
                lock (databaseLock)
                {
                    DbConnection.Delete<BookEntity>(id);
                }
            });
        }

        public Task<List<BookEntity>> GetAll()
        {
            List<BookEntity> books;

            lock (databaseLock)
            {
                books = DbConnection.Table<BookEntity>().ToList();
            }

            return Task.FromResult(books);
        }
    }
}
