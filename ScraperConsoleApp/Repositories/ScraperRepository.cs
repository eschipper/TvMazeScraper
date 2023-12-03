using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using Models;

namespace ScraperConsoleApp.Repositories
{
    public class ScraperRepository : IScraperRepository
    {
        private readonly CosmosClient _client;
        private readonly ILogger _logger;

        private Container _showsContainer;

        public ScraperRepository(CosmosClient client, ILogger<ScraperRepository> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task EnsureDatabaseAsync()
        {
            _logger.LogInformation("Create database and container if not exists");
            Database database = await _client.CreateDatabaseIfNotExistsAsync("tvmazescraper", 400);

            _showsContainer = await database.CreateContainerIfNotExistsAsync("scrapedshows", "/id");
        }

        public async Task UpsertShowAsync(Show show)
        {
            await _showsContainer.UpsertItemAsync(show);

        }
    }
}
