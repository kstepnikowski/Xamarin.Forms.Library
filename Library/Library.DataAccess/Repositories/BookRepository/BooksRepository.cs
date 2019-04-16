using System.Collections.Generic;
using System.Linq;
using Library.DataAccess.Entities;
using Realms;

namespace Library.DataAccess.Repositories.BookRepository
{
    public class BooksRepository : IBooksRepository
    {
        private static readonly Realm Realm = Realm.GetInstance();
        public void Add(BookEntity book)
        {
            Realm.Write(()=>
            {
                Realm.Add(book);
            });
        }

        public void Remove(int id)
        {
            var book = Realm.All<BookEntity>().First(x => x.Id == id);

            using (var trans = Realm.BeginWrite())
            {
                Realm.Remove(book);
                trans.Commit();
            }
        }

        public List<BookEntity> GetAll()
        {
            return Realm.All<BookEntity>().ToList();
        }
    }
}
