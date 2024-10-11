using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.ApplicationInsights.Extensibility;

Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostingContext, config) =>
    {
        config
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
    })
    .ConfigureServices((context, services) =>
    {
        services.AddHostedService<Worker>();
        services.AddTransient<IMyService, MyService>();
        services.AddApplicationInsightsTelemetryWorkerService(context.Configuration["ApplicationInsights:InstrumentationKey"]);
    })
    .ConfigureLogging((context, logging) =>
    {
        logging.ClearProviders();
        logging.AddConsole();
        logging.AddApplicationInsights();
        logging.SetMinimumLevel(LogLevel.Information);
    })
    .Build()
    .Run();
