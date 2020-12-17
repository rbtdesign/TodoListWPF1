CREATE PROCEDURE [dbo].[spUpdateTodo]
	@id int,
	@title nvarchar(100),
	@isCompleted bit
AS

BEGIN
	UPDATE Todos
	SET Title = @title, IsCompleted = @isCompleted
	WHERE Id = @id;
END
