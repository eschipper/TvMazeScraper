using ScraperConsoleApp.Dto;

namespace ScraperConsoleApp
{
    public interface IShowMerger
    {
        Task MergeShowsAsync(IEnumerable<Show> shows);
    }
}