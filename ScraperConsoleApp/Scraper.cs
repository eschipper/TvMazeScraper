using Microsoft.Extensions.Logging;
using ScraperConsoleApp.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScraperConsoleApp
{
    internal class Scraper
    {
        private readonly ITvMazeClient _client;
        private readonly ILogger _logger;

        public Scraper(ITvMazeClient client, ILogger<Scraper> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task StartScrapingAsync()
        {
            _logger.LogInformation("Start scraping");

            int currentPageNumber = 0;            
            
            // Replace by cron mechanism
            while (true)
            {

                _logger.LogInformation($"   Get shows for page {currentPageNumber}");

                var shows = await _client.GetShows(currentPageNumber);

                if (shows.Any())
                {
                    _logger.LogInformation($"   {shows.Count} shows found");

                    currentPageNumber++;

                    continue;
                }

                _logger.LogInformation("No more shows found");
                currentPageNumber = 0;

            }

        }
    }
}
