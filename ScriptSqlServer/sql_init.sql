USE [master]
GO
/****** Object:  Database [CredPago]    Script Date: 01/09/2019 10:59:19 ******/
CREATE DATABASE [CredPago]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CredPago', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\CredPago.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CredPago_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\CredPago_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CredPago] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CredPago].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CredPago] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CredPago] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CredPago] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CredPago] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CredPago] SET ARITHABORT OFF 
GO
ALTER DATABASE [CredPago] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CredPago] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CredPago] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CredPago] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CredPago] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CredPago] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CredPago] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CredPago] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CredPago] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CredPago] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CredPago] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CredPago] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CredPago] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CredPago] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CredPago] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CredPago] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CredPago] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CredPago] SET RECOVERY FULL 
GO
ALTER DATABASE [CredPago] SET  MULTI_USER 
GO
ALTER DATABASE [CredPago] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CredPago] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CredPago] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CredPago] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CredPago] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CredPago', N'ON'
GO
USE [CredPago]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 01/09/2019 10:59:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cart](
	[cart_id] [varchar](100) NULL,
	[client_id] [varchar](100) NULL,
	[product_id] [varchar](100) NULL,
	[date] [varchar](10) NULL,
	[time] [varchar](8) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CreditCard]    Script Date: 01/09/2019 10:59:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CreditCard](
	[card_number] [varchar](100) NULL,
	[card_holder_name] [varchar](max) NULL,
	[cvv] [int] NULL,
	[exp_date] [varchar](10) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[History]    Script Date: 01/09/2019 10:59:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[History](
	[card_number] [varchar](100) NULL,
	[client_id] [varchar](100) NULL,
	[value] [int] NULL,
	[order_id] [varchar](100) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 01/09/2019 10:59:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Orders](
	[client_id] [varchar](100) NULL,
	[cart_id] [varchar](100) NULL,
	[client_name] [varchar](max) NULL,
	[total_to_pay] [int] NULL,
	[credit_card] [varchar](100) NULL,
	[order_id] [varchar](100) NULL,
	[date] [varchar](10) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Product]    Script Date: 01/09/2019 10:59:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[product_id] [varchar](100) NULL,
	[artist] [varchar](100) NULL,
	[year] [int] NULL,
	[album] [varchar](100) NULL,
	[price] [int] NULL,
	[store] [varchar](100) NULL,
	[thumb] [varchar](max) NULL,
	[date] [varchar](10) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [CredPago] SET  READ_WRITE 
GO
