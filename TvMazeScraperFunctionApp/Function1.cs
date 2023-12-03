using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using TvMazeScraperFunctionApp.Client;

namespace TvMazeScraperFunctionApp
{
    public class Function1
    {
        private readonly ILogger _logger;
        private readonly ITvMazeClient _tvMazeClient;

        public Function1(ILoggerFactory loggerFactory, ITvMazeClient tvMazeClient)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
            _tvMazeClient = tvMazeClient;
        }

        [Function("Function1")]
        public async Task Run([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            
            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }

            var response = await _tvMazeClient.GetShows();

            _logger.LogInformation("Task completed");
        }
    }
}
