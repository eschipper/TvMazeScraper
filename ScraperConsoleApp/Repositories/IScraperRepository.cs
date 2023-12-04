using Models;

namespace ScraperConsoleApp.Repositories
{
    public interface IScraperRepository
    {
        Task EnsureDatabaseAsync();
        Task UpsertShowAsync(Show show);
        IAsyncEnumerable<Show> GetAllShowsAsync();
        Task UpsertShowCastAsync(ShowCast showCast);
        IAsyncEnumerable<ShowCast> GetAllShowcastsAsync();
    }
}