CREATE PROCEDURE [dbo].[AuthClient]
	@Email NVARCHAR(384),
	@Passwd NVARCHAR(50)
AS
BEGIN
	SELECT Id, fname, lname, bdate, email, ccard, idcard, book_count, is_vip, is_healthy
	FROM [Clients] 
	WHERE email = @Email
	AND pass = Hashbytes('SHA2_512', @Passwd);
	RETURN 0;
END