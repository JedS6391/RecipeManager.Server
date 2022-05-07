USE RecipeManager

IF (NOT EXISTS (SELECT 1 
                FROM INFORMATION_SCHEMA.TABLES 
                WHERE TABLE_SCHEMA = 'dbo' 
                AND  TABLE_NAME = 'tblRecipeGroup'))
BEGIN
    CREATE TABLE dbo.tblRecipeGroup
    (
        recipeGroup_id UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
        recipeGroup_userId NVARCHAR(250),
        recipeGroup_name NVARCHAR(250),
    )
END
