namespace RecipeManager.WebApi.Security
{
    /// <summary>
    /// Defines the various authorization scopes for the resources.
    /// </summary>
    public static class AuthorizationScopes
    {
        /// <summary>
        /// Defines the authorization scopes for the recipes resources.
        /// </summary>
        public static class Recipes
        {
            /// <summary>
            /// The read scope.
            /// </summary>
            public const string Read = "read:recipes";

            /// <summary>
            /// The write scope.
            /// </summary>
            public const string Write = "write:recipes";
        }
    }
}
