using ScraperConsoleApp.Dto;

namespace ScraperConsoleApp.Client
{
    public interface ITvMazeClient
    {
        Task<List<Show>> GetShows(int pageNr);
    }
}
