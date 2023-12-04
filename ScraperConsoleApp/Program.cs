using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ScraperConsoleApp.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Azure.Cosmos;
using ScraperConsoleApp.Repositories;
using ScraperConsoleApp.Mapper;
using System.Net.Http.Headers;

namespace ScraperConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IHost host = CreateHost();
            Scraper scraper = ActivatorUtilities.CreateInstance<Scraper>(host.Services);

            await scraper.StartScrapingAsync();
        }

        private static IHost CreateHost() =>
            Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => 
                {
                    var config = context.Configuration;

                    services.AddSingleton<ITvMazeClient, TvMazeClient>();
                    services.AddSingleton<IScraperRepository, ScraperRepository>();
                    services.AddSingleton<IShowMerger, ShowMerger>();
                    services.AddSingleton<IShowCastMerger, ShowCastMerger>();
                    services.AddSingleton<CosmosClient>(serviceProvider =>
                    {
                        return new CosmosClient(config.GetConnectionString("Cosmos"));
                    });
                    services.AddAutoMapper(new System.Reflection.Assembly[] { typeof(MapperProfile).Assembly });
                    services.AddHttpClient("Scraper", client => 
                    { 
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    });
                })
                .Build();               

    }
}
