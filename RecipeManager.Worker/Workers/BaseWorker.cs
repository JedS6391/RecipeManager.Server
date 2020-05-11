using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace RecipeManager.Worker.Workers
{
    /// <summary>
    /// Provides a set of base functionality for all workers.
    /// </summary>
    public abstract class BaseWorker : BackgroundService
    {
        /// <summary>
        /// Gets a value that determines how long the worker should wait between each run.
        /// </summary>
        protected virtual TimeSpan WaitTime { get; } = TimeSpan.FromSeconds(10);
        
        /// <summary>
        /// Gets the logger for this worker.
        /// </summary>
        protected ILogger<BaseWorker> Logger { get; }

        protected BaseWorker(ILogger<BaseWorker> logger)
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

        /// <summary>
        /// The entry point for worker processing. This method will be called periodically based
        /// on the interval defined by <see cref="WaitTime"/>.
        /// </summary>
        /// <returns></returns>
        protected abstract Task DoWork();
    }
}