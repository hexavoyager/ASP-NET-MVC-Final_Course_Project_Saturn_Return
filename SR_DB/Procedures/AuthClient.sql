CREATE PROCEDURE [dbo].[AuthClient]
	@Email NVARCHAR(384),
	@Passwd NVARCHAR(50)
AS
BEGIN
	SELECT Id, fname, lname, bdate, email, pass, ccard, idcard, book_count, is_vip, is_healthy
	FROM [Clients] 
	WHERE email = @Email
	AND pass = @Passwd
	RETURN 0;
END