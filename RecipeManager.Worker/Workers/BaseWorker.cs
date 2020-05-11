using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace RecipeManager.Worker.Workers
{
    public abstract class BaseWorker : BackgroundService
    {
        protected virtual TimeSpan WaitTime { get; } = TimeSpan.FromSeconds(10);
        protected readonly ILogger<BaseWorker> Logger;

        public BaseWorker(ILogger<BaseWorker> logger)
        {
            Logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    Logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                    await DoWork();
                }
                catch (Exception exception)
                {
                    Logger.LogError(exception, "Unhandled exception.");
                }
                
                await Task.Delay(WaitTime, stoppingToken);
            }
        }

        protected abstract Task DoWork();
    }
}