using Microsoft.Extensions.Logging;
using ScraperConsoleApp.Client;
using ScraperConsoleApp.Repositories;

namespace ScraperConsoleApp
{
    internal class Scraper
    {
        private readonly ITvMazeClient _client;
        private readonly IScraperRepository _repository;
        private readonly IShowMerger _showMerger;
        private readonly ILogger _logger;

        public Scraper(ITvMazeClient client, 
            IScraperRepository repository, 
            IShowMerger showMerger, 
            ILogger<Scraper> logger)
        {
            _client = client;
            _repository = repository;
            _showMerger = showMerger;
            _logger = logger;
        }

        public async Task StartScrapingAsync()
        {
            await _repository.EnsureDatabaseAsync();
            _logger.LogInformation("Start scraping");

            int currentPageNumber = 0;
            
            // Replace by cron mechanism
            while (true)
            {
                _logger.LogInformation("   Get shows for page {CurrentPageNumber}", currentPageNumber);

                var shows = await _client.GetShows(currentPageNumber);

                if (shows.Count != 0)
                {
                    _logger.LogInformation("   {ShowCount} shows found", shows.Count);

                    await _showMerger.MergeShows(shows);

                    currentPageNumber++;

                    continue;
                }

                _logger.LogInformation("No more shows found");
                currentPageNumber = 0;

            }

        }
    }
}
