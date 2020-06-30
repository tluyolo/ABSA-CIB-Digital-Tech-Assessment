USE [master]
GO

/****** Object:  Database [ABSA]    Script Date: 6/30/2020 9:30:47 AM ******/
CREATE DATABASE [ABSA] ON  PRIMARY 
( NAME = N'ABSA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\ABSA.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ABSA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\ABSA_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [ABSA] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ABSA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [ABSA] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [ABSA] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [ABSA] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [ABSA] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [ABSA] SET ARITHABORT OFF 
GO

ALTER DATABASE [ABSA] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [ABSA] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [ABSA] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [ABSA] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [ABSA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [ABSA] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [ABSA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [ABSA] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [ABSA] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [ABSA] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [ABSA] SET  DISABLE_BROKER 
GO

ALTER DATABASE [ABSA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [ABSA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [ABSA] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [ABSA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [ABSA] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [ABSA] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [ABSA] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [ABSA] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [ABSA] SET  MULTI_USER 
GO

ALTER DATABASE [ABSA] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [ABSA] SET DB_CHAINING OFF 
GO

ALTER DATABASE [ABSA] SET  READ_WRITE 
GO

