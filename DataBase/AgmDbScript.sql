USE [master]
GO
/****** Object:  Database [Agm]    Script Date: 26.04.2019 21:44:11 ******/
CREATE DATABASE [Agm]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Agm', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Agm.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Agm_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Agm_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Agm] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Agm].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Agm] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Agm] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Agm] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Agm] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Agm] SET ARITHABORT OFF 
GO
ALTER DATABASE [Agm] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Agm] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Agm] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Agm] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Agm] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Agm] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Agm] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Agm] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Agm] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Agm] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Agm] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Agm] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Agm] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Agm] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Agm] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Agm] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Agm] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Agm] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Agm] SET  MULTI_USER 
GO
ALTER DATABASE [Agm] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Agm] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Agm] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Agm] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Agm] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Agm]
GO
/****** Object:  Table [dbo].[Asistance]    Script Date: 26.04.2019 21:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asistance](
	[asistanceId] [int] IDENTITY(1,1) NOT NULL,
	[asistanceNameSurname] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[asistanceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GroupAsistance]    Script Date: 26.04.2019 21:44:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupAsistance](
	[groupFk] [int] NOT NULL,
	[asistanceFk] [int] NOT NULL,
 CONSTRAINT [PK_GroupAsistance] PRIMARY KEY CLUSTERED 
(
	[groupFk] ASC,
	[asistanceFk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Groups]    Script Date: 26.04.2019 21:44:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[groupId] [int] IDENTITY(1,1) NOT NULL,
	[groupName] [nvarchar](150) NULL,
	[textFk] [int] NULL,
	[groupImageUrl] [nvarchar](250) NULL,
	[managerFk] [int] NULL,
	[groupCode] [nchar](8) NULL,
PRIMARY KEY CLUSTERED 
(
	[groupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Manager]    Script Date: 26.04.2019 21:44:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manager](
	[managerId] [int] IDENTITY(1,1) NOT NULL,
	[managerNameSurname] [nvarchar](100) NULL,
	[userFk] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[managerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TextMessage]    Script Date: 26.04.2019 21:44:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TextMessage](
	[textId] [int] IDENTITY(1,1) NOT NULL,
	[textOwner] [nvarchar](100) NULL,
	[textContent] [nvarchar](max) NULL,
	[groupFk] [int] NULL,
	[textDate] [smalldatetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[textId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 26.04.2019 21:44:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[userId] [int] IDENTITY(1,1) NOT NULL,
	[userPhoneNumber] [nvarchar](11) NULL,
	[userNameSurname] [nvarchar](100) NULL,
	[userLoginName] [nvarchar](100) NULL,
	[userPassword] [nvarchar](25) NULL,
	[userImageUrl] [nvarchar](250) NULL,
	[userEmail] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UsersGroup]    Script Date: 26.04.2019 21:44:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersGroup](
	[usersFk] [int] NOT NULL,
	[groupFk] [int] NOT NULL,
 CONSTRAINT [PK_UsersGroup] PRIMARY KEY CLUSTERED 
(
	[usersFk] ASC,
	[groupFk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([userId], [userPhoneNumber], [userNameSurname], [userLoginName], [userPassword], [userImageUrl], [userEmail]) VALUES (17, N'55329022943', N'test', N'test', N'asd', N'/User_Images/default.png', N'test@gmail.com')
INSERT [dbo].[Users] ([userId], [userPhoneNumber], [userNameSurname], [userLoginName], [userPassword], [userImageUrl], [userEmail]) VALUES (18, N'05532902294', N'Emre Sert', N'emre', N'asd', N'/User_Images/images.jpg', N'emresert1233@gmail.com')
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[GroupAsistance]  WITH CHECK ADD  CONSTRAINT [FK_GroupAsistance_Asistance] FOREIGN KEY([asistanceFk])
REFERENCES [dbo].[Asistance] ([asistanceId])
GO
ALTER TABLE [dbo].[GroupAsistance] CHECK CONSTRAINT [FK_GroupAsistance_Asistance]
GO
ALTER TABLE [dbo].[GroupAsistance]  WITH CHECK ADD  CONSTRAINT [FK_GroupAsistance_Groups] FOREIGN KEY([groupFk])
REFERENCES [dbo].[Groups] ([groupId])
GO
ALTER TABLE [dbo].[GroupAsistance] CHECK CONSTRAINT [FK_GroupAsistance_Groups]
GO
ALTER TABLE [dbo].[Groups]  WITH CHECK ADD  CONSTRAINT [FK_Groups_Manager] FOREIGN KEY([managerFk])
REFERENCES [dbo].[Manager] ([managerId])
GO
ALTER TABLE [dbo].[Groups] CHECK CONSTRAINT [FK_Groups_Manager]
GO
ALTER TABLE [dbo].[Groups]  WITH CHECK ADD  CONSTRAINT [FK_Groups_TextMessage] FOREIGN KEY([textFk])
REFERENCES [dbo].[TextMessage] ([textId])
GO
ALTER TABLE [dbo].[Groups] CHECK CONSTRAINT [FK_Groups_TextMessage]
GO
ALTER TABLE [dbo].[Manager]  WITH CHECK ADD  CONSTRAINT [FK_Manager_Users] FOREIGN KEY([userFk])
REFERENCES [dbo].[Users] ([userId])
GO
ALTER TABLE [dbo].[Manager] CHECK CONSTRAINT [FK_Manager_Users]
GO
ALTER TABLE [dbo].[UsersGroup]  WITH CHECK ADD  CONSTRAINT [FK_UsersGroup_Groups] FOREIGN KEY([groupFk])
REFERENCES [dbo].[Groups] ([groupId])
GO
ALTER TABLE [dbo].[UsersGroup] CHECK CONSTRAINT [FK_UsersGroup_Groups]
GO
ALTER TABLE [dbo].[UsersGroup]  WITH CHECK ADD  CONSTRAINT [FK_UsersGroup_Users] FOREIGN KEY([usersFk])
REFERENCES [dbo].[Users] ([userId])
GO
ALTER TABLE [dbo].[UsersGroup] CHECK CONSTRAINT [FK_UsersGroup_Users]
GO
/****** Object:  StoredProcedure [dbo].[spAddUserGroups]    Script Date: 26.04.2019 21:44:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spAddUserGroups] (@userFk int,@groupFk int) as
declare @u int
select @u= userId from Users where userId = @userFk
declare @g int
select @g= groupId from Groups where groupId = @groupFk
insert into UsersGroup (usersFk,groupFk) values (@u,@g)
GO
/****** Object:  StoredProcedure [dbo].[spGroupJoin]    Script Date: 26.04.2019 21:44:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spGroupJoin] (@userId int,@groupId int) as
insert into UsersGroup (usersFk,groupFk) values(@userId,@groupId)
GO
/****** Object:  StoredProcedure [dbo].[spGroupsManager]    Script Date: 26.04.2019 21:44:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spGroupsManager] (@userId int)
as 
select groupId,groupName,groupImageUrl,managerNameSurname,managerId,userFk from Groups g 
inner join Manager m on g.managerFk = m.managerId inner join Users u on u.userId = m.userFk where u.userId = @userId
GO
/****** Object:  StoredProcedure [dbo].[spLeaveGroup]    Script Date: 26.04.2019 21:44:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spLeaveGroup](@userId int,@groupId int)
as
delete UsersGroup from Groups g
 inner join UsersGroup ug on ug.groupFk = g.groupId 
 inner join Users u on u.userId = ug.usersFk
 where u.userId= @userId and g.groupId=@groupId

GO
/****** Object:  StoredProcedure [dbo].[spUserGroup]    Script Date: 26.04.2019 21:44:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spUserGroup](@id int)
as
select groupId,groupName,groupImageUrl from groups g inner join UsersGroup ug 
on g.groupId = ug.groupFk inner join Users u 
on ug.usersFk = u.userId where usersFk=@id

GO
/****** Object:  StoredProcedure [dbo].[userGroupsUsidGrpid]    Script Date: 26.04.2019 21:44:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[userGroupsUsidGrpid](@id int , @groupid int)
as
select groupId,groupName,groupImageUrl from groups g inner join UsersGroup ug 
on g.groupId = ug.groupFk inner join Users u 
on ug.usersFk = u.userId where usersFk=@id and groupId=@groupid
GO
USE [master]
GO
ALTER DATABASE [Agm] SET  READ_WRITE 
GO
