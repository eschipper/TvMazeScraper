using ScraperConsoleApp.Dto;

namespace ScraperConsoleApp
{
    public interface IShowMerger
    {
        Task MergeShows(IEnumerable<Show> shows);
    }
}