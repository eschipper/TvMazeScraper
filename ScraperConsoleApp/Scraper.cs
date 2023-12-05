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
        private readonly IShowCastMerger _showCastMerger;
        private readonly ILogger _logger;

        public Scraper(ITvMazeClient client, 
            IScraperRepository repository, 
            IShowMerger showMerger,
            IShowCastMerger showCastMerger,
            ILogger<Scraper> logger)
        {
            _client = client;
            _repository = repository;
            _showMerger = showMerger;
            _showCastMerger = showCastMerger;
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

                // todo: switch later

                await _showCastMerger.MergeCastAsync();

                _logger.LogInformation("   Get shows for page {CurrentPageNumber}", currentPageNumber);


                var shows = await _client.GetShowsAsync(currentPageNumber);

                if (shows.Count != 0)
                {
                    _logger.LogInformation("   {ShowCount} shows found", shows.Count);

                    await _showMerger.MergeShowsAsync(shows);

                    currentPageNumber++;

                    continue;
                }

                _logger.LogInformation("No more shows found");

                currentPageNumber = 0;

            }
        }
    }
}
