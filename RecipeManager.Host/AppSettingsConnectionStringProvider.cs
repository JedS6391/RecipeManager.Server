using System;
using Microsoft.Extensions.Configuration;
using RecipeManager.Core.Data.Abstract;

namespace RecipeManager.Host
{
    /// <summary>
    /// An implementation of <see cref="IConnectionStringProvider"/> that reads a connection string from <see cref="IConfiguration"/>.
    /// </summary>
    public class AppSettingsConnectionStringProvider : IConnectionStringProvider
    {
        private readonly Lazy<string> _connectionString;

        public AppSettingsConnectionStringProvider(IConfiguration configuration)
        {
            _connectionString = new Lazy<string>(() =>
                configuration.GetValue<string>("Database:ConnectionString"));
                
        }

        public string ConnectionString => _connectionString.Value;
    }
}
