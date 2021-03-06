USE [master]
GO
/****** 对象:  Database [SohoControlPanel]    脚本日期: 05/19/2014 23:14:32 ******/
CREATE DATABASE [SohoControlPanel] ON  PRIMARY 
( NAME = N'SohoControlPanel', FILENAME = N'D:\NEW\MSSQL10_50.CENTERDB\MSSQL\DATA\SohoControlPanel.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SohoControlPanel_log', FILENAME = N'D:\NEW\MSSQL10_50.CENTERDB\MSSQL\DATA\SohoControlPanel_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 COLLATE Chinese_PRC_CI_AS
GO
EXEC dbo.sp_dbcmptlevel @dbname=N'SohoControlPanel', @new_cmptlevel=90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SohoControlPanel].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SohoControlPanel] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SohoControlPanel] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SohoControlPanel] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SohoControlPanel] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SohoControlPanel] SET ARITHABORT OFF 
GO
ALTER DATABASE [SohoControlPanel] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SohoControlPanel] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [SohoControlPanel] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SohoControlPanel] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SohoControlPanel] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SohoControlPanel] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SohoControlPanel] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SohoControlPanel] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SohoControlPanel] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SohoControlPanel] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SohoControlPanel] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SohoControlPanel] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SohoControlPanel] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SohoControlPanel] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SohoControlPanel] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SohoControlPanel] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SohoControlPanel] SET  READ_WRITE 
GO
ALTER DATABASE [SohoControlPanel] SET RECOVERY FULL 
GO
ALTER DATABASE [SohoControlPanel] SET  MULTI_USER 
GO
ALTER DATABASE [SohoControlPanel] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SohoControlPanel] SET DB_CHAINING OFF 