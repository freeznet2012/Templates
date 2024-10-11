using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IMyService _myService;

    public Worker(ILogger<Worker> logger, IMyService myService)
    {
        _logger = logger;
        _myService = myService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Worker started at: {time}", DateTimeOffset.Now);
        while (!stoppingToken.IsCancellationRequested)
        {
            _myService.Run();
            await Task.Delay(1000, stoppingToken); // Wait for 1 second
        }
        _logger.LogInformation("Worker stopping at: {time}", DateTimeOffset.Now);
    }
}
