
CREATE TABLE [dbo].[Bookings]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [clientId] INT NOT NULL, 
    [planet] BIT NOT NULL, 
    [stopover] BIT NOT NULL,
    [planet_portId] INT  NULL,
    [dateA] DATETIME NOT NULL,
    [dateB] DATETIME NOT NULL,
    [is_1stclass] BIT NOT NULL, 
    [price] INT NOT NULL, 
    CONSTRAINT [FK_Bookings_Clients] FOREIGN KEY ([clientId]) REFERENCES [Clients]([Id])
    --CONSTRAINT [FK_Bookings_Ports] FOREIGN KEY ([planet_portId]) REFERENCES [Ports]([Id])
)
