using AutoMapper;
using Models;
using ScraperConsoleApp.Client;
using ScraperConsoleApp.Repositories;

namespace ScraperConsoleApp
{
    public class ShowCastMerger : IShowCastMerger
    {
        private readonly IScraperRepository _scraperRepository;
        private readonly ITvMazeClient _tvMazeClient;
        private readonly IMapper _mapper;

        public ShowCastMerger(IScraperRepository scraperRepository, ITvMazeClient tvMazeClient, IMapper mapper)
        {
            _scraperRepository = scraperRepository;
            _tvMazeClient = tvMazeClient;
            _mapper = mapper;
        }

        public async Task MergeCastAsync()
        {

            //// see how far we got 
            //List<ShowCast> showCasts = new List<ShowCast>();
            //await foreach (var showCast in _scraperRepository.GetAllShowcastsAsync())
            //{
            //    showCasts.Add(showCast);
            //}

            List<Show> shows = new List<Show>();
            await foreach (var show in _scraperRepository.GetAllShowsAsync())
            {
                shows.Add(show);
            }

            foreach (var myshow in shows)
            {
                var showWithCastDto = await _tvMazeClient.GetShowAsync(int.Parse(myshow.id), includeCast: true);

                List<Cast> castList = CreateCast(showWithCastDto);

                var showCast = new ShowCast
                {
                    id = showWithCastDto.id.ToString(),
                    Name = showWithCastDto.name,
                    Cast = castList.ToArray()
                };

                await _scraperRepository.UpsertShowCastAsync(showCast);
            }
        }

        private List<Cast> CreateCast(Dto.Show showWithCastDto)
        {
            var castList = new List<Cast>();

            foreach (var cast in showWithCastDto._embedded.cast)
            {
                var modelCast = _mapper.Map<Cast>(cast);
                castList.Add(modelCast);
            }

            return castList;
        }
    }
}
