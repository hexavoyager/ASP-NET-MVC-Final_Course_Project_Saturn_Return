/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

--EXEC RegisterClient @fname = 'David', @lname = 'Bowman', @bdate = '1970/05/30', @email = 'db@gmail.com', @pass = 'pw', @ccard = 'XXXX-XXXX-XXXX-XXXX', @idcard = 'A9F41KV', @book_count = DEFAULT, @is_vip = 1, @is_healthy = 1;
--EXEC RegisterClient @fname = 'John', @lname = 'Doe', @bdate = '1978/07/02', @email = 'jd@gmail.com', @pass = 'pw', @ccard = 'XXXX-XXXX-XXXX-XXXX', @idcard = 'Y3GN98B', @book_count = DEFAULT, @is_vip = 0, @is_healthy = 1;

--INSERT INTO [Planets] (
--    [name],
--    [capacity], 
--    [distance_m], 
--    [distance_h], 
--    [fuel_req], 
--    [atmosphere], 
--    [ports_count]
--    ) VALUES ('Saturn', 437, 120, 191, 50000, 'hydrogen', 1);

--INSERT INTO [Planets] (
--    [name],
--    [capacity], 
--    [distance_m], 
--    [distance_h], 
--    [fuel_req], 
--    [atmosphere], 
--    [ports_count]
--    ) VALUES ('Jupiter', 698, 444, 57, 3100, 'helium', 2);

--INSERT INTO [Users] ([fname], [lname], [bdate], [email], [pass], [ccard], [idcard], [book_count], [isAdmin]) VALUES ('Hal', '9000', 12/01/1992, 'h9@srite.com', 'pw', null, null, DEFAULT, 1);