using AutoMapper;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using ScraperConsoleApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task MergeShows(IEnumerable<Dto.Show> shows)
        {
            foreach (var showDto in shows)
            {
                try
                {
                    var show = _mapper.Map<Model.Show>(showDto);

                    await _repository.UpsertShowAsync(show);
                    _logger.LogTrace("        Show with id {ShowId} synced with repo", showDto.id);
                }
                catch (CosmosException cEx)
                {
                    _logger.LogError(cEx, cEx.Message);
                }
            }
        }
    }
}
