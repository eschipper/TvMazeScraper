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

        public Scraper(ITvMazeClient client)
        {
            _client = client;
        }

        public async Task StartScrapingAsync()
        {
            var shows = await _client.GetShows();

        }
    }
}
