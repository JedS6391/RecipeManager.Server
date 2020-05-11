using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RecipeManager.Core.Features.Recipes.Commands.Requests;
using RecipeManager.Core.Queue.Abstract;
using RecipeManager.Core.Queue.Contracts;

namespace RecipeManager.Core.Features.Recipes.Commands.Handlers
{
    public class ImportRecipeCommandHandler
        : IRequestHandler<ImportRecipeRequest>
    {
        // TODO: Inject this?
        private const string QueueName = "import-recipe-queue"; 
        private readonly IQueueClientFactory<ImportRecipeMessage> _queueClientFactory;
        
        public ImportRecipeCommandHandler(IQueueClientFactory<ImportRecipeMessage> queueClientFactory)
        {
            _queueClientFactory = queueClientFactory;
        }   
        
        public async Task<Unit> Handle(ImportRecipeRequest request, CancellationToken cancellationToken)
        {
            var message = new ImportRecipeMessage()
            {
                RecipeUrl = request.RecipeUrl,
                UserId = request.User.Id,
                Created = DateTime.Now
            };

            var queue = _queueClientFactory.GetSenderClient(QueueName);
            
            await queue.SendMessageAsync(message);
            
            return Unit.Value;
        }
    }
}