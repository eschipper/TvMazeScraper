using AutoMapper;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using ScraperConsoleApp.Repositories;

namespace ScraperConsoleApp
{
    public class ShowMerger : IShowMerger
    {
        private readonly IScraperRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public ShowMerger(IScraperRepository repository, IMapper mapper, ILogger<ShowMerger> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task MergeShowsAsync(IEnumerable<Dto.Show> shows)
        {
            foreach (var showDto in shows)
            {
                try
                {
                    var show = _mapper.Map<Models.Show>(showDto);

                    await _repository.UpsertShowAsync(show);
                    _logger.LogTrace("Show with id {ShowId} synced with repo", showDto.id);
                }
                catch (CosmosException cEx)
                {
                    _logger.LogError(cEx, cEx.Message);
                }
            }
        }
    }
}
