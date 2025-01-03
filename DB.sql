USE [master]
GO
/****** Object:  Database [Product_Demo]    Script Date: 21-12-2024 11:45:36 PM ******/
CREATE DATABASE [Product_Demo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Product_Demo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Product_Demo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Product_Demo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Product_Demo_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Product_Demo] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Product_Demo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Product_Demo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Product_Demo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Product_Demo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Product_Demo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Product_Demo] SET ARITHABORT OFF 
GO
ALTER DATABASE [Product_Demo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Product_Demo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Product_Demo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Product_Demo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Product_Demo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Product_Demo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Product_Demo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Product_Demo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Product_Demo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Product_Demo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Product_Demo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Product_Demo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Product_Demo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Product_Demo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Product_Demo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Product_Demo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Product_Demo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Product_Demo] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Product_Demo] SET  MULTI_USER 
GO
ALTER DATABASE [Product_Demo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Product_Demo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Product_Demo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Product_Demo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Product_Demo] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Product_Demo] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Product_Demo] SET QUERY_STORE = ON
GO
ALTER DATABASE [Product_Demo] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Product_Demo]
GO
/****** Object:  Table [dbo].[Product_Table]    Script Date: 21-12-2024 11:45:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Table](
	[Product_ID] [int] IDENTITY(1,1) NOT NULL,
	[Product_Name] [varchar](200) NOT NULL,
	[Product_SKU] [varchar](20) NOT NULL,
	[Product_Status] [bit] NOT NULL,
	[Product_Price] [decimal](10, 2) NOT NULL,
	[Product_Img_Path] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Product_Table] PRIMARY KEY CLUSTERED 
(
	[Product_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_Table]    Script Date: 21-12-2024 11:45:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Table](
	[User_ID] [int] IDENTITY(1,1) NOT NULL,
	[User_Name] [varchar](200) NOT NULL,
	[User_Email] [varchar](255) NOT NULL,
	[User_Phone] [varchar](10) NOT NULL,
	[User_Password] [varchar](10) NOT NULL,
 CONSTRAINT [PK_User_Table] PRIMARY KEY CLUSTERED 
(
	[User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Product_Table] ON 

INSERT [dbo].[Product_Table] ([Product_ID], [Product_Name], [Product_SKU], [Product_Status], [Product_Price], [Product_Img_Path]) VALUES (1, N'Apple', N'AP-A-1', 1, CAST(250.00 AS Decimal(10, 2)), N'/uploads/product-img/20241221233533-Apple.jpg')
SET IDENTITY_INSERT [dbo].[Product_Table] OFF
GO
SET IDENTITY_INSERT [dbo].[User_Table] ON 

INSERT [dbo].[User_Table] ([User_ID], [User_Name], [User_Email], [User_Phone], [User_Password]) VALUES (1, N'Bhargav', N'bhargavkachhela1@gmail.com', N'9664633122', N'Bhargav12@')
INSERT [dbo].[User_Table] ([User_ID], [User_Name], [User_Email], [User_Phone], [User_Password]) VALUES (2, N'Demo12', N'demo@gmail.com', N'9632587410', N'Bhargav12@')
SET IDENTITY_INSERT [dbo].[User_Table] OFF
GO
/****** Object:  StoredProcedure [dbo].[DeleteProduct]    Script Date: 21-12-2024 11:45:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Delete Procedure
CREATE PROCEDURE [dbo].[DeleteProduct]
    @Product_ID INT
AS
BEGIN
    DELETE FROM dbo.Product_Table
    WHERE Product_ID = @Product_ID
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 21-12-2024 11:45:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Delete Procedure for User
CREATE PROCEDURE [dbo].[DeleteUser]
    @User_ID INT
AS
BEGIN
    DELETE FROM dbo.User_Table
    WHERE User_ID = @User_ID
END
GO
/****** Object:  StoredProcedure [dbo].[InsertProduct]    Script Date: 21-12-2024 11:45:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Insert Procedure
CREATE PROCEDURE [dbo].[InsertProduct]
    @Product_Name VARCHAR(200),
    @Product_SKU VARCHAR(20),
    @Product_Status BIT,
    @Product_Price DECIMAL(10, 2),
    @Product_Image_Path VARCHAR(MAX)
AS
BEGIN
    INSERT INTO dbo.Product_Table (Product_Name, Product_SKU, Product_Status, Product_Price, Product_Img_Path)
    VALUES (@Product_Name, @Product_SKU, @Product_Status, @Product_Price, @Product_Image_Path)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertUser]    Script Date: 21-12-2024 11:45:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Insert Procedure for User
CREATE PROCEDURE [dbo].[InsertUser]
    @User_Name VARCHAR(200),
    @User_Email VARCHAR(255),
    @User_Phone VARCHAR(10),
    @User_Password VARCHAR(10)
AS
BEGIN
    INSERT INTO dbo.User_Table (User_Name, User_Email, User_Phone, User_Password)
    VALUES (@User_Name, @User_Email, @User_Phone, @User_Password)
END
GO
/****** Object:  StoredProcedure [dbo].[SelectAllProducts]    Script Date: 21-12-2024 11:45:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Select All Procedure
CREATE PROCEDURE [dbo].[SelectAllProducts]
AS
BEGIN
    SELECT Product_ID, Product_Name, Product_SKU, Product_Status, Product_Price, Product_Img_Path
    FROM dbo.Product_Table
END
GO
/****** Object:  StoredProcedure [dbo].[SelectAllUsers]    Script Date: 21-12-2024 11:45:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Select All Procedure for Users
CREATE PROCEDURE [dbo].[SelectAllUsers]
AS
BEGIN
    SELECT User_ID, User_Name, User_Email, User_Phone
    FROM dbo.User_Table
END
GO
/****** Object:  StoredProcedure [dbo].[SelectUserByPK]    Script Date: 21-12-2024 11:45:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create   PRoc [dbo].[SelectUserByPK]
@User_ID int
AS
Select 
User_Table.User_ID,
User_Table.User_Name,
User_Table.User_Email,
User_Table.User_Password
From User_Table
Where User_Table.User_ID = @User_ID
GO
/****** Object:  StoredProcedure [dbo].[UpdateProduct]    Script Date: 21-12-2024 11:45:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Update Procedure
CREATE PROCEDURE [dbo].[UpdateProduct]
    @Product_ID INT,
    @Product_Name VARCHAR(200),
    @Product_SKU VARCHAR(20),
    @Product_Status BIT,
    @Product_Price DECIMAL(10, 2),
    @Product_Image_Path VARCHAR(MAX)
AS
BEGIN
    UPDATE dbo.Product_Table
    SET Product_Name = @Product_Name,
        Product_SKU = @Product_SKU,
        Product_Status = @Product_Status,
        Product_Price = @Product_Price,
        Product_Img_Path = @Product_Image_Path
    WHERE Product_ID = @Product_ID
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 21-12-2024 11:45:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Update Procedure for User
CREATE PROCEDURE [dbo].[UpdateUser]
    @User_ID INT,
    @User_Name VARCHAR(200),
    @User_Email VARCHAR(255),
    @User_Phone VARCHAR(10),
    @User_Password VARCHAR(10)
AS
BEGIN
    UPDATE dbo.User_Table
    SET User_Name = @User_Name,
        User_Email = @User_Email,
        User_Phone = @User_Phone,
        User_Password = @User_Password
    WHERE User_ID = @User_ID
END
GO
/****** Object:  StoredProcedure [dbo].[UserAuth]    Script Date: 21-12-2024 11:45:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[UserAuth]
@User_Email Varchar(200),
@User_Pass Varchar(20)
AS
Select 
User_Table.User_ID,
User_Table.User_Name,
User_Table.User_Email,
User_Table.User_Password
From User_Table
Where User_Email = @User_Email AND User_Password = @User_Pass
GO
USE [master]
GO
ALTER DATABASE [Product_Demo] SET  READ_WRITE 
GO
