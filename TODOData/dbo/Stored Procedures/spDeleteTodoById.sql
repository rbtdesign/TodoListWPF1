CREATE PROCEDURE [dbo].[spDeleteTodoById]
	@id int
AS
BEGIN
	DELETE from Todos WHERE Id = @id
END