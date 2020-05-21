using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RecipeManager.Core.Features.Recipes.Services.Abstract;
using RecipeManager.Core.Queue.Abstract;
using RecipeManager.Core.Queue.Contracts;

namespace RecipeManager.Worker.Workers
{
    /// <summary>
    /// A worker that will attempt to process all <see cref="ImportRecipeMessage"/> in 
    /// the queue and import them into the system.
    /// </summary>
    public class RecipeImportWorker : BaseWorker
    {
        protected override TimeSpan WaitTime { get; } = TimeSpan.FromSeconds(30);

        private readonly IQueueClientFactory<ImportRecipeMessage> _queueClientFactory;
        private readonly IRecipeImporterService _recipeImporterService;

        public RecipeImportWorker(
            ILogger<BaseWorker> logger,
            IQueueClientFactory<ImportRecipeMessage> queueClientFactory,
            IRecipeImporterService recipeImporterService) 
            : base(logger)
        {
            _queueClientFactory = queueClientFactory;
            _recipeImporterService = recipeImporterService;
        }

        protected override async Task DoWork()
        {
            Logger.LogInformation("RecipeImportWorker running at: {time}", DateTimeOffset.Now);

            var queue = _queueClientFactory.GetReceiverClient();
            
            while (true)
            {
                var message = await queue.GetNextMessageAsync();

                if (message == null)
                {
                    break;
                }
                
                Logger.LogInformation("Processing message...");

                await _recipeImporterService.ImportRecipe(message);
            }
            
            await Task.CompletedTask;
        }
    }
}