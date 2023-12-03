﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TvMazeScraperFunctionApp.Dto;



namespace TvMazeScraperFunctionApp.Client
{
    internal class TvMazeClient : ITvMazeClient
    {
        public async Task<List<Show>> GetShows()
        {
            using HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            await using Stream stream =
                await client.GetStreamAsync("https://api.tvmaze.com/shows");

            var response = await JsonSerializer.DeserializeAsync<List<Show>>(stream);            

            return response ?? new();
        }

    }
}