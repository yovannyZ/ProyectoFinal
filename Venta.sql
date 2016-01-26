USE [master]
GO
/****** Object:  Database [Ventas]    Script Date: 25/01/2016 18:30:34 ******/
CREATE DATABASE [Ventas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Ventas', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Ventas.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Ventas_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Ventas_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Ventas] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Ventas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Ventas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Ventas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Ventas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Ventas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Ventas] SET ARITHABORT OFF 
GO
ALTER DATABASE [Ventas] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Ventas] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Ventas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Ventas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Ventas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Ventas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Ventas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Ventas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Ventas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Ventas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Ventas] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Ventas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Ventas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Ventas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Ventas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Ventas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Ventas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Ventas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Ventas] SET RECOVERY FULL 
GO
ALTER DATABASE [Ventas] SET  MULTI_USER 
GO
ALTER DATABASE [Ventas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Ventas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Ventas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Ventas] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Ventas', N'ON'
GO
USE [Ventas]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 25/01/2016 18:30:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categoria](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [char](4) NOT NULL,
	[Descripcion] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 25/01/2016 18:30:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[RUC] [char](12) NOT NULL,
	[DNI] [char](8) NOT NULL,
	[Direccion] [varchar](100) NOT NULL,
	[Telefono] [varchar](12) NOT NULL,
	[Observacion] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[DNI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[RUC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DetalleVenta]    Script Date: 25/01/2016 18:30:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleVenta](
	[IdDetalleventa] [int] IDENTITY(1,1) NOT NULL,
	[IdVenta] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Precio] [decimal](8, 2) NOT NULL,
 CONSTRAINT [PK_DetalleVenta] PRIMARY KEY CLUSTERED 
(
	[IdDetalleventa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 25/01/2016 18:30:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Empleado](
	[IdEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[DNI] [char](8) NOT NULL,
	[Direccion] [varchar](100) NOT NULL,
	[Telefono] [varchar](12) NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[Clave] [varchar](50) NOT NULL,
	[Observacion] [varchar](200) NULL,
	[IdTipoUsuario] [int] NOT NULL,
 CONSTRAINT [PK__Empleado__CE6D8B9E197E0C37] PRIMARY KEY CLUSTERED 
(
	[IdEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__Empleado__C035B8DDC80C1214] UNIQUE NONCLUSTERED 
(
	[DNI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 25/01/2016 18:30:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Producto](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Descripcion] [varchar](200) NULL,
	[Marca] [varchar](50) NOT NULL,
	[Stock] [int] NOT NULL,
	[StockMinimo] [int] NOT NULL,
	[PrecioVenta] [decimal](8, 2) NOT NULL,
	[PrecioCosto] [decimal](8, 2) NOT NULL,
	[Utilidad] [decimal](8, 2) NOT NULL,
	[Foto] [image] NULL,
	[IdCategoria] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoComprobante]    Script Date: 25/01/2016 18:30:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoComprobante](
	[IdTipoComprobante] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTipoComprobante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoUsuario]    Script Date: 25/01/2016 18:30:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoUsuario](
	[IdTipoUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTipoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 25/01/2016 18:30:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Venta](
	[IdVenta] [int] IDENTITY(1,1) NOT NULL,
	[Serie] [varchar](5) NOT NULL,
	[Numero] [varchar](20) NOT NULL,
	[Fecha] [date] NOT NULL,
	[TotalVenta] [decimal](8, 2) NOT NULL,
	[Descuento] [decimal](8, 2) NULL,
	[Subtotal] [decimal](8, 2) NOT NULL,
	[Igv] [decimal](8, 2) NOT NULL,
	[TotalPagar] [decimal](8, 2) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdEmpleado] [int] NOT NULL,
	[IdTipoComprobante] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD  CONSTRAINT [fk_Venta_Detalle] FOREIGN KEY([IdVenta])
REFERENCES [dbo].[Venta] ([IdVenta])
GO
ALTER TABLE [dbo].[DetalleVenta] CHECK CONSTRAINT [fk_Venta_Detalle]
GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD  CONSTRAINT [fk_Venta_Produc] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
ALTER TABLE [dbo].[DetalleVenta] CHECK CONSTRAINT [fk_Venta_Produc]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [fk_Emp_Usu] FOREIGN KEY([IdTipoUsuario])
REFERENCES [dbo].[TipoUsuario] ([IdTipoUsuario])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [fk_Emp_Usu]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [fk_Prod_cat] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([IdCategoria])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [fk_Prod_cat]
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [fk_Vent_Clien] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [fk_Vent_Clien]
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [fk_Vent_Compro] FOREIGN KEY([IdTipoComprobante])
REFERENCES [dbo].[TipoComprobante] ([IdTipoComprobante])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [fk_Vent_Compro]
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [fk_Vent_Emp] FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[Empleado] ([IdEmpleado])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [fk_Vent_Emp]
GO
USE [master]
GO
ALTER DATABASE [Ventas] SET  READ_WRITE 
GO
