using Azure;
using Microsoft.Extensions.Logging;
using ScraperConsoleApp.Dto;
using System.Text.Json;

namespace ScraperConsoleApp.Client
{
    internal class TvMazeClient : ITvMazeClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;

        public TvMazeClient(HttpClient httpClient, ILogger<TvMazeClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
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

        public async Task<Show> GetShow(int id, bool includeCast = false)
        {
            try
            {
                await using Stream stream =
                    await _httpClient.GetStreamAsync($"https://api.tvmaze.com/shows/{id}{(includeCast ? "?embed=cast" : string.Empty)}");

                var response = JsonSerializer.DeserializeAsync<Show>(stream).Result;
                return response;
            }
            catch (HttpRequestException hEx) when (hEx.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
            {
                _logger.LogWarning(hEx, "rate limit hit");
                
                await Task.Delay(5000);
                return await GetShow(id, includeCast);
            }
        }
    }
}
