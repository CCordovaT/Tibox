CREATE PROCEDURE [dbo].[CustomerObtenerxNombre]
	@cFirstName VARCHAR(80),
	@cLastName VARCHAR(80)
AS
 BEGIN

	SELECT c.Id,
	       c.FirstName,
	       c.LastName,
	       c.City,
	       c.Country,
	       c.Phone
	  FROM Customer c
	 WHERE c.FirstName = @cFirstName
	       AND c.LastName = @cLastName

 END