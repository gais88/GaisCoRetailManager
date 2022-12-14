CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	[ProductName] nvarchar(100) not null, 
    [Desc] NVARCHAR(MAX) NOT NULL, 
	[RetailPrice]	MONEY NOT NULL,
	[QuantityInStock] int not null default 1,
    [CreatedData] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [LastModified] DATETIME2 NOT NULL DEFAULT getutcdate() 


)
