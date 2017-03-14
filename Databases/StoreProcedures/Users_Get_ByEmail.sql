/*
Users_Get_ByEmail: 
Ensures user at contains roles. Filter by Email
*/
IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'Users_Get_ByEmail') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [Users_Get_ByEmail]
GO

CREATE PROCEDURE [Users_Get_ByEmail]
	@EMAIL NVARCHAR(250)
AS
BEGIN
SELECT        Users.Id, Users.UserName,Users.PasswordHash, Users.FirstName, Users.LastName, Users.Email, Users.EmailNotification, Users.EmailConfirmed, Users.PhoneNumber, Users.PhoneNotification, ParentUser.ReportsTo, 
                         Roles.Name AS Role
FROM            Users INNER JOIN
                         Users AS ParentUser ON Users.Id = ParentUser.Id INNER JOIN
                         UserRoles ON Users.Id = UserRoles.UserId INNER JOIN
                         Roles ON UserRoles.RoleId = Roles.Id
WHERE        (Users.Email = @EMAIL)
END;
GO



