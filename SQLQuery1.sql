CREATE DATABASE DBuserSignupLogin
GO
USE DBuserSignupLogin
GO

CREATE TABLE TBLUserInfo
(
	IDUs	INT IDENTITY PRIMARY KEY,
	UsernameUS VARCHAR (20),
	PassWordUs VARCHAR (255)
)