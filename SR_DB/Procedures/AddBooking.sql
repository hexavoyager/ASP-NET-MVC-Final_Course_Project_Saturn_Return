CREATE PROCEDURE [dbo].[AddBooking]
	@clientId INT,
	@planet BIT,
	@stopover BIT,
	@planet_portId INT,
	@dateA DATETIME,
	@dateB DATETIME,
	@is_1stclass BIT,
	@price INT
AS
BEGIN
	INSERT INTO [Bookings] (clientId, planet, stopover, planet_portId, dateA, dateB, is_1stclass, price) VALUES (@clientId, @planet, @stopover, @planet_portId, @dateA, @dateB, @is_1stclass, @price);
	RETURN 0
end