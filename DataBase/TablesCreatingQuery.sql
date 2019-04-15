CREATE TABLE Users (
userId INT PRIMARY KEY IDENTITY (1,1),
userPhoneNumber  NVARCHAR(11),
userNameSurname NVARCHAR(100),
userLoginName NVARCHAR(100),
userPassword NVARCHAR(25),
userImageUrl NVARCHAR(250)
)
GO
CREATE TABLE Groups(
groupId INT PRIMARY KEY IDENTITY (1,1),
groupName NVARCHAR(150),
textFk INT,
groupImageUrl NVARCHAR(250)
)
GO
CREATE TABLE TextMessage(
textId INT PRIMARY KEY IDENTITY(1,1),
textOwner NVARCHAR(100),
textContent NVARCHAR(MAX),
groupFk INT,
textDate SMALLDATETIME
)
GO
CREATE TABLE Manager(
managerId INT PRIMARY KEY IDENTITY(1,1),
managerNameSurname NVARCHAR(100)
)
GO
CREATE TABLE Asistance(
asistanceId INT PRIMARY KEY IDENTITY (1,1),
asistanceNameSurname NVARCHAR(100)
)