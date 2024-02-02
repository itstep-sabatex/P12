USE [master]
GO
/****** Object:  Database [test]    Script Date: 02.02.2024 21:08:17 ******/
CREATE DATABASE [test]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'test', FILENAME = N'/var/opt/mssql/data/test.mdf' , SIZE = 16384KB , MAXSIZE = UNLIMITED, FILEGROWTH = 8192KB )
 LOG ON 
( NAME = N'test_log', FILENAME = N'/var/opt/mssql/data/test_log.ldf' , SIZE = 40960KB , MAXSIZE = 2048GB , FILEGROWTH = 8192KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [test] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [test].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [test] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [test] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [test] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [test] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [test] SET ARITHABORT OFF 
GO
ALTER DATABASE [test] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [test] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [test] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [test] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [test] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [test] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [test] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [test] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [test] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [test] SET  DISABLE_BROKER 
GO
ALTER DATABASE [test] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [test] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [test] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [test] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [test] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [test] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [test] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [test] SET RECOVERY FULL 
GO
ALTER DATABASE [test] SET  MULTI_USER 
GO
ALTER DATABASE [test] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [test] SET DB_CHAINING OFF 
GO
ALTER DATABASE [test] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [test] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [test] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [test] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'test', N'ON'
GO
ALTER DATABASE [test] SET QUERY_STORE = ON
GO
ALTER DATABASE [test] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [test]
GO
USE [test]
GO
/****** Object:  Sequence [dbo].[OrdersSequences]    Script Date: 02.02.2024 21:08:17 ******/
CREATE SEQUENCE [dbo].[OrdersSequences] 
 AS [int]
 START WITH 1
 INCREMENT BY 1
 MINVALUE -2147483648
 MAXVALUE 2147483647
 CACHE  10 
GO
/****** Object:  UserDefinedFunction [dbo].[AddInt]    Script Date: 02.02.2024 21:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[AddInt]
(
	@param1 int,
	@param2 int
)
RETURNS INT
AS
BEGIN
	RETURN @param1 + @param2
END
GO
/****** Object:  UserDefinedFunction [dbo].[Function]    Script Date: 02.02.2024 21:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[Function]
(
	@param1 int,
	@param2 char(5)
)
RETURNS @returntable TABLE
(
	c1 int,
	c2 char(5)
)
AS
BEGIN
	INSERT @returntable
	SELECT @param1, @param2
	RETURN
END
GO
/****** Object:  UserDefinedFunction [dbo].[InitCap]    Script Date: 02.02.2024 21:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[InitCap] ( @InputString varchar(4000) )
RETURNS VARCHAR(4000)
AS
BEGIN
 
DECLARE @Index          INT
DECLARE @Char           CHAR(1)
DECLARE @PrevChar       CHAR(1)
DECLARE @OutputString   VARCHAR(255)
 
SET @OutputString = LOWER(@InputString)
SET @Index = 1
 
WHILE @Index <= LEN(@InputString)
BEGIN
    SET @Char     = SUBSTRING(@InputString, @Index, 1)
    SET @PrevChar = CASE WHEN @Index = 1 THEN ' '
                         ELSE SUBSTRING(@InputString, @Index - 1, 1)
                    END
 
    IF @PrevChar IN (' ', ';', ':', '!', '?', ',', '.', '_', '-', '/', '&', '''', '(')
    BEGIN
        IF @PrevChar != '''' OR UPPER(@Char) != 'S'
            SET @OutputString = STUFF(@OutputString, @Index, 1, UPPER(@Char))
    END
 
    SET @Index = @Index + 1
END
 
RETURN @OutputString
 
END
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 02.02.2024 21:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceDetail]    Script Date: 02.02.2024 21:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceDetail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceId] [int] NOT NULL,
	[NomenclatureId] [int] NOT NULL,
	[UnitOfMeasurementsId] [int] NOT NULL,
	[Count] [numeric](18, 2) NOT NULL,
	[Price] [numeric](18, 2) NOT NULL,
	[Sum] [numeric](18, 2) NOT NULL,
	[Vat] [numeric](18, 2) NOT NULL,
	[Tax] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_InvoiceDetail] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoices]    Script Date: 02.02.2024 21:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoices](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[OrderNumber] [varchar](10) NULL,
	[BayerId] [int] NULL,
	[SellerId] [int] NULL,
	[Date] [date] NULL,
 CONSTRAINT [PK_Invoices] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogTable]    Script Date: 02.02.2024 21:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TableName] [nchar](100) NULL,
	[Log] [nchar](100) NULL,
	[Action] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nomenclatures]    Script Date: 02.02.2024 21:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nomenclatures](
	[Id] [int] IDENTITY(10,1) NOT NULL,
	[Description] [varchar](100) NOT NULL,
	[UnitOfMeasurementsId] [int] NOT NULL,
	[Price] [numeric](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[People]    Script Date: 02.02.2024 21:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UnitOfMerasurements]    Script Date: 02.02.2024 21:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnitOfMerasurements](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[InvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetail_Invoices] FOREIGN KEY([InvoiceId])
REFERENCES [dbo].[Invoices] ([id])
GO
ALTER TABLE [dbo].[InvoiceDetail] CHECK CONSTRAINT [FK_InvoiceDetail_Invoices]
GO
ALTER TABLE [dbo].[InvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetail_ToNomenclature] FOREIGN KEY([NomenclatureId])
REFERENCES [dbo].[Nomenclatures] ([Id])
GO
ALTER TABLE [dbo].[InvoiceDetail] CHECK CONSTRAINT [FK_InvoiceDetail_ToNomenclature]
GO
ALTER TABLE [dbo].[InvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetail_ToUnitOfMeasurements] FOREIGN KEY([UnitOfMeasurementsId])
REFERENCES [dbo].[UnitOfMerasurements] ([Id])
GO
ALTER TABLE [dbo].[InvoiceDetail] CHECK CONSTRAINT [FK_InvoiceDetail_ToUnitOfMeasurements]
GO
ALTER TABLE [dbo].[Invoices]  WITH CHECK ADD  CONSTRAINT [FK_Invoices_Clients] FOREIGN KEY([BayerId])
REFERENCES [dbo].[Clients] ([Id])
GO
ALTER TABLE [dbo].[Invoices] CHECK CONSTRAINT [FK_Invoices_Clients]
GO
ALTER TABLE [dbo].[Invoices]  WITH CHECK ADD  CONSTRAINT [FK_Invoices_Clients1] FOREIGN KEY([SellerId])
REFERENCES [dbo].[Clients] ([Id])
GO
ALTER TABLE [dbo].[Invoices] CHECK CONSTRAINT [FK_Invoices_Clients1]
GO
ALTER TABLE [dbo].[Nomenclatures]  WITH CHECK ADD  CONSTRAINT [FK_Nomenclatures_UnitOfMerasurements] FOREIGN KEY([UnitOfMeasurementsId])
REFERENCES [dbo].[UnitOfMerasurements] ([Id])
GO
ALTER TABLE [dbo].[Nomenclatures] CHECK CONSTRAINT [FK_Nomenclatures_UnitOfMerasurements]
GO
/****** Object:  StoredProcedure [dbo].[CountTables]    Script Date: 02.02.2024 21:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CountTables]
	@param1 int = 0,
	@param2 int,
	@param3 int OUTPUT
AS
	SET @param3 = @param1 + @param2;
RETURN 0
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Первинний ключ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Nomenclatures', @level2type=N'COLUMN',@level2name=N'Id'
GO
USE [master]
GO
ALTER DATABASE [test] SET  READ_WRITE 
GO
