using TvMazeScraperFunctionApp.Dto;

namespace TvMazeScraperFunctionApp.Client
{
    public interface ITvMazeClient
    {
        Task<List<Show>> GetShows();
    }
}