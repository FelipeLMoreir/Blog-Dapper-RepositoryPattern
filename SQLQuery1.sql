SELECT * FROM Category
SELECT * FROM [User]

SELECT *
FROM [User] u
JOIN UserRole ur
ON u.Id = ur.UserId
JOIN [Role] r
ON r.Id = ur.RoleId


