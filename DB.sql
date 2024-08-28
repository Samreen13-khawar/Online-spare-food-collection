USE [master]
GO
/****** Object:  Database [FoodCollectionDB]    Script Date: 12/4/2023 7:39:01 PM ******/
CREATE DATABASE [FoodCollectionDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FoodCollectionDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\FoodCollectionDB.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'FoodCollectionDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\FoodCollectionDB_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [FoodCollectionDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FoodCollectionDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FoodCollectionDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FoodCollectionDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FoodCollectionDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FoodCollectionDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FoodCollectionDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [FoodCollectionDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [FoodCollectionDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FoodCollectionDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FoodCollectionDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FoodCollectionDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FoodCollectionDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FoodCollectionDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FoodCollectionDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FoodCollectionDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FoodCollectionDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [FoodCollectionDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FoodCollectionDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FoodCollectionDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FoodCollectionDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FoodCollectionDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FoodCollectionDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FoodCollectionDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FoodCollectionDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FoodCollectionDB] SET  MULTI_USER 
GO
ALTER DATABASE [FoodCollectionDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FoodCollectionDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FoodCollectionDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FoodCollectionDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [FoodCollectionDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [FoodCollectionDB]
GO
/****** Object:  Table [dbo].[DonatedFood]    Script Date: 12/4/2023 7:39:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonatedFood](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DonatedBy] [int] NOT NULL,
	[FoodName] [nvarchar](250) NULL,
	[Quantity] [nvarchar](250) NULL,
	[ManufacturedDate] [datetime] NULL,
	[ExpiryDate] [date] NULL,
	[Status] [nvarchar](250) NULL,
	[City] [nvarchar](250) NULL,
 CONSTRAINT [PK_DonatedFood] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FoodRequests]    Script Date: 12/4/2023 7:39:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodRequests](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FoodName] [nvarchar](250) NULL,
	[FamilyMember] [int] NOT NULL,
	[Discription] [nvarchar](550) NULL,
	[Status] [nvarchar](250) NULL,
	[City] [nvarchar](250) NULL,
	[FkUser] [int] NOT NULL,
 CONSTRAINT [PK_FoodRequests] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/4/2023 7:39:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](250) NULL,
	[LastName] [nvarchar](250) NULL,
	[City] [nvarchar](250) NULL,
	[Address] [nvarchar](250) NULL,
	[PhoneNo] [nvarchar](250) NULL,
	[Email] [nvarchar](50) NULL,
	[PasswordHash] [nvarchar](500) NULL,
	[Type] [nvarchar](250) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[DonatedFood] ON 

INSERT [dbo].[DonatedFood] ([Id], [DonatedBy], [FoodName], [Quantity], [ManufacturedDate], [ExpiryDate], [Status], [City]) VALUES (6, 4, N'Pasta', N'4 kg', CAST(N'2023-12-12 00:00:00.000' AS DateTime), CAST(N'2023-12-23' AS Date), N'Sent To Needy - Done', N'Karachi')
INSERT [dbo].[DonatedFood] ([Id], [DonatedBy], [FoodName], [Quantity], [ManufacturedDate], [ExpiryDate], [Status], [City]) VALUES (7, 4, N'biryani', N'4 kg', CAST(N'2023-12-15 00:00:00.000' AS DateTime), CAST(N'2023-12-16' AS Date), N'Reached at Collection Center', N'Islamabad')
SET IDENTITY_INSERT [dbo].[DonatedFood] OFF
SET IDENTITY_INSERT [dbo].[FoodRequests] ON 

INSERT [dbo].[FoodRequests] ([Id], [FoodName], [FamilyMember], [Discription], [Status], [City], [FkUser]) VALUES (4, N'biryani', 7, N'dfgrfrg', N'Rejected', N'Lahore', 27)
INSERT [dbo].[FoodRequests] ([Id], [FoodName], [FamilyMember], [Discription], [Status], [City], [FkUser]) VALUES (5, N'pasta', 5, N'dfgr', N'Sent - Done', N'Lahore', 27)
INSERT [dbo].[FoodRequests] ([Id], [FoodName], [FamilyMember], [Discription], [Status], [City], [FkUser]) VALUES (6, N'sff', 6, N'fggh', N'Accepted', N'Lahore', 27)
SET IDENTITY_INSERT [dbo].[FoodRequests] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [City], [Address], [PhoneNo], [Email], [PasswordHash], [Type]) VALUES (1, N'samreen', N'khawar', N'Lahore', N'lahore', N'77777', N'a@m.com', N'MTIz', N'Donator')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [City], [Address], [PhoneNo], [Email], [PasswordHash], [Type]) VALUES (2, N'sam', N'khawar', N'Karachi', N'karachi', N'88', N'a@s.com', N'MTIz', N'Donator')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [City], [Address], [PhoneNo], [Email], [PasswordHash], [Type]) VALUES (3, N'sam', N'khawar', N'Karachi', N'karachi', N'88', N'a@o.com', N'MTIz', N'Donator')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [City], [Address], [PhoneNo], [Email], [PasswordHash], [Type]) VALUES (4, N'sm', N'ii', N'Karachi', N'karachi', N'888', N'A@e.com', N'MTIz', N'Donator')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [City], [Address], [PhoneNo], [Email], [PasswordHash], [Type]) VALUES (5, N'samreen', N'khawar', N'Karachi', N'lahore', N'777', N'a@u.com', N'MTIz', N'Donator')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [City], [Address], [PhoneNo], [Email], [PasswordHash], [Type]) VALUES (6, N'samreen', N'khawar', N'Islamabad', N'lahore', N'777', N'a@q.com', N'MTIz', N'Donator')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [City], [Address], [PhoneNo], [Email], [PasswordHash], [Type]) VALUES (7, N'samreen', N'ii', N'Lahore', N'lahore', N'777', N'a@h.com', N'MTIz', N'Donator')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [City], [Address], [PhoneNo], [Email], [PasswordHash], [Type]) VALUES (8, N'mirha', N'khawar', N'Choose...', N'karachi', N'77777', N'f@f.com', N'MTIz', N'Donator')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [City], [Address], [PhoneNo], [Email], [PasswordHash], [Type]) VALUES (9, N'sam', N'ii', N'Islamabad', N'karachi', N'77777', N'a@b.com', N'MTIz', N'Donator')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [City], [Address], [PhoneNo], [Email], [PasswordHash], [Type]) VALUES (11, N'tayyaba', N'khawar', N'Lahore', N'lahore', N'888', N'a@l.com', N'MTIz', N'Donator')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [City], [Address], [PhoneNo], [Email], [PasswordHash], [Type]) VALUES (12, N'ffa', N'khawar', N'Islamabad', N'lahore', N'77777', N'A@EPCOM', N'MTIz', N'Donator')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [City], [Address], [PhoneNo], [Email], [PasswordHash], [Type]) VALUES (13, N'samreen', N'khawar', N'Lahore', N'lahore', N'777', N'A@aa.com', N'MTIz', N'Donator')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [City], [Address], [PhoneNo], [Email], [PasswordHash], [Type]) VALUES (14, N'fari', N'khawar', N'Lahore', N'lahore', N'77777', N'a@aaa.com', N'MTIz', N'Donator')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [City], [Address], [PhoneNo], [Email], [PasswordHash], [Type]) VALUES (15, N'samreen', N'khawar', N'Karachi', N'lahore', N'777', N'a@w.com', N'MTIz', N'Donator')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [City], [Address], [PhoneNo], [Email], [PasswordHash], [Type]) VALUES (16, N'abeeha00', N'khan00', N'Karachi', N'lahore00', N'7777700', N'a@uu.com', N'MTIz', N'Donator')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [City], [Address], [PhoneNo], [Email], [PasswordHash], [Type]) VALUES (17, N'samreen', N'khawar', N'Lahore', N'lahore', N'0000', N'a@ab.com', N'MTIz', N'Donator')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [City], [Address], [PhoneNo], [Email], [PasswordHash], [Type]) VALUES (18, N'test', N'samreen', N'Lahore', N'lahore', N'03154489759', N'a@ba.com', N'MTIz', N'Donator')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [City], [Address], [PhoneNo], [Email], [PasswordHash], [Type]) VALUES (19, N'sam', N'ii', N'Karachi', N'karachi', N'88', N'a@j.com', N'MTIz', N'Donator')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [City], [Address], [PhoneNo], [Email], [PasswordHash], [Type]) VALUES (21, N'sam', N'khawar', N'Karachi', N'lahore', N'77777', N'a@ww.com', N'MTIz', N'Donator')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [City], [Address], [PhoneNo], [Email], [PasswordHash], [Type]) VALUES (22, N'samreen', N'khawar', N'Karachi', N'karachi', N'77777', N'a@c.com', N'MTIz', N'Donator')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [City], [Address], [PhoneNo], [Email], [PasswordHash], [Type]) VALUES (23, N'samreen', N'khawar', N'Karachi', N'lahore', N'77777', N'a@p.com', N'MTIz', N'Donator')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [City], [Address], [PhoneNo], [Email], [PasswordHash], [Type]) VALUES (24, N'Admin', N'--kk', N'Lahore', N'Lahore Pakistan', N'1111', N'Admin@FS.com', N'MTIz', N'Admin')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [City], [Address], [PhoneNo], [Email], [PasswordHash], [Type]) VALUES (25, N'eeee', N'eeee', N'Lahore', N'eeee', N'333', N'fe@fe.com', N'MTIzMzM=', N'Donator')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [City], [Address], [PhoneNo], [Email], [PasswordHash], [Type]) VALUES (26, N'fgf', N'rrr', N'Karachi', N'ffff', N'4444', N'kj@f.com', N'MTIz', N'Donator')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [City], [Address], [PhoneNo], [Email], [PasswordHash], [Type]) VALUES (27, N'yyy', N'yyy', N'Lahore', N'yy', N'6666', N'y@y.com', N'MTIz', N'Needy')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [City], [Address], [PhoneNo], [Email], [PasswordHash], [Type]) VALUES (29, N'samreen', N'khawar', N'Karachi', N'lahore', N'888', N'a@ss.com', N'MTIz', N'Needy')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [City], [Address], [PhoneNo], [Email], [PasswordHash], [Type]) VALUES (30, N'samreen', N'khawar', N'Lahore', N'lahore', N'77777', N'a@ee.com', N'MTIz', N'Donator')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [City], [Address], [PhoneNo], [Email], [PasswordHash], [Type]) VALUES (32, N'samreen', N'khawar', N'Karachi', N'lahore', N'888', N'a@jj.com', N'MTIy', N'Donator')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [City], [Address], [PhoneNo], [Email], [PasswordHash], [Type]) VALUES (33, N'samreen', N'khawar', N'Karachi', N'lahore', N'888', N'a@jj.com', N'MTIy', N'Donator')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [City], [Address], [PhoneNo], [Email], [PasswordHash], [Type]) VALUES (34, N'samreen', N'khawar', N'Lahore', N'lahore', N'777', N'a@pc.com', N'MTIz', N'Donator')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [City], [Address], [PhoneNo], [Email], [PasswordHash], [Type]) VALUES (35, N'samreen', N'khawar', N'Karachi', N'lahore', N'77777', N'a@y.com', N'MTIz', N'Needy')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [City], [Address], [PhoneNo], [Email], [PasswordHash], [Type]) VALUES (36, N'samreen', N'khawar', N'Karachi', N'lahore', N'77777', N'a@yy.com', N'MTIz', N'Needy')
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[DonatedFood]  WITH CHECK ADD  CONSTRAINT [FK_DonatedFood_Users] FOREIGN KEY([DonatedBy])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[DonatedFood] CHECK CONSTRAINT [FK_DonatedFood_Users]
GO
ALTER TABLE [dbo].[FoodRequests]  WITH CHECK ADD  CONSTRAINT [FK_FoodRequests_Users] FOREIGN KEY([FkUser])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[FoodRequests] CHECK CONSTRAINT [FK_FoodRequests_Users]
GO
USE [master]
GO
ALTER DATABASE [FoodCollectionDB] SET  READ_WRITE 
GO
