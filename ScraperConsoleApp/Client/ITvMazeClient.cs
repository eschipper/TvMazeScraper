using ScraperConsoleApp.Dto;

namespace ScraperConsoleApp.Client
{
    public interface ITvMazeClient
    {
        Task<List<Show>> GetShowsAsync(int pageNr);
        Task<Show> GetShowAsync(int id, bool includeCast);
    }
}
