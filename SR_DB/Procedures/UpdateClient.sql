CREATE PROCEDURE [dbo].[UpdateClient]
@Id int,
@book_count int
AS
BEGIN
UPDATE [Clients] Set [book_count] = @book_count WHERE Id = @Id;

RETURN 0
END
