CREATE PROCEDURE [dbo].[spGetTodoById]
	@id int
AS
BEGIN
	SELECT Title, IsCompleted FROM Todos WHERE Id = @id
END