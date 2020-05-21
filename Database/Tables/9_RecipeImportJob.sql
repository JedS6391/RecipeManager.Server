IF (NOT EXISTS (SELECT 1 
                FROM INFORMATION_SCHEMA.TABLES 
                WHERE TABLE_SCHEMA = 'dbo' 
                AND  TABLE_NAME = 'tblRecipeImportJob'))
BEGIN
    CREATE TABLE dbo.tblRecipeImportJob
    (
        recipeImportJob_id UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
        recipeImportJob_userId NVARCHAR(250),
        recipeImportJob_status NVARCHAR(100),
    )
END
