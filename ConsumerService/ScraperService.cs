using System;
using cSharpCars;

namespace CarsService
{
    public class ScraperService : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly API _api;

        public IConfiguration _configuration;

        public ScraperService(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _api = new API(_configuration.GetValue<String>("APIKey"));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Scraper service running using API key:" + _configuration.GetValue<String>("APIKey"));
            while (!stoppingToken.IsCancellationRequested) {
                _logger.LogInformation("Updating car park list...");
                var carParks = await this._api.GetAllCarParks(1);

                // TODO - push this information to Kafka stream instead
                _logger.LogInformation(carParks.ToString());

                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}

