USE [master]
GO
/****** Object:  Database [HM]    Script Date: 08-01-2021 23:04:34 ******/
CREATE DATABASE [HM]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HM', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\HM.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HM_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\HM_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [HM] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HM] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HM] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HM] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HM] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HM] SET ARITHABORT OFF 
GO
ALTER DATABASE [HM] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HM] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HM] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HM] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HM] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HM] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HM] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HM] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HM] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HM] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HM] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HM] SET RECOVERY FULL 
GO
ALTER DATABASE [HM] SET  MULTI_USER 
GO
ALTER DATABASE [HM] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HM] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HM] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HM] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HM] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'HM', N'ON'
GO
ALTER DATABASE [HM] SET QUERY_STORE = OFF
GO
USE [HM]
GO
/****** Object:  Table [dbo].[tbl_booking]    Script Date: 08-01-2021 23:04:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_booking](
	[bookingId] [bigint] IDENTITY(1,1) NOT NULL,
	[hotelid] [bigint] NULL,
	[roomid] [bigint] NULL,
	[statusOfBooking] [nvarchar](50) NULL,
	[bookingDate] [nvarchar](max) NULL,
	[isActive] [int] NULL,
 CONSTRAINT [PK_tbl_booking] PRIMARY KEY CLUSTERED 
(
	[bookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_hotel]    Script Date: 08-01-2021 23:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_hotel](
	[hid] [bigint] IDENTITY(1,1) NOT NULL,
	[hotelName] [nvarchar](max) NULL,
	[address] [nvarchar](max) NULL,
	[city] [nvarchar](max) NULL,
	[pincode] [nvarchar](max) NULL,
	[contactNumber] [bigint] NULL,
	[contactPerson] [nvarchar](50) NULL,
	[website] [nvarchar](max) NULL,
	[facebook] [nvarchar](max) NULL,
	[Twitter] [nvarchar](max) NULL,
	[isActive] [nvarchar](max) NULL,
	[createDate] [datetime] NULL,
	[createdBy] [nvarchar](max) NULL,
	[updateDate] [datetime] NULL,
	[updatedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_hotel] PRIMARY KEY CLUSTERED 
(
	[hid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_room]    Script Date: 08-01-2021 23:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_room](
	[rid] [bigint] IDENTITY(1,1) NOT NULL,
	[hotelid] [bigint] NULL,
	[roomName] [nvarchar](50) NULL,
	[category] [nvarchar](50) NULL,
	[price] [nvarchar](max) NULL,
	[isActive] [bigint] NULL,
	[createdDate] [datetime] NULL,
	[createdBy] [nvarchar](max) NULL,
	[updateDate] [datetime] NULL,
	[updatedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_room] PRIMARY KEY CLUSTERED 
(
	[rid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [HM] SET  READ_WRITE 
GO
