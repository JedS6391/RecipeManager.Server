USE RecipeManager

IF NOT EXISTS (SELECT 1 
               FROM INFORMATION_SCHEMA.TABLES 
               WHERE TABLE_SCHEMA = 'dbo' 
               AND  TABLE_NAME = 'tblRecipe')
BEGIN
    CREATE TABLE dbo.tblRecipe
    (
        recipe_id UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
        recipe_name NVARCHAR(250),
        recipe_userId NVARCHAR(250)
    )
END

