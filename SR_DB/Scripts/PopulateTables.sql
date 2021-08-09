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

--INSERT INTO [Clients] ([fname], [lname], [bdate], [email], [pass], [ccard], [idcard], [book_count], [is_vip], [is_healthy]) VALUES ('David', 'Bowman', 30/05/1970, 'db@gmail.com', 'pw', 'XXXX-XXXX-XXXX-XXXX', 'A9F41KV', DEFAULT, 1, 1);
--INSERT INTO [Clients] ([fname], [lname], [bdate], [email], [pass], [ccard], [idcard], [book_count], [is_vip], [is_healthy]) VALUES ('John', 'Doe', 02/07/1978, 'jd@gmail.com', 'pw', 'XXXX-XXXX-XXXX-XXXX', 'Y3GN98B', DEFAULT, DEFAULT, 1);

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