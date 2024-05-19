USE [master]
GO
/****** Object:  Database [golf_cource]    Script Date: 5/18/2024 9:38:23 PM ******/
CREATE DATABASE [golf_cource]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'golf_cource', FILENAME = N'C:\Users\rkobayashi\Desktop\MSSQL16.SQLEXPRESS05\MSSQL\DATA\golf_cource.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'golf_cource_log', FILENAME = N'C:\Users\rkobayashi\Desktop\MSSQL16.SQLEXPRESS05\MSSQL\DATA\golf_cource_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [golf_cource] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [golf_cource].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [golf_cource] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [golf_cource] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [golf_cource] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [golf_cource] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [golf_cource] SET ARITHABORT OFF 
GO
ALTER DATABASE [golf_cource] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [golf_cource] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [golf_cource] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [golf_cource] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [golf_cource] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [golf_cource] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [golf_cource] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [golf_cource] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [golf_cource] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [golf_cource] SET  DISABLE_BROKER 
GO
ALTER DATABASE [golf_cource] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [golf_cource] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [golf_cource] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [golf_cource] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [golf_cource] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [golf_cource] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [golf_cource] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [golf_cource] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [golf_cource] SET  MULTI_USER 
GO
ALTER DATABASE [golf_cource] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [golf_cource] SET DB_CHAINING OFF 
GO
ALTER DATABASE [golf_cource] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [golf_cource] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [golf_cource] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [golf_cource] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [golf_cource] SET QUERY_STORE = ON
GO
ALTER DATABASE [golf_cource] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [golf_cource]
GO
/****** Object:  User [comp305]    Script Date: 5/18/2024 9:38:23 PM ******/
CREATE USER [comp305] FOR LOGIN [comp305] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 5/18/2024 9:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NULL,
	[CourseURL] [nvarchar](max) NULL,
	[CourseName] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[TelephoneNumber] [bigint] NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 5/18/2024 9:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [bigint] NOT NULL,
	[FirstName] [nvarchar](250) NULL,
	[LastName] [nvarchar](250) NULL,
	[EmailAddress] [nvarchar](250) NULL,
	[Password] [nvarchar](250) NULL,
	[IsActive] [bit] NULL,
	[TelephoneNumber] [bigint] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([CourseId], [UserId], [CourseURL], [CourseName], [Address], [TelephoneNumber], [Description]) VALUES (2, 1, N'http://example.com', N'Sample Golf Course', N'123 Golf Lane', 1234567890, N'A beautiful 18-hole course with challenging fairways and scenic views.')
INSERT [dbo].[Course] ([CourseId], [UserId], [CourseURL], [CourseName], [Address], [TelephoneNumber], [Description]) VALUES (3, 1, N'http://example.com', N'Sample Golf Course', N'123 Golf Lane', 1234567890, N'A beautiful 18-hole course with challenging fairways and scenic views.')
INSERT [dbo].[Course] ([CourseId], [UserId], [CourseURL], [CourseName], [Address], [TelephoneNumber], [Description]) VALUES (4, 1, N'http://example.com', N'Sample Golf Course', N'123 Golf Lane', 1234567890, N'A beautiful 18-hole course with challenging fairways and scenic views.')
INSERT [dbo].[Course] ([CourseId], [UserId], [CourseURL], [CourseName], [Address], [TelephoneNumber], [Description]) VALUES (5, 1, N'http://example.com', N'Sample Golf Course', N'123 Golf Lane', 1234567890, N'A beautiful 18-hole course with challenging fairways and scenic views.')
INSERT [dbo].[Course] ([CourseId], [UserId], [CourseURL], [CourseName], [Address], [TelephoneNumber], [Description]) VALUES (6, 1, N'http://example.com', N'Sample Golf Course', N'123 Golf Lane', 1234567890, N'A beautiful 18-hole course with challenging fairways and scenic views.')
INSERT [dbo].[Course] ([CourseId], [UserId], [CourseURL], [CourseName], [Address], [TelephoneNumber], [Description]) VALUES (14, 1, N'adfg', N'asgfg', N'123 Golf Lane', 35435254, N'afgadfg')
INSERT [dbo].[Course] ([CourseId], [UserId], [CourseURL], [CourseName], [Address], [TelephoneNumber], [Description]) VALUES (18, 2, N'hxh', N'yh', N'dhtth', 21414, N'tserthse')
SET IDENTITY_INSERT [dbo].[Course] OFF
GO
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [EmailAddress], [Password], [IsActive], [TelephoneNumber]) VALUES (1, N'Ryo', N'Kobayashi', N'ryokoba0501@gmail.com', N'123', 1, 7085395424)
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [EmailAddress], [Password], [IsActive], [TelephoneNumber]) VALUES (2, N'ok', N'no', N'okno@gmail.com', N'243', 1, 3241241234)
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_User]
GO
USE [master]
GO
ALTER DATABASE [golf_cource] SET  READ_WRITE 
GO
