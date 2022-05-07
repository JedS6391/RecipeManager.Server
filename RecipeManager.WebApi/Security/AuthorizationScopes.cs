namespace RecipeManager.WebApi.Security
{
    /// <summary>
    /// Defines the various authorization scopes for available API resources.
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

        /// <summary>
        /// Defines the authorization scopes for the cart resources.
        /// </summary>
        public static class Cart
        {
            /// <summary>
            /// The read scope.
            /// </summary>
            public const string Read = "read:cart";

            /// <summary>
            /// The write scope.
            /// </summary>
            public const string Write = "write:cart";
        }
    }
}
