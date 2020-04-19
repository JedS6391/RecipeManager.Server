IF (NOT EXISTS (SELECT 1 
                FROM INFORMATION_SCHEMA.TABLES 
                WHERE TABLE_SCHEMA = 'dbo' 
                AND  TABLE_NAME = 'tblIngredient'))
BEGIN
    CREATE TABLE dbo.tblIngredient
    (
        ingredient_id UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
        ingredient_recipeId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES tblRecipe(recipe_id),
        ingredient_name NVARCHAR(250),
        ingredient_amount NVARCHAR(250)
    )
END
