using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Models;

namespace WebApi.Repositories
{
    public class ShowCastRepository : IShowCastRepository
    {
        private readonly CosmosClient _client;
        private readonly ILogger _logger;

        private const string DatabaseName = "tvmazescraper";
        private const string ContainerName = "showcasts";

        public ShowCastRepository(CosmosClient client, ILogger<ShowCastRepository> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<ShowCast?> GetById(string id)
        {
            var database = _client.GetDatabase(DatabaseName);
            var container = database.GetContainer(ContainerName);

            var query = container.GetItemLinqQueryable<ShowCast>()
                .Where(s => s.id == id);

            _logger.LogInformation("Execute query: {Query}", query.ToString());

            var iterator = query.ToFeedIterator();
            var results = await iterator.ReadNextAsync();

            return await Task.FromResult(results.Count == 1 ? results.First() : null);
        }
    }
}
