using Models;

namespace ScraperConsoleApp.Repositories
{
    public interface IScraperRepository
    {
        Task EnsureDatabaseAsync();
        Task UpsertShowAsync(Show show);
    }
}