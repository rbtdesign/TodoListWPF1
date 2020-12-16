CREATE PROCEDURE [dbo].[spAddTodo]
	@title nvarchar(100)
AS

BEGIN
	INSERT into Todos(Title) VALUES(@title)
	SELECT Cast(SCOPE_IDENTITY() AS INT)
END

-- Don't forget to precise the (columns when receiving partial payload)