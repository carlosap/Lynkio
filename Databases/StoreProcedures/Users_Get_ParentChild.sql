/*
Users_Get_ParentChild: 
Provides users tree releations and roles.

*/
IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'Users_Get_ParentChild') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [Users_Get_ParentChild]
GO

CREATE PROCEDURE [Users_Get_ParentChild]
AS
BEGIN
SELECT        Users.Id, Users.UserName,Users.PasswordHash, Users.FirstName, Users.LastName, Users.Email, Users.EmailNotification, Users.EmailConfirmed, Users.PhoneNumber, Users.PhoneNotification, ParentUser.ReportsTo, 
                         Roles.Name AS Role
FROM            Users INNER JOIN
                         Users AS ParentUser ON Users.Id = ParentUser.Id INNER JOIN
                         UserRoles ON Users.Id = UserRoles.UserId INNER JOIN
                         Roles ON UserRoles.RoleId = Roles.Id
END;

GO


