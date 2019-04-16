using SQLite;

namespace Library.DataAccess.Repositories.Base
{
    public class BaseDbRepository
    {
        protected static object databaseLock = new object();
        protected SQLiteConnection DbConnection { get; set; }

        public BaseDbRepository(SQLiteConnection dbConnection)
        {
            DbConnection = dbConnection;
        }
    }
}
