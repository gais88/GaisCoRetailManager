CREATE PROCEDURE [dbo].[spProducts_GetAll]
as
begin

	SELECT Id,ProductName,[Desc],[RetailPrice],[QuantityInStock]
	from [Product]
	order by ProductName

end
