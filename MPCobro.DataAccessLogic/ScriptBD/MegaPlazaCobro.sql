CREATE DATABASE [MegaPlazaCobrosBD]
GO
USE [MegaPlazaCobrosBD]
GO
/****** Object:  Table [dbo].[Arqueo]    Script Date: 08/11/2023 16:14:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Arqueo](
	[ArqueoId] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[CantidadDe1] [int] NOT NULL,
	[CantidadDe5] [int] NOT NULL,
	[CantidadDe10] [int] NOT NULL,
	[CantidadDe20] [int] NOT NULL,
	[CierreCaja] [money] NOT NULL,
	[TotalApertura] [money] NOT NULL,
	[FinalDia] [money] NOT NULL,
	[TotalVentaDelDia] [money] NOT NULL,
	[TotalSobrante] [money] NOT NULL,
	[TotalFaltante] [money] NOT NULL,
	[FechaArqueo] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ArqueoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Arrendatario]    Script Date: 08/11/2023 16:14:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Arrendatario](
	[ArrendatarioId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](255) NOT NULL,
	[Apellido] [varchar](255) NOT NULL,
	[Telefono] [varchar](15) NOT NULL,
	[Dui] [varchar](10) NOT NULL,
	[CorreoElectronico] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ArrendatarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AsignacionLocal]    Script Date: 08/11/2023 16:14:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AsignacionLocal](
	[AsignacionLocalId] [int] IDENTITY(1,1) NOT NULL,
	[LocalId] [int] NOT NULL,
	[ArrendatarioId] [int] NOT NULL,
	[FechaInicio] [datetime] NOT NULL,
	[FechaUltimoPago] [datetime] NOT NULL,
	[Monto] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AsignacionLocalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 08/11/2023 16:14:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[CategoriaId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](255) NOT NULL,
	[Descripcion] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoriaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cobro]    Script Date: 08/11/2023 16:14:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cobro](
	[CobroId] [int] IDENTITY(1,1) NOT NULL,
	[EmpleadoId] [int] NOT NULL,
	[LocalId] [int] NOT NULL,
	[FechaCobro] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CobroId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Edificio]    Script Date: 08/11/2023 16:14:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Edificio](
	[EdificioId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](255) NOT NULL,
	[CantidadLocales] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EdificioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 08/11/2023 16:14:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[EmpleadoId] [int] IDENTITY(1,1) NOT NULL,
	[RolId] [int] NOT NULL,
	[EstadoId] [int] NOT NULL,
	[Nombre] [varchar](60) NOT NULL,
	[Apellido] [varchar](60) NOT NULL,
	[Telefono] [varchar](15) NOT NULL,
	[DUI] [varchar](10) NOT NULL,
	[CorreoElectronico] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[EmpleadoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estado]    Script Date: 08/11/2023 16:14:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado](
	[EstadoId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EstadoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Locales]    Script Date: 08/11/2023 16:14:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locales](
	[LocalesId] [int] IDENTITY(1,1) NOT NULL,
	[EdificioId] [int] NOT NULL,
	[CategoriaId] [int] NOT NULL,
	[EstadoId] [int] NOT NULL,
	[Nombre] [varchar](255) NOT NULL,
	[CodigoDeBarras] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LocalesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 08/11/2023 16:14:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[RolId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 08/11/2023 16:14:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[UsuarioId] [int] IDENTITY(1,1) NOT NULL,
	[EmpleadoId] [int] NOT NULL,
	[NombreUser] [varchar](50) NOT NULL,
	[Clave] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Arrendatario] ON 

INSERT [dbo].[Arrendatario] ([ArrendatarioId], [Nombre], [Apellido], [Telefono], [Dui], [CorreoElectronico]) VALUES (30, N'Juan', N' Perez', N'1234-5678', N'123456789', N'@juanperez')
INSERT [dbo].[Arrendatario] ([ArrendatarioId], [Nombre], [Apellido], [Telefono], [Dui], [CorreoElectronico]) VALUES (33, N'helen ', N'apellido', N'45789', N'12547896', N'Hola@gmail.com')
SET IDENTITY_INSERT [dbo].[Arrendatario] OFF
GO
SET IDENTITY_INSERT [dbo].[AsignacionLocal] ON 

INSERT [dbo].[AsignacionLocal] ([AsignacionLocalId], [LocalId], [ArrendatarioId], [FechaInicio], [FechaUltimoPago], [Monto]) VALUES (2, 8, 33, CAST(N'2023-11-03T00:00:00.000' AS DateTime), CAST(N'2023-11-16T00:00:00.000' AS DateTime), 3.0000)
INSERT [dbo].[AsignacionLocal] ([AsignacionLocalId], [LocalId], [ArrendatarioId], [FechaInicio], [FechaUltimoPago], [Monto]) VALUES (4, 6, 33, CAST(N'2023-11-07T00:00:00.000' AS DateTime), CAST(N'2023-11-07T00:00:00.000' AS DateTime), 3.0000)
INSERT [dbo].[AsignacionLocal] ([AsignacionLocalId], [LocalId], [ArrendatarioId], [FechaInicio], [FechaUltimoPago], [Monto]) VALUES (7, 1, 33, CAST(N'2023-11-08T00:00:00.000' AS DateTime), CAST(N'2023-11-15T00:00:00.000' AS DateTime), 5.0000)
SET IDENTITY_INSERT [dbo].[AsignacionLocal] OFF
GO
SET IDENTITY_INSERT [dbo].[Categoria] ON 

INSERT [dbo].[Categoria] ([CategoriaId], [Nombre], [Descripcion]) VALUES (2, N'Frutas', N'verduras')
SET IDENTITY_INSERT [dbo].[Categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[Cobro] ON 

INSERT [dbo].[Cobro] ([CobroId], [EmpleadoId], [LocalId], [FechaCobro]) VALUES (1, 11, 1, CAST(N'2023-11-15T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Cobro] OFF
GO
SET IDENTITY_INSERT [dbo].[Edificio] ON 

INSERT [dbo].[Edificio] ([EdificioId], [Nombre], [CantidadLocales]) VALUES (1, N'Edificio 2', 53)
SET IDENTITY_INSERT [dbo].[Edificio] OFF
GO
SET IDENTITY_INSERT [dbo].[Empleado] ON 

INSERT [dbo].[Empleado] ([EmpleadoId], [RolId], [EstadoId], [Nombre], [Apellido], [Telefono], [DUI], [CorreoElectronico]) VALUES (3, 2, 2, N'Jose', N'Martinez', N'74523698', N'05263148-9', N'Jose@gmail.com')
INSERT [dbo].[Empleado] ([EmpleadoId], [RolId], [EstadoId], [Nombre], [Apellido], [Telefono], [DUI], [CorreoElectronico]) VALUES (4, 1, 2, N'Helen', N'Bolaños', N'8745641684', N'16515618-5', N'Helen@gmail.com')
INSERT [dbo].[Empleado] ([EmpleadoId], [RolId], [EstadoId], [Nombre], [Apellido], [Telefono], [DUI], [CorreoElectronico]) VALUES (10, 2, 2, N'dfvgd', N'dfv df', N'47856921', N'4156416198', N'@gmail.com')
INSERT [dbo].[Empleado] ([EmpleadoId], [RolId], [EstadoId], [Nombre], [Apellido], [Telefono], [DUI], [CorreoElectronico]) VALUES (11, 1, 1, N'Mia', N'Bolaños', N'61621648', N'545787', N'Helen@gmail.com')
INSERT [dbo].[Empleado] ([EmpleadoId], [RolId], [EstadoId], [Nombre], [Apellido], [Telefono], [DUI], [CorreoElectronico]) VALUES (12, 2, 1, N'felipe', N'Bolaños', N'8489651', N'1651641', N'daniel@gmail.com')
INSERT [dbo].[Empleado] ([EmpleadoId], [RolId], [EstadoId], [Nombre], [Apellido], [Telefono], [DUI], [CorreoElectronico]) VALUES (13, 1, 1, N'Jose', N'Perez', N'74523698', N'05263148-9', N'Jose@gmail.com')
INSERT [dbo].[Empleado] ([EmpleadoId], [RolId], [EstadoId], [Nombre], [Apellido], [Telefono], [DUI], [CorreoElectronico]) VALUES (14, 2, 2, N'jnnkjnknk', N'hkjhbkjhbkjbh', N'415125', N'65651-9', N'Hola@gmail.com')
INSERT [dbo].[Empleado] ([EmpleadoId], [RolId], [EstadoId], [Nombre], [Apellido], [Telefono], [DUI], [CorreoElectronico]) VALUES (15, 2, 2, N'jusns', N'fredvd', N'1245-6785', N'34567889-9', N'wwreyhr7')
SET IDENTITY_INSERT [dbo].[Empleado] OFF
GO
SET IDENTITY_INSERT [dbo].[Estado] ON 

INSERT [dbo].[Estado] ([EstadoId], [Nombre]) VALUES (1, N'Disponible')
INSERT [dbo].[Estado] ([EstadoId], [Nombre]) VALUES (2, N'Inactivo')
INSERT [dbo].[Estado] ([EstadoId], [Nombre]) VALUES (4, N'Asignado')
INSERT [dbo].[Estado] ([EstadoId], [Nombre]) VALUES (5, N'En Mantenimiento')
INSERT [dbo].[Estado] ([EstadoId], [Nombre]) VALUES (6, N'No')
INSERT [dbo].[Estado] ([EstadoId], [Nombre]) VALUES (7, N'Si')
INSERT [dbo].[Estado] ([EstadoId], [Nombre]) VALUES (8, N'asdfghj')
INSERT [dbo].[Estado] ([EstadoId], [Nombre]) VALUES (9, N'651615')
INSERT [dbo].[Estado] ([EstadoId], [Nombre]) VALUES (11, N'jashbjhabd')
INSERT [dbo].[Estado] ([EstadoId], [Nombre]) VALUES (12, N'')
SET IDENTITY_INSERT [dbo].[Estado] OFF
GO
SET IDENTITY_INSERT [dbo].[Locales] ON 

INSERT [dbo].[Locales] ([LocalesId], [EdificioId], [CategoriaId], [EstadoId], [Nombre], [CodigoDeBarras]) VALUES (1, 1, 2, 4, N'Local 1', N'')
INSERT [dbo].[Locales] ([LocalesId], [EdificioId], [CategoriaId], [EstadoId], [Nombre], [CodigoDeBarras]) VALUES (2, 1, 2, 1, N'local2', N'')
INSERT [dbo].[Locales] ([LocalesId], [EdificioId], [CategoriaId], [EstadoId], [Nombre], [CodigoDeBarras]) VALUES (3, 1, 2, 1, N'sdfghjk', N'')
INSERT [dbo].[Locales] ([LocalesId], [EdificioId], [CategoriaId], [EstadoId], [Nombre], [CodigoDeBarras]) VALUES (4, 1, 2, 1, N'local 4', N'0000004')
INSERT [dbo].[Locales] ([LocalesId], [EdificioId], [CategoriaId], [EstadoId], [Nombre], [CodigoDeBarras]) VALUES (5, 1, 2, 1, N'local 5', N'0000005')
INSERT [dbo].[Locales] ([LocalesId], [EdificioId], [CategoriaId], [EstadoId], [Nombre], [CodigoDeBarras]) VALUES (6, 1, 2, 4, N'Local 6', N'0000006')
INSERT [dbo].[Locales] ([LocalesId], [EdificioId], [CategoriaId], [EstadoId], [Nombre], [CodigoDeBarras]) VALUES (7, 1, 2, 1, N'Local 7', N'0000007')
INSERT [dbo].[Locales] ([LocalesId], [EdificioId], [CategoriaId], [EstadoId], [Nombre], [CodigoDeBarras]) VALUES (8, 1, 2, 4, N'Local 8', N'0000008')
INSERT [dbo].[Locales] ([LocalesId], [EdificioId], [CategoriaId], [EstadoId], [Nombre], [CodigoDeBarras]) VALUES (9, 1, 2, 1, N'Local 8', N'0000009')
INSERT [dbo].[Locales] ([LocalesId], [EdificioId], [CategoriaId], [EstadoId], [Nombre], [CodigoDeBarras]) VALUES (10, 1, 2, 1, N'local 10', N'00000010')
INSERT [dbo].[Locales] ([LocalesId], [EdificioId], [CategoriaId], [EstadoId], [Nombre], [CodigoDeBarras]) VALUES (11, 1, 2, 1, N'Local 12', N'00000011')
INSERT [dbo].[Locales] ([LocalesId], [EdificioId], [CategoriaId], [EstadoId], [Nombre], [CodigoDeBarras]) VALUES (12, 1, 2, 1, N'local 13', N'00000012')
INSERT [dbo].[Locales] ([LocalesId], [EdificioId], [CategoriaId], [EstadoId], [Nombre], [CodigoDeBarras]) VALUES (13, 1, 2, 5, N'local 13', N'00000013')
INSERT [dbo].[Locales] ([LocalesId], [EdificioId], [CategoriaId], [EstadoId], [Nombre], [CodigoDeBarras]) VALUES (14, 1, 2, 1, N'Local 14', N'00000014')
INSERT [dbo].[Locales] ([LocalesId], [EdificioId], [CategoriaId], [EstadoId], [Nombre], [CodigoDeBarras]) VALUES (15, 1, 2, 1, N'local 15', N'00000015')
INSERT [dbo].[Locales] ([LocalesId], [EdificioId], [CategoriaId], [EstadoId], [Nombre], [CodigoDeBarras]) VALUES (16, 1, 2, 1, N'Local 16', N'000000000016')
INSERT [dbo].[Locales] ([LocalesId], [EdificioId], [CategoriaId], [EstadoId], [Nombre], [CodigoDeBarras]) VALUES (17, 1, 2, 1, N'Local 17', N'000000000017')
INSERT [dbo].[Locales] ([LocalesId], [EdificioId], [CategoriaId], [EstadoId], [Nombre], [CodigoDeBarras]) VALUES (18, 1, 2, 1, N'Local 18', N'00000018')
INSERT [dbo].[Locales] ([LocalesId], [EdificioId], [CategoriaId], [EstadoId], [Nombre], [CodigoDeBarras]) VALUES (19, 1, 2, 1, N'Local 19', N'00000019')
SET IDENTITY_INSERT [dbo].[Locales] OFF
GO
SET IDENTITY_INSERT [dbo].[Rol] ON 

INSERT [dbo].[Rol] ([RolId], [Nombre]) VALUES (1, N'Admin')
INSERT [dbo].[Rol] ([RolId], [Nombre]) VALUES (2, N'Cobrador')
INSERT [dbo].[Rol] ([RolId], [Nombre]) VALUES (3, N'')
INSERT [dbo].[Rol] ([RolId], [Nombre]) VALUES (4, N'Prueba')
INSERT [dbo].[Rol] ([RolId], [Nombre]) VALUES (5, N'Helen')
INSERT [dbo].[Rol] ([RolId], [Nombre]) VALUES (6, N'Coordinador')
INSERT [dbo].[Rol] ([RolId], [Nombre]) VALUES (7, N'Docente')
INSERT [dbo].[Rol] ([RolId], [Nombre]) VALUES (8, N'Odenanza')
SET IDENTITY_INSERT [dbo].[Rol] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([UsuarioId], [EmpleadoId], [NombreUser], [Clave]) VALUES (2, 11, N'Adios hola', N'1254')
INSERT [dbo].[Usuario] ([UsuarioId], [EmpleadoId], [NombreUser], [Clave]) VALUES (3, 12, N'Juego', N'4567')
INSERT [dbo].[Usuario] ([UsuarioId], [EmpleadoId], [NombreUser], [Clave]) VALUES (4, 12, N'Lipe', N'1235')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[Arqueo]  WITH CHECK ADD FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([UsuarioId])
GO
ALTER TABLE [dbo].[AsignacionLocal]  WITH CHECK ADD FOREIGN KEY([ArrendatarioId])
REFERENCES [dbo].[Arrendatario] ([ArrendatarioId])
GO
ALTER TABLE [dbo].[AsignacionLocal]  WITH CHECK ADD FOREIGN KEY([LocalId])
REFERENCES [dbo].[Locales] ([LocalesId])
GO
ALTER TABLE [dbo].[Cobro]  WITH CHECK ADD FOREIGN KEY([EmpleadoId])
REFERENCES [dbo].[Empleado] ([EmpleadoId])
GO
ALTER TABLE [dbo].[Cobro]  WITH CHECK ADD FOREIGN KEY([LocalId])
REFERENCES [dbo].[Locales] ([LocalesId])
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD FOREIGN KEY([EstadoId])
REFERENCES [dbo].[Estado] ([EstadoId])
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD FOREIGN KEY([RolId])
REFERENCES [dbo].[Rol] ([RolId])
GO
ALTER TABLE [dbo].[Locales]  WITH CHECK ADD FOREIGN KEY([CategoriaId])
REFERENCES [dbo].[Categoria] ([CategoriaId])
GO
ALTER TABLE [dbo].[Locales]  WITH CHECK ADD FOREIGN KEY([EdificioId])
REFERENCES [dbo].[Edificio] ([EdificioId])
GO
ALTER TABLE [dbo].[Locales]  WITH CHECK ADD FOREIGN KEY([EstadoId])
REFERENCES [dbo].[Estado] ([EstadoId])
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([EmpleadoId])
REFERENCES [dbo].[Empleado] ([EmpleadoId])
GO
/****** Object:  StoredProcedure [dbo].[sp_ArqueoDelete]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------------------------------
CREATE PROCEDURE [dbo].[sp_ArqueoDelete]
	@ArqueoId INT
AS 
	BEGIN
		DELETE FROM Arqueo WHERE ArqueoId = @ArqueoId;
	 END; 
GO
/****** Object:  StoredProcedure [dbo].[sp_ArqueoInsert]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------SP DE LAS TABLAS ARQUEO, EMPLEADO Y USUARIO ASIGNADAS A HELEN
------SP PARA ARQUEO
CREATE PROCEDURE [dbo].[sp_ArqueoInsert]
	@UsuarioId INT,
	@CantidadDe1 INT,
	@CantidadDe5 INT,
	@CantidadDe10 INT,
	@CantidadDe20 INT,
	@CierreCaja MONEY,
	@TotalApertura MONEY,
	@FinalDia MONEY,
	@TotalVentaDelDia MONEY,
	@TotalSobrante MONEY,
	@TotalFaltante MONEY,
	@FechaArqueo DATETIME
AS 
	BEGIN
		INSERT INTO Arqueo (UsuarioId, CantidadDe1, CantidadDe5, CantidadDe10, CantidadDe20, CierreCaja, TotalApertura, FinalDia, TotalVentaDelDia, TotalSobrante, TotalFaltante, FechaArqueo)
		VALUES (@UsuarioId, @CantidadDe1, @CantidadDe5, @CantidadDe10, @CantidadDe20, @CierreCaja, @TotalApertura, @FinalDia, @TotalVentaDelDia, @TotalSobrante, @TotalFaltante, @FechaArqueo);
	 END; 
GO
/****** Object:  StoredProcedure [dbo].[sp_ArqueoSelectAll]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------------------------
CREATE PROCEDURE [dbo].[sp_ArqueoSelectAll]
AS
	SELECT *
	FROM Arqueo; 
GO
/****** Object:  StoredProcedure [dbo].[sp_ArqueoSelectById]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------------
CREATE PROCEDURE [dbo].[sp_ArqueoSelectById]
	@ArqueoId INT
AS
	BEGIN 
		SELECT ArqueoId, UsuarioId, CantidadDe1, CantidadDe5, CantidadDe10, CantidadDe20, CierreCaja, TotalApertura, FinalDia, TotalVentaDelDia, TotalSobrante, TotalFaltante, FechaArqueo
		FROM Arqueo WHERE ArqueoId = @ArqueoId;
	END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ArqueoUpdate]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
CREATE PROCEDURE [dbo].[sp_ArqueoUpdate]
	@ArqueoId INT,
	@UsuarioId INT,
	@CantidadDe1 INT,
	@CantidadDe5 INT,
	@CantidadDe10 INT,
	@CantidadDe20 INT,
	@CierreCaja MONEY,
	@TotalApertura MONEY,
	@FinalDia MONEY,
	@TotalVentaDelDia MONEY,
	@TotalSobrante MONEY,
	@TotalFaltante MONEY,
	@FechaArqueo DATETIME
AS 
	BEGIN
		UPDATE Arqueo
		SET UsuarioId = @UsuarioId, CantidadDe1 = @CantidadDe1, CantidadDe5 = @CantidadDe5, CantidadDe10 = @CantidadDe10, CantidadDe20 = @CantidadDe20,
			CierreCaja = @CierreCaja, TotalApertura = @TotalApertura, FinalDia = @FinalDia, TotalVentaDelDia = @TotalVentaDelDia, 
			TotalSobrante = @TotalSobrante, TotalFaltante = @TotalFaltante, FechaArqueo = @FechaArqueo
		WHERE ArqueoId = @ArqueoId;
	 END; 
GO
/****** Object:  StoredProcedure [dbo].[sp_ArrendatarioDelete]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ArrendatarioDelete]
	@ArrendatarioId int
AS 
begin
	DELETE FROM Arrendatario WHERE ArrendatarioId=@ArrendatarioId
end
GO
/****** Object:  StoredProcedure [dbo].[sp_ArrendatarioInsert]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------ARRENDATARIO--------------------------------------------
CREATE PROCEDURE [dbo].[sp_ArrendatarioInsert]
	@Nombre varchar (255),
	@Apellido varchar (255),
	@Telefono varchar (15),
	@Dui varchar (10),
	@CorreoElectronico varchar (255)
AS 
	BEGIN
		INSERT INTO Arrendatario(Nombre,Apellido,Telefono,Dui,CorreoElectronico) 
		VALUES (@Nombre,@Apellido,@Telefono,@Dui,@CorreoElectronico);
	 END;	 
	
GO
/****** Object:  StoredProcedure [dbo].[sp_ArrendatarioSelectAll]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[sp_ArrendatarioSelectAll]
AS
begin
	SELECT ArrendatarioId,Nombre,Apellido,Telefono,Dui,CorreoElectronico FROM Arrendatario; 
end
GO
/****** Object:  StoredProcedure [dbo].[sp_ArrendatarioSelectById]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ArrendatarioSelectById]
	@Arrendatario int
AS
	BEGIN 
		SELECT ArrendatarioId,Nombre,Apellido,Telefono,Dui,CorreoElectronico
		FROM Arrendatario WHERE ArrendatarioId=@Arrendatario;
	END;
	exec sp_ArrendatarioSelectById 1
GO
/****** Object:  StoredProcedure [dbo].[sp_ArrendatarioUpdate]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ArrendatarioUpdate]
	@ArrendatarioId int,
	@Nombre varchar (255),
	@Apellido varchar (255),
	@Telefono varchar (15),
	@Dui varchar (10),
	@CorreoElectronico varchar (255)
AS 
begin
	UPDATE Arrendatario SET Nombre=@Nombre,Apellido=@Apellido,Telefono=@Telefono,Dui=@Dui,CorreoElectronico=@CorreoElectronico
	WHERE ArrendatarioId=@ArrendatarioId;
end
GO
/****** Object:  StoredProcedure [dbo].[sp_AsigFechaUltimoPagoUpdate]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----*** UPDATE

CREATE PROCEDURE [dbo].[sp_AsigFechaUltimoPagoUpdate]
@AsignacionLocalId INT,
@FechaUltimoPago DATETIME

AS
   BEGIN
   UPDATE AsignacionLocal
   SET FechaUltimoPago= @FechaUltimoPago
   WHERE AsignacionLocalId = @AsignacionLocalId;
   END;
GO
/****** Object:  StoredProcedure [dbo].[sp_AsignacionLocalDelete]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--****DELETE
CREATE PROCEDURE [dbo].[sp_AsignacionLocalDelete]
   @AsignacionLocalId INT
 AS
  BEGIN
     DELETE FROM AsignacionLocal WHERE AsignacionLocalId = @AsignacionLocalId;
 END;
GO
/****** Object:  StoredProcedure [dbo].[sp_AsignacionLocalInsert]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SP ASIGNACIONLOCAL   **INSERT

CREATE PROCEDURE [dbo].[sp_AsignacionLocalInsert]
@LocalId INT,
@ArrendatarioId INT,
@FechaInicio DATETIME,
@FechaUltimoPago DATETIME,
@Monto MONEY
AS
  BEGIN
     INSERT INTO AsignacionLocal(LocalID,ArrendatarioID,FechaInicio,FechaUltimoPago,Monto)
     VALUES( @LocalId,@ArrendatarioId,@FechaInicio,@FechaUltimoPago,@Monto);
  END;
GO
/****** Object:  StoredProcedure [dbo].[sp_AsignacionLocalSelectAll]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  -------------*****SELECTALL
  CREATE PROCEDURE [dbo].[sp_AsignacionLocalSelectAll]
 AS
    SELECT * FROM AsignacionLocal;
GO
/****** Object:  StoredProcedure [dbo].[sp_AsignacionLocalSelectById]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---***SELECTBYID
CREATE PROCEDURE [dbo].[sp_AsignacionLocalSelectById]
   @AsignacionLocalId INT
AS
   BEGIN
   SELECT AsignacionLocalId, LocalId, ArrendatarioId, FechaInicio, FechaUltimoPago, Monto
   FROM AsignacionLocal WHERE AsignacionLocalId = @AsignacionLocalId;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_AsignacionLocalUpdate]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----*** UPDATE

CREATE PROCEDURE [dbo].[sp_AsignacionLocalUpdate]
@AsignacionLocalId INT,
@LocalId INT,
@ArrendatarioId INT,
@FechaInicio DATETIME,
@FechaUltimoPago DATETIME,
@Monto MONEY

AS
   BEGIN
   UPDATE AsignacionLocal
   SET LocalID= @LocalId, ArrendatarioID= @ArrendatarioId, FechaInicio= @FechaInicio, FechaUltimoPago= @FechaUltimoPago, Monto= @Monto
   WHERE AsignacionLocalId = @AsignacionLocalId;
   END;
GO
/****** Object:  StoredProcedure [dbo].[sp_CategoriaDelete]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------

--*** DELETE**

CREATE PROCEDURE [dbo].[sp_CategoriaDelete]
 @CategoriaId INT
AS
  BEGIN
     DELETE FROM Categoria WHERE CategoriaId = @CategoriaId;
	 END;
GO
/****** Object:  StoredProcedure [dbo].[sp_CategoriaInsert]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---------------------

--  SP PARA CATEGORIA ***

-- **INSERT**
CREATE PROCEDURE [dbo].[sp_CategoriaInsert]
  @Nombre VARCHAR (255),
  @Descripcion VARCHAR(255)
AS
  BEGIN 
  INSERT INTO Categoria( Nombre,Descripcion)
  VALUES(@Nombre,@Descripcion);
  END;
GO
/****** Object:  StoredProcedure [dbo].[sp_CategoriaSelectAll]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------------------------------

--**SELECTALL

CREATE PROCEDURE [dbo].[sp_CategoriaSelectAll]
 AS
  SELECT * FROM Categoria;
GO
/****** Object:  StoredProcedure [dbo].[sp_CategoriaSelectById]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-----------------

--** SELECTBYID

CREATE PROCEDURE  [dbo].[sp_CategoriaSelectById]
  @CategoriaId INT
AS
   BEGIN
     SELECT CategoriaId, Nombre, Descripcion
     FROM Categoria WHERE CategoriaId= @CategoriaId;
   END;
GO
/****** Object:  StoredProcedure [dbo].[sp_CategoriaUpdate]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------------

--**UPDATE
CREATE PROCEDURE [dbo].[sp_CategoriaUpdate]
  @CategoriaId INT,
  @Nombre VARCHAR(255),
  @Descripcion VARCHAR(255)
AS
   BEGIN 
   UPDATE Categoria
   SET Nombre= @Nombre, Descripcion= @Descripcion
      WHERE CategoriaId = @CategoriaId;
  END;
GO
/****** Object:  StoredProcedure [dbo].[sp_CobroDelete]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_CobroDelete]
	@CobroId int
AS 
Begin
	DELETE FROM Cobro WHERE CobroId=@CobroId
End
GO
/****** Object:  StoredProcedure [dbo].[sp_CobroInsert]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----------------------------COBRO-----------------------------
CREATE PROCEDURE [dbo].[sp_CobroInsert]

	@EmpleadoId int,
	@LocalId int,
	@FechaCobro datetime
AS 
	BEGIN
		INSERT INTO Cobro(EmpleadoId, LocalId, FechaCobro) 
		VALUES (@EmpleadoId,@LocalId,@FechaCobro);
	 END; 
GO
/****** Object:  StoredProcedure [dbo].[sp_CobroSelecAll]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_CobroSelecAll]
AS
	SELECT CobroId,EmpleadoId,LocalId,FechaCobro FROM Cobro; 
	exec sp_CobroSelecAll
GO
/****** Object:  StoredProcedure [dbo].[sp_CobroSelectById]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_CobroSelectById]
	@CobroId int
AS
	BEGIN 
		SELECT @CobroId,EmpleadoId,LocalId,FechaCobro FROM Cobro WHERE CobroId=@CobroId;
	END;
	exec sp_CobroSelectById 1
GO
/****** Object:  StoredProcedure [dbo].[sp_CobroUpdate]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_CobroUpdate]
	@CobroId int,
	@EmpleadoId int,
	@LocalId int,
	@FechaCobro datetime
AS 
	UPDATE Cobro SET EmpleadoId=@EmpleadoId, LocalId=@LocalId, FechaCobro=@FechaCobro 
	WHERE CobroId=@CobroId;
GO
/****** Object:  StoredProcedure [dbo].[sp_EdificioDelete]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------
--** DELETE**

CREATE PROCEDURE [dbo].[sp_EdificioDelete]
  @EdificioId INT
AS
  BEGIN 
     DELETE FROM Edificio WHERE EdificioId = @EdificioId;
  END;
GO
/****** Object:  StoredProcedure [dbo].[sp_EdificioInsert]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--**** SP PARA EDIFICIO

--   ** INSERT **
CREATE PROCEDURE [dbo].[sp_EdificioInsert]
@Nombre VARCHAR(255),
@CantidadLocales INT

AS
  BEGIN 
    INSERT INTO Edificio( Nombre, CantidadLocales)
    VALUES (@Nombre, @CantidadLocales);
 END;
GO
/****** Object:  StoredProcedure [dbo].[sp_EdificioSelectAll]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------------

--** SELECTALL
CREATE PROCEDURE [dbo].[sp_EdificioSelectAll]
AS
   SELECT * FROM Edificio;
GO
/****** Object:  StoredProcedure [dbo].[sp_EdificioSelectById]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------

--** SELECTBYID

CREATE PROCEDURE [dbo].[sp_EdificioSelectById]
 @EdificioId INT
AS
   BEGIN
     SELECT EdificioId, Nombre, CantidadLocales
     FROM Edificio WHERE EdificioId = @EdificioId;
  END;
GO
/****** Object:  StoredProcedure [dbo].[sp_EdificioUpdate]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---------------

--**UPDATE

CREATE PROCEDURE [dbo].[sp_EdificioUpdate]
  @EdificioId INT,
  @Nombre VARCHAR(60),
  @CantidadLocales INT
AS
   BEGIN 
   UPDATE Edificio
   SET Nombre = @Nombre, CantidadLocales = @CantidadLocales
   WHERE EdificioId = @EdificioId;
   END;
GO
/****** Object:  StoredProcedure [dbo].[sp_EmpleadoDelete]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-----------------------------------
CREATE PROCEDURE [dbo].[sp_EmpleadoDelete]
	@EmpleadoId INT
AS 
	BEGIN
		UPDATE Empleado
		SET EstadoId = 2
		WHERE EmpleadoId = @EmpleadoId;
	 END; 
GO
/****** Object:  StoredProcedure [dbo].[sp_EmpleadoInsert]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------SP PARA EMPLEADO

CREATE PROCEDURE [dbo].[sp_EmpleadoInsert]
	@RolId INT,
	@EstadoId INT,
	@Nombre VARCHAR(60),
	@Apellido VARCHAR(60),
	@Telefono VARCHAR(15),
	@DUI VARCHAR(10),
	@CorreoElectronico VARCHAR(255)
AS 
	BEGIN
		INSERT INTO Empleado (RolId, EstadoId, Nombre, Apellido, Telefono, DUI, CorreoElectronico)
		VALUES (@RolId, @EstadoId, @Nombre, @Apellido, @Telefono, @DUI, @CorreoElectronico);
	 END; 
GO
/****** Object:  StoredProcedure [dbo].[sp_EmpleadoSelectAll]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---------------------------------------

CREATE PROCEDURE [dbo].[sp_EmpleadoSelectAll]
AS
begin
	SELECT *
	FROM Empleado Order by Empleado.EstadoId asc; 
end
GO
/****** Object:  StoredProcedure [dbo].[sp_EmpleadoSelectById]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------------------------
CREATE PROCEDURE [dbo].[sp_EmpleadoSelectById]
	@EmpleadoId INT
AS
	BEGIN 
		SELECT EmpleadoId, RolId, EstadoId, Nombre, Apellido, Telefono, DUI, CorreoElectronico
		FROM Empleado WHERE EmpleadoId = @EmpleadoId;
	END;
GO
/****** Object:  StoredProcedure [dbo].[sp_EmpleadoUpdate]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---------------------------------
CREATE PROCEDURE [dbo].[sp_EmpleadoUpdate]
	@EmpleadoId INT,
	@RolId INT,
	@EstadoId INT,
	@Nombre VARCHAR(60),
	@Apellido VARCHAR(60),
	@Telefono VARCHAR(15),
	@DUI VARCHAR(10),
	@CorreoElectronico VARCHAR(255)
AS 
	BEGIN
		UPDATE Empleado
		SET RolId = @RolId, EstadoId = @EstadoId, Nombre = @Nombre, Apellido = @Apellido, Telefono = @Telefono, DUI = @DUI, CorreoElectronico = @CorreoElectronico
		WHERE EmpleadoId = @EmpleadoId;
	 END; 
GO
/****** Object:  StoredProcedure [dbo].[sp_EstadoDelete]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_EstadoDelete]
	@EstadoId int
AS 
begin
	DELETE FROM Estado WHERE EstadoId=@EstadoId
end

GO
/****** Object:  StoredProcedure [dbo].[sp_EstadoInsert]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------------------ESTADO------------------------------------
CREATE PROCEDURE [dbo].[sp_EstadoInsert]
	@Nombre varchar (50)
AS 
	BEGIN
		INSERT INTO ESTADO(Nombre) VALUES (@Nombre);
	 END
GO
/****** Object:  StoredProcedure [dbo].[sp_EstadoSelectAll]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_EstadoSelectAll]
AS
begin
	SELECT * FROM Estado; 
end
GO
/****** Object:  StoredProcedure [dbo].[sp_EstadoSelectById]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_EstadoSelectById]
	@EstadoId int
AS
	BEGIN 
		SELECT EstadoId,Nombre FROM Estado WHERE EstadoId=@EstadoId;
	END;
GO
/****** Object:  StoredProcedure [dbo].[sp_EstadoUpdate]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_EstadoUpdate]
	@Nombre varchar (50),
	@EstadoId int
AS 
begin
	UPDATE Estado SET Nombre=@Nombre WHERE EstadoId=@EstadoId;
	end
GO
/****** Object:  StoredProcedure [dbo].[sp_LocalesDelete]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--*******DELETE

CREATE PROCEDURE [dbo].[sp_LocalesDelete]
  @LocalesId INT
  AS 
    BEGIN 
	   DELETE FROM Locales WHERE LocalesId =@LocalesId;
   END;
GO
/****** Object:  StoredProcedure [dbo].[sp_LocalesInsert]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--- SP PARA LOCALES 

-- **INSERT 

CREATE PROCEDURE [dbo].[sp_LocalesInsert]
 @EdificioId INT,
 @CategoriaId INT,
 @EstadoId INT,
 @Nombre VARCHAR(255),
 @CodigoDeBarras VARCHAR(255)
AS
  BEGIN
  INSERT INTO Locales( EdificioID, CategoriaID, EstadoID, Nombre, CodigoDeBarras)
  VALUES(@EdificioId, @CategoriaId, @EstadoId, @Nombre, @CodigoDeBarras);
  END;
 /* Select SCOPE_IDENTITY()*/
