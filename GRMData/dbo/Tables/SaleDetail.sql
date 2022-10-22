CREATE TABLE [dbo].[SaleDetail]
(
	[Id] INT NOT NULL PRIMARY KEY Identity, 
    [SaleId] INT NOT NULL, 
    [ProductId] INT NOT NULL,
	[Quantity] int not null default 1,
	[PurchasePrice] Money NOT NULL ,
	[Tax] Money NOT NULL default 0


)
