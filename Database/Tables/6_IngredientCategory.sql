IF (NOT EXISTS (SELECT 1 
                FROM INFORMATION_SCHEMA.TABLES 
                WHERE TABLE_SCHEMA = 'dbo' 
                AND  TABLE_NAME = 'tblIngredientCategory'))
BEGIN
    CREATE TABLE dbo.tblIngredientCategory
    (
        ingredientCategory_id UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
        ingredientCategory_userId NVARCHAR(250),
        ingredientCategory_name NVARCHAR(250),
    )
END
