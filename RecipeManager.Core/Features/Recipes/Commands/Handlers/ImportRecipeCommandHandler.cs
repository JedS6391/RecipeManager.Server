using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RecipeManager.Core.Data.Abstract;
using RecipeManager.Core.Features.Recipes.Commands.Requests;
using RecipeManager.Core.Features.Recipes.Models.Query;
using RecipeManager.Core.Infrastructure.Abstract;
using RecipeManager.Core.Queue.Abstract;
using RecipeManager.Core.Queue.Contracts;
using RecipeManager.Domain.Entities;
using RecipeManager.Domain.Entities.Enum;

namespace RecipeManager.Core.Features.Recipes.Commands.Handlers
{
    /// <summary>
    /// Handles all <see cref="ImportRecipeRequest"/> requests.
    /// </summary>
    public class ImportRecipeCommandHandler
        : BaseCommandHandler<ImportRecipeRequest, RecipeImportJobModel>
    {
        // TODO: Inject this?
        private const string QueueName = "import-recipe-queue";
        
        private readonly IQueueClientFactory<ImportRecipeMessage> _queueClientFactory;
        
        public ImportRecipeCommandHandler(
            IRecipeDomainContext recipeDomainContext,
            IQueueClientFactory<ImportRecipeMessage> queueClientFactory)
            : base(recipeDomainContext)
        {
            _queueClientFactory = queueClientFactory;
        }   
        
        /// <inheritdoc/>
        public override async Task<RecipeImportJobModel> Handle(ImportRecipeRequest request, CancellationToken cancellationToken)
        {
            var job = await CreateRecipeImportJob(request);

            await QueueJob(job, request);

            return RecipeImportJobModel.From(job);
        }

        private async Task<RecipeImportJob> CreateRecipeImportJob(ImportRecipeRequest request)
        {
            // Create the import job.
            var job = new RecipeImportJob()
            {
                UserId = request.User.Id,
                Status = RecipeImportJobStatus.Created
            };

            await RecipeDomainContext.RecipeImportJobs.AddAsync(job);

            await RecipeDomainContext.SaveChangesAsync();

            return job;
        }

        private async Task QueueJob(RecipeImportJob job, ImportRecipeRequest request)
        {
            var message = new ImportRecipeMessage()
            {
                JobId = job.Id,
                RecipeUrl = request.RecipeUrl,
                UserId = request.User.Id,
                Created = DateTime.Now
            };

            // Queue the job
            var queue = _queueClientFactory.GetSenderClient(QueueName);
            
            await queue.SendMessageAsync(message);
            
            // Update job status
            job.Status = RecipeImportJobStatus.Queued;

            await RecipeDomainContext.SaveChangesAsync();
        }
    }
}