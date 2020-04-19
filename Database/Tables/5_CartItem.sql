IF NOT EXISTS (SELECT 1 
               FROM INFORMATION_SCHEMA.TABLES 
               WHERE TABLE_SCHEMA = 'dbo' 
               AND  TABLE_NAME = 'tblCartItem')
BEGIN
    CREATE TABLE dbo.tblCartItem
    (
        cartItem_id UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
        cartItem_cartId UNIQUEIDENTIFIER,
        cartItem_createdDate DATETIME,
        cartItem_ingredientId UNIQUEIDENTIFIER
    )
END

