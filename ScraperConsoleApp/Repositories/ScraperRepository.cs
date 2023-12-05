using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Extensions.Logging;
using Models;

namespace ScraperConsoleApp.Repositories
{
    public class ScraperRepository : IScraperRepository
    {
        private readonly CosmosClient _client;
        private readonly ILogger _logger;

        private Container _showsIndexContainer;
        private Container _showCastContainer;

        public ScraperRepository(CosmosClient client, ILogger<ScraperRepository> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task EnsureDatabaseAsync()
        {
            _logger.LogInformation("Create database and container if not exists");
            Database database = await _client.CreateDatabaseIfNotExistsAsync("tvmazescraper", 400);

            _showsIndexContainer = await database.CreateContainerIfNotExistsAsync("showsindex", "/id");
            _showCastContainer = await database.CreateContainerIfNotExistsAsync("showcasts", "/id");

        }

        public async Task UpsertShowAsync(Show show)
        {
            await _showsIndexContainer.UpsertItemAsync(show);

        }

        public async IAsyncEnumerable<Show> GetAllShowsAsync()
        {
            var query = _showsIndexContainer.GetItemLinqQueryable<Show>();            

            _logger.LogInformation("Execute query: {Query}", query.ToString());

            var iterator = query.ToFeedIterator();

            while (iterator.HasMoreResults)
                foreach (var show in await iterator.ReadNextAsync())
                    yield return show;
        }

        public async IAsyncEnumerable<ShowCast> GetAllShowcastsAsync()
        {
            var query = _showCastContainer.GetItemLinqQueryable<ShowCast>();
            _logger.LogInformation("Execute query: {Query}", query.ToString());
            var iterator = query.ToFeedIterator();

            while (iterator.HasMoreResults)
                foreach (var showCast in await iterator.ReadNextAsync())
                    yield return showCast;
        }

        public async Task UpsertShowCastAsync(ShowCast showCast)
        {
            await _showCastContainer.UpsertItemAsync(showCast);
        }
    }
}
