USE [DGVDB]
GO
/****** Object:  Table [dbo].[Position]    Script Date: 12/4/2017 7:05:06 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Position]') AND type in (N'U'))
DROP TABLE [dbo].[Position]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 12/4/2017 7:05:06 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee]') AND type in (N'U'))
DROP TABLE [dbo].[Employee]
GO
/****** Object:  StoredProcedure [dbo].[EmployeeDeleteByID]    Script Date: 12/4/2017 7:05:06 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmployeeDeleteByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[EmployeeDeleteByID]
GO
/****** Object:  StoredProcedure [dbo].[EmployeeAddOrEdit]    Script Date: 12/4/2017 7:05:06 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmployeeAddOrEdit]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[EmployeeAddOrEdit]
GO
USE [master]
GO
/****** Object:  Database [DGVDB]    Script Date: 12/4/2017 7:05:06 PM ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'DGVDB')
DROP DATABASE [DGVDB]
GO
/****** Object:  Database [DGVDB]    Script Date: 12/4/2017 7:05:06 PM ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'DGVDB')
BEGIN
CREATE DATABASE [DGVDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DGVDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLE2012\MSSQL\DATA\DGVDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DGVDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLE2012\MSSQL\DATA\DGVDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
END

GO
ALTER DATABASE [DGVDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DGVDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DGVDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DGVDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DGVDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DGVDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DGVDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [DGVDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DGVDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [DGVDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DGVDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DGVDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DGVDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DGVDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DGVDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DGVDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DGVDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DGVDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DGVDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DGVDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DGVDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DGVDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DGVDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DGVDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DGVDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DGVDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DGVDB] SET  MULTI_USER 
GO
ALTER DATABASE [DGVDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DGVDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DGVDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DGVDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [DGVDB]
GO
/****** Object:  StoredProcedure [dbo].[EmployeeAddOrEdit]    Script Date: 12/4/2017 7:05:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmployeeAddOrEdit]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[EmployeeAddOrEdit]
@EmployeeID int,
@Name varchar(100),
@PositionID int,
@Office varchar(50),
@Age int
AS
 IF @EmployeeID = 0
 INSERT INTO Employee(Name,PositionID,Office,Age)
 VALUES (@Name,@PositionID,@Office,@Age)
 ELSE
 UPDATE Employee
 SET 
 Name = @Name,
 PositionID = @PositionID,
 Office = @Office,
 Age = @Age
 WHERE EmployeeID = @EmployeeID' 
END
GO
/****** Object:  StoredProcedure [dbo].[EmployeeDeleteByID]    Script Date: 12/4/2017 7:05:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmployeeDeleteByID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[EmployeeDeleteByID]
@EmployeeID int
AS
	DELETE FROM Employee
	WHERE EmployeeID = @EmployeeID' 
END
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 12/4/2017 7:05:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[PositionID] [int] NULL,
	[Office] [varchar](50) NULL,
	[Age] [int] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Position]    Script Date: 12/4/2017 7:05:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Position]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Position](
	[PositionID] [int] NOT NULL,
	[Position] [varchar](50) NULL,
 CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED 
(
	[PositionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [DGVDB] SET  READ_WRITE 
GO
