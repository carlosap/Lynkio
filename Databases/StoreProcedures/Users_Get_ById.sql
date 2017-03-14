/*
Users_Get_ById: Ensures user at contains roles
*/
IF EXISTS(SELECT Name FROM SYS.Objects WHERE Object_ID = OBJECT_ID(N'Users_Get_ById') AND TYPE IN(N'P', N'PC'))
	DROP PROCEDURE [Users_Get_ById]
GO

CREATE PROCEDURE [Users_Get_ById]
	@Id INT
AS
BEGIN
SELECT        Users.Id, Users.UserName,Users.PasswordHash, Users.FirstName, Users.LastName, Users.Email, Users.EmailNotification, Users.EmailConfirmed, Users.PhoneNumber, Users.PhoneNotification, ParentUser.ReportsTo, 
                         Roles.Name AS Role
FROM            Users INNER JOIN
                         Users AS ParentUser ON Users.Id = ParentUser.Id INNER JOIN
                         UserRoles ON Users.Id = UserRoles.UserId INNER JOIN
                         Roles ON UserRoles.RoleId = Roles.Id
WHERE        (Users.Id = @Id)
END;
GO



