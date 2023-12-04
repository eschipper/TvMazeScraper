using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Models;

namespace WebApi.Repositories
{
    public class ShowRepository : IShowRepository
    {
        private readonly CosmosClient _client;
        private readonly ILogger _logger;


        private const string DatabaseName = "tvmazescraper";
        private const string ContainerName = "scrapedshows";
        private const int PageSize = 10;

        public ShowRepository(CosmosClient client, ILogger<ShowRepository> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<Show?> GetById(string id)
        {
            var database = _client.GetDatabase(DatabaseName);
            var container = database.GetContainer(ContainerName);

            var query = container.GetItemLinqQueryable<Show>()
                .Where(s => s.id == id);

            _logger.LogInformation("Execute query: {Query}", query.ToString());

            var iterator = query.ToFeedIterator();
            var results = await iterator.ReadNextAsync();

            return await Task.FromResult(results.Count == 1 ? results.First() : null);
        }

        public async Task<IEnumerable<Show>> GetAll(int pageNumber = 1)
        {
            var database = _client.GetDatabase(DatabaseName);
            var container = database.GetContainer(ContainerName);

            var query = container.GetItemLinqQueryable<Show>()
                .OrderBy(s => s.id)
                .Skip((pageNumber - 1) * PageSize)
                .Take(PageSize);
            

            _logger.LogInformation("Execute query: {Query}", query.ToString());

            var iterator = query.ToFeedIterator();
            var results = await iterator.ReadNextAsync();
            return results;
        }

    }
}
