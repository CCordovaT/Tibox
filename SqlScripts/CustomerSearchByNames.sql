CREATE PROCEDURE dbo.CustomerSearchByNames
	@firstName nvarchar(40),
	@lastName nvarchar(40)
AS
BEGIN	
	SET NOCOUNT ON;
	SELECT [Id]
      ,[FirstName]
      ,[LastName]
      ,[City]
      ,[Country]
      ,[Phone]
	  FROM dbo.Customer
	  WHERE FirstName=@firstName AND LastName=@lastName
	SET NOCOUNT OFF;
END
GO
