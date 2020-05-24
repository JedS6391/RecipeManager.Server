using System;
using System.Collections.Generic;
using RecipeManager.Core.Queue.Abstract;
using RecipeManager.Core.Queue.Contracts;

namespace RecipeManager.Core.Queue.Azure
{
    /// <summary>
    /// An implementation of <see cref="IQueueNameProvider"/> that will provide the names
    /// of Azure storage queues. 
    /// </summary>
    public class AzureQueueNameProvider : IQueueNameProvider
    {
        private static readonly IDictionary<Type, string> QueueNameByTypeLookup = new Dictionary<Type, string>()
        {
            { typeof(ImportRecipeMessage), "import-recipe-queue" }
        };
        
        /// <inheritdoc/>
        public string GetQueueNameForMessageType<TMessage>() where TMessage : Message
        {
            if (!QueueNameByTypeLookup.TryGetValue(typeof(TMessage), out var queueName))
            {
                throw new ArgumentOutOfRangeException($"No queue name defined for message of type {typeof(TMessage).Name}");
            }

            return queueName;
        }
    }
}