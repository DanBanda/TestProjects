CREATE DATABASE PruebaBD
GO

USE [PruebaBD]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 3/3/2023 3:05:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Contrasena] [varchar](50) NULL,
	[Estado] [bit] NULL,
	[Nombre] [varchar](100) NULL,
	[Genero] [char](1) NULL,
	[Edad] [int] NULL,
	[Direccion] [varchar](500) NULL,
	[Telefono] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuenta]    Script Date: 3/3/2023 3:05:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuenta](
	[NumCuenta] [int] IDENTITY(1,1) NOT NULL,
	[TipoCuenta] [varchar](50) NULL,
	[SaldoInicial] [money] NULL,
	[Estado] [bit] NULL,
	[Cliente] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[NumCuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimiento]    Script Date: 3/3/2023 3:05:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimiento](
	[IdMovimiento] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [date] NULL,
	[Cliente] [varchar](100) NULL,
	[NumCuenta] [int] NULL,
	[TipoMovimiento] [varchar](50) NULL,
	[Valor] [money] NULL,
	[Estado] [bit] NULL,
	[DescMovimiento] [varchar](100) NULL,
	[SaldoFinal] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMovimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([IdCliente], [Contrasena], [Estado], [Nombre], [Genero], [Edad], [Direccion], [Telefono]) VALUES (1, N'12345', 1, N'Daniel Banda', N'M', 30, N'Via Gracia 113', N'8119765106')
INSERT [dbo].[Cliente] ([IdCliente], [Contrasena], [Estado], [Nombre], [Genero], [Edad], [Direccion], [Telefono]) VALUES (2, N'12345', 1, N'Alejandro Parra', N'M', 25, N'Valle del Mirador', N'8120167599')
INSERT [dbo].[Cliente] ([IdCliente], [Contrasena], [Estado], [Nombre], [Genero], [Edad], [Direccion], [Telefono]) VALUES (3, N'12345', 1, N'Alejandro Vargas', N'M', 35, N'Las Almas', N'0102030405')
INSERT [dbo].[Cliente] ([IdCliente], [Contrasena], [Estado], [Nombre], [Genero], [Edad], [Direccion], [Telefono]) VALUES (5, N'x$fde23&', 1, N'Rodrigo Moran', N'M', 25, N'Valle de Mitras', N'0102030405')
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Cuenta] ON 

INSERT [dbo].[Cuenta] ([NumCuenta], [TipoCuenta], [SaldoInicial], [Estado], [Cliente]) VALUES (1, N'Ahorro', 5000.0000, 1, N'Daniel Banda')
INSERT [dbo].[Cuenta] ([NumCuenta], [TipoCuenta], [SaldoInicial], [Estado], [Cliente]) VALUES (2, N'Corriente', 10000.0000, 1, N'Daniel Banda')
SET IDENTITY_INSERT [dbo].[Cuenta] OFF
GO
SET IDENTITY_INSERT [dbo].[Movimiento] ON 

INSERT [dbo].[Movimiento] ([IdMovimiento], [Fecha], [Cliente], [NumCuenta], [TipoMovimiento], [Valor], [Estado], [DescMovimiento], [SaldoFinal]) VALUES (1, CAST(N'2023-02-20' AS Date), N'Daniel Banda', 1, N'Ahorro', 500.0000, 1, N'Retiro 500 de su cuenta de ahorro', 4500.0000)
SET IDENTITY_INSERT [dbo].[Movimiento] OFF
GO
