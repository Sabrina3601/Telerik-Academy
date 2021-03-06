USE [master]
GO
/****** Object:  Database [Personal_Info]    Script Date: 8/24/2014 6:54:55 PM ******/
CREATE DATABASE [Personal_Info]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Personal_Info', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Personal_Info.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Personal_Info_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Personal_Info_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Personal_Info] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Personal_Info].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Personal_Info] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Personal_Info] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Personal_Info] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Personal_Info] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Personal_Info] SET ARITHABORT OFF 
GO
ALTER DATABASE [Personal_Info] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Personal_Info] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Personal_Info] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Personal_Info] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Personal_Info] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Personal_Info] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Personal_Info] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Personal_Info] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Personal_Info] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Personal_Info] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Personal_Info] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Personal_Info] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Personal_Info] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Personal_Info] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Personal_Info] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Personal_Info] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Personal_Info] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Personal_Info] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Personal_Info] SET RECOVERY FULL 
GO
ALTER DATABASE [Personal_Info] SET  MULTI_USER 
GO
ALTER DATABASE [Personal_Info] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Personal_Info] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Personal_Info] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Personal_Info] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Personal_Info', N'ON'
GO
USE [Personal_Info]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 8/24/2014 6:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[address_text] [nvarchar](50) NULL,
	[town_id] [int] NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continent]    Script Date: 8/24/2014 6:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continent](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Continent] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Country]    Script Date: 8/24/2014 6:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[continetn_id] [int] NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Person]    Script Date: 8/24/2014 6:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [nvarchar](50) NULL,
	[last_name] [nvarchar](50) NULL,
	[address_id] [int] NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Town]    Script Date: 8/24/2014 6:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Town](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[country_id] [int] NULL,
 CONSTRAINT [PK_Town] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Address] ON 

INSERT [dbo].[Address] ([id], [address_text], [town_id]) VALUES (1, N'Mladost', 1)
INSERT [dbo].[Address] ([id], [address_text], [town_id]) VALUES (2, N'Kongo State', 2)
SET IDENTITY_INSERT [dbo].[Address] OFF
SET IDENTITY_INSERT [dbo].[Continent] ON 

INSERT [dbo].[Continent] ([id], [name]) VALUES (1, N'Europe')
INSERT [dbo].[Continent] ([id], [name]) VALUES (2, N'Africa')
SET IDENTITY_INSERT [dbo].[Continent] OFF
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([id], [name], [continetn_id]) VALUES (1, N'Bulgaria', 1)
INSERT [dbo].[Country] ([id], [name], [continetn_id]) VALUES (2, N'Kongo', 2)
SET IDENTITY_INSERT [dbo].[Country] OFF
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([id], [first_name], [last_name], [address_id]) VALUES (1, N'Ivan', N'Ivanov', 1)
INSERT [dbo].[Person] ([id], [first_name], [last_name], [address_id]) VALUES (2, N'Kongo', N'Kongov', 2)
SET IDENTITY_INSERT [dbo].[Person] OFF
SET IDENTITY_INSERT [dbo].[Town] ON 

INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (1, N'Sofia', 1)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (2, N'Kongo Capital', 2)
SET IDENTITY_INSERT [dbo].[Town] OFF
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Town] FOREIGN KEY([town_id])
REFERENCES [dbo].[Town] ([id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Town]
GO
ALTER TABLE [dbo].[Country]  WITH CHECK ADD  CONSTRAINT [FK_Country_Continent] FOREIGN KEY([continetn_id])
REFERENCES [dbo].[Continent] ([id])
GO
ALTER TABLE [dbo].[Country] CHECK CONSTRAINT [FK_Country_Continent]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Address] FOREIGN KEY([address_id])
REFERENCES [dbo].[Address] ([id])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Address]
GO
ALTER TABLE [dbo].[Town]  WITH CHECK ADD  CONSTRAINT [FK_Town_Country] FOREIGN KEY([country_id])
REFERENCES [dbo].[Country] ([id])
GO
ALTER TABLE [dbo].[Town] CHECK CONSTRAINT [FK_Town_Country]
GO
USE [master]
GO
ALTER DATABASE [Personal_Info] SET  READ_WRITE 
GO
