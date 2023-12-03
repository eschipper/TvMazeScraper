
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ScraperConsoleApp.Client;

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
                })
                .Build();               

    }
}
