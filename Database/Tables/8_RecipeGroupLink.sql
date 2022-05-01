USE RecipeManager

IF (NOT EXISTS (SELECT 1 
                FROM INFORMATION_SCHEMA.TABLES 
                WHERE TABLE_SCHEMA = 'dbo' 
                AND  TABLE_NAME = 'tblRecipeGroupLink'))
BEGIN
    CREATE TABLE dbo.tblRecipeGroupLink
    (
        recipeGroupLink_recipeGroupId UNIQUEIDENTIFIER,
        recipeGroupLink_recipeId UNIQUEIDENTIFIER
    )
END
