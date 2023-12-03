using ScraperConsoleApp.Dto;
using System.Text.Json;

namespace ScraperConsoleApp.Client
{
    internal class TvMazeClient : ITvMazeClient
    {
        private readonly HttpClient _httpClient;

        public TvMazeClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Show>> GetShows(int pageNr)
        {
            try
            {
                await using Stream stream =
                    await _httpClient.GetStreamAsync($"https://api.tvmaze.com/shows?page={pageNr}");

                var response = await JsonSerializer.DeserializeAsync<List<Show>>(stream);


                return response ?? new();
            }
            catch (HttpRequestException hEx) when (hEx.StatusCode == System.Net.HttpStatusCode.NotFound) 
            {
                return new();
            }
        }
    }
}