GO
/****** Object:  StoredProcedure [dbo].[sp_LocalesSelectAll]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--------------------

--       ****SELECTALL
CREATE PROCEDURE [dbo].[sp_LocalesSelectAll]
AS
  SELECT * FROM Locales;
GO
/****** Object:  StoredProcedure [dbo].[sp_LocalesSelectById]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--****SELECTBYID

CREATE PROCEDURE [dbo].[sp_LocalesSelectById]
  @LocalesId INT
AS
  BEGIN
    SELECT LocalesId, EdificioId, CategoriaId,EstadoId, Nombre, CodigoDeBarras
	FROM Locales WHERE LocalesId= @LocalesId;
	END;
GO
/****** Object:  StoredProcedure [dbo].[sp_LocalesUpdate]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--********* UPDATE

CREATE PROCEDURE [dbo].[sp_LocalesUpdate]
 @LocalesId INT,
 @EdificioId INT,
 @CategoriaId INT,
 @EstadoId INT,
 @Nombre VARCHAR(255),
 @CodigoDeBarras VARCHAR(255)
AS
 BEGIN 
    UPDATE Locales
	SET EdificioID= @EdificioId, CategoriaID= @CategoriaId, EstadoID= @EstadoId, Nombre= @Nombre, CodigoDeBarras= @CodigoDeBarras
	WHERE LocalesId = @LocalesId;
	END;
GO
/****** Object:  StoredProcedure [dbo].[sp_LocalesUpdateStates]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_LocalesUpdateStates]
 @LocalesId INT,
 @EstadoId INT
AS
 BEGIN 
    UPDATE Locales
	SET  EstadoID= @EstadoId
	WHERE LocalesId = @LocalesId;
	END;
GO
/****** Object:  StoredProcedure [dbo].[sp_RolDelete]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_RolDelete]
	@RolId int
AS 
begin
	DELETE FROM Rol WHERE RolId=@RolId
	end
GO
/****** Object:  StoredProcedure [dbo].[sp_RolInsert]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-------------------------ROL---------------------------------
CREATE PROCEDURE [dbo].[sp_RolInsert]
	@Nombre varchar (50)
AS 
	BEGIN
		INSERT INTO Rol(Nombre) VALUES (@Nombre);
	 END; 
GO
/****** Object:  StoredProcedure [dbo].[sp_RolSelectAll]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_RolSelectAll]
AS
begin
	SELECT * FROM Rol; 
end
GO
/****** Object:  StoredProcedure [dbo].[sp_RolSelectById]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_RolSelectById]
	@RolId int
AS
	BEGIN 
		SELECT @RolId,Nombre FROM Rol WHERE RolId=@RolId;
	END;
GO
/****** Object:  StoredProcedure [dbo].[sp_RolUpdate]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_RolUpdate]
	@Nombre varchar(50),
	@RolId int
AS 
begin
	UPDATE Rol SET Nombre=@Nombre WHERE RolId=@RolId;
end
GO
/****** Object:  StoredProcedure [dbo].[sp_UsuarioDelete]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------
CREATE PROCEDURE [dbo].[sp_UsuarioDelete]
	@UsuarioId INT
AS 
	BEGIN
		DELETE FROM Usuario WHERE UsuarioId = @UsuarioId;
	 END; 
GO
/****** Object:  StoredProcedure [dbo].[sp_UsuarioInsert]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------SP PARA USUARIO
CREATE PROCEDURE [dbo].[sp_UsuarioInsert]
	@EmpleadoId INT,
	@NombreUser VARCHAR(50),
	@Clave VARCHAR(50)
AS 
	BEGIN
		INSERT INTO Usuario (EmpleadoId, NombreUser, Clave)
		VALUES (@EmpleadoId, @NombreUser, @Clave);
	 END; 
GO
/****** Object:  StoredProcedure [dbo].[sp_UsuarioSelectAll]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------
CREATE PROCEDURE [dbo].[sp_UsuarioSelectAll]
AS
	SELECT *
	FROM Usuario; 
GO
/****** Object:  StoredProcedure [dbo].[sp_UsuarioSelectById]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--------------------------------
CREATE PROCEDURE [dbo].[sp_UsuarioSelectById]
	@UsuarioId INT
AS
	BEGIN 
		SELECT UsuarioId, EmpleadoId, NombreUser
		FROM Usuario WHERE UsuarioId = @UsuarioId;
	END;
GO
/****** Object:  StoredProcedure [dbo].[sp_UsuarioUpdate]    Script Date: 08/11/2023 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------
CREATE PROCEDURE [dbo].[sp_UsuarioUpdate]
	@UsuarioId INT,
	@EmpleadoId INT,
	@NombreUser VARCHAR(50),
	@Clave VARCHAR(50)
AS 
	BEGIN
		UPDATE Usuario
		SET EmpleadoId = @EmpleadoId, NombreUser = @NombreUser, Clave = @Clave
		WHERE UsuarioId = @UsuarioId;
	 END; 
GO
USE [master]
GO
ALTER DATABASE [MegaPlazaCobrosBD] SET  READ_WRITE 
GO
