CREATE TABLE [dbo].[Clients]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [fname] NVARCHAR(50) NOT NULL, 
    [lname] NVARCHAR(50) NOT NULL, 
    [bdate] DATETIME NOT NULL, 
    [email] NVARCHAR(50) NOT NULL, 
    [pass] NVARCHAR(50) NOT NULL,
    [ccard] NVARCHAR(50) NOT NULL, 
    [idcard] NVARCHAR(50) NOT NULL, 
    [book_count] INT NOT NULL DEFAULT 0, 
    [is_vip] BIT NOT NULL DEFAULT 0, 
    [is_healthy] BIT NOT NULL, 
)
