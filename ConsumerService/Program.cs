using CarsService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        //services.AddHostedService<Worker>();
        services.AddHostedService<ScraperService>();
    })
    .Build();

await host.RunAsync();

return 0;