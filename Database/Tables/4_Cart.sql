USE RecipeManager

IF NOT EXISTS (SELECT 1 
               FROM INFORMATION_SCHEMA.TABLES 
               WHERE TABLE_SCHEMA = 'dbo' 
               AND  TABLE_NAME = 'tblCart')
BEGIN
    CREATE TABLE dbo.tblCart
    (
        cart_id UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
        cart_userId NVARCHAR(250),
        cart_createdDate DATETIME,
        cart_isCurrent BIT
    )
END

