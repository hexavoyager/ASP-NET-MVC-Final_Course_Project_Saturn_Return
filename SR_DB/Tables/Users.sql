CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [fname] NVARCHAR(50) NOT NULL, 
    [lname] NVARCHAR(50) NOT NULL, 
    [bdate] DATETIME NOT NULL, 
    [email] NVARCHAR(50) NOT NULL, 
    [pass] NVARCHAR(50) NOT NULL,
    [ccard] NVARCHAR(50) NULL,
    [idcard] INT NULL, 
    [book_count] INT NOT NULL DEFAULT 0,
    [isAdmin] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_Users_ToTable_Clients] FOREIGN KEY ([Id]) REFERENCES [Clients]([Id])
)
