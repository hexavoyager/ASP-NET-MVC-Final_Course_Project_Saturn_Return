CREATE TABLE [dbo].[Ports]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [name] NVARCHAR(50) NOT NULL, 
    [planetId] INT NOT NULL,
    [capacity] INT NOT NULL, 
    CONSTRAINT [FK_Ports_ToTable_Planets] FOREIGN KEY ([planetId]) REFERENCES [Planets]([Id])
)
