CREATE TABLE [dbo].[Planets]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [name] NVARCHAR(50) NOT NULL, 
    [capacity] INT NOT NULL, 
    [distance_m] INT NOT NULL,
    [distance_h] INT NOT NULL,
    [fuel_req] INT NOT NULL,
    [atmosphere] NVARCHAR(10) NOT NULL, 
    [ports_count] INT NOT NULL
)
