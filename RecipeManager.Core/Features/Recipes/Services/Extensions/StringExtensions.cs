using System;
using System.Linq;

namespace RecipeManager.Core.Features.Recipes.Services.Extensions
{
    /// <summary>
    /// Extensions for the <see cref="string"/> class.
    /// </summary>
    public static class StringExtensions
    {
        public static string FirstCharToUpper(this string input) =>
            input switch
            {
                null => throw new ArgumentNullException(nameof(input)),
                "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
                _ => input.First().ToString().ToUpper() + input.Substring(1)
            };
    }
}