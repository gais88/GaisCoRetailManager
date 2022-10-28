CREATE PROCEDURE [dbo].[spUserLookUp]
	@Id nvarchar(128)
AS
begin
    set nocount on;
	SELECT *
	from [dbo].[User]
	where Id = Id
end
