using System;
using System.IO;
using Library.PlatformServices;
using SQLite;

namespace Library.Droid.Services
{
    internal class DatabaseService : IDatabaseService
    {
        private const string DbFile = "books.db";

        public DatabaseService()
        {
            if (Connection == null)
            {
                var folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                Filename = Path.GetFullPath(Path.Combine(folder, DbFile));
                Connection = new SQLiteConnection(Filename);
            }
        }

        public string Filename { get;}
        public SQLiteConnection Connection { get;}
    }
}