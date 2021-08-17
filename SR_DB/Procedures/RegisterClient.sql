CREATE PROCEDURE [dbo].[RegisterClient]
	@fname NVARCHAR(75),
	@lname NVARCHAR(75),
	@bdate DATETIME,
	@email NVARCHAR(75),
	@pass NVARCHAR(50),
	@ccard NVARCHAR(16),
	@idcard NVARCHAR(12),
	@book_count INT = 0,
	@is_vip BIT,
	@is_healthy BIT = 1
AS
BEGIN
	INSERT INTO [Clients] (fname, lname, bdate, email, pass, ccard, idcard, book_count, is_vip, is_healthy) VALUES (@fname, @lname, @bdate, @email, Hashbytes('SHA2_512', @pass), @ccard, @idcard, @book_count, @is_vip, @is_healthy)
RETURN 0
END