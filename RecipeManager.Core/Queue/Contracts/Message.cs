using System;

namespace RecipeManager.Core.Queue.Contracts
{
    public abstract class Message
    {
        public virtual string Version { get; } = "V1";
        public DateTime Created { get; set; }
    }
}