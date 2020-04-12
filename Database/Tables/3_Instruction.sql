USE RecipeManager;

IF (NOT EXISTS (SELECT 1 
                FROM INFORMATION_SCHEMA.TABLES 
                WHERE TABLE_SCHEMA = 'dbo' 
                AND  TABLE_NAME = 'tblInstruction'))
BEGIN
    CREATE TABLE dbo.tblInstruction
    (
        instruction_id UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
        instruction_recipeId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES tblRecipe(recipe_id),
        instruction_sequence INT,
        instruction_details NVARCHAR(MAX)
    )
END

