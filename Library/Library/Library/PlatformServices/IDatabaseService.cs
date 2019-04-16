using SQLite;

namespace Library.PlatformServices
{
    public interface IDatabaseService
    {
        SQLiteConnection Connection { get; }
    }
}