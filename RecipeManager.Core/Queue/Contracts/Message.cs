using System;

namespace RecipeManager.Core.Queue.Contracts
{
    /// <summary>
    /// Defines the base message contract.
    /// </summary>
    public abstract class Message
    {
        /// <summary>
        /// Gets the version of this message.
        /// </summary>
        public virtual string Version { get; } = "V1";
        
        /// <summary>
        /// Gets the date/time the message was created.
        /// </summary>
        public DateTime Created { get; set; }
    }
}