Create DataBase MegaPlazaCobrosBD
GO
USE [MegaPlazaCobrosBD]
GO
/****** Object:  Table [dbo].[Arqueo]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  Table [dbo].[Arrendatario]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  Table [dbo].[AsignacionLocal]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  Table [dbo].[Categoria]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  Table [dbo].[Cobro]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  Table [dbo].[Edificio]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  Table [dbo].[Empleado]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  Table [dbo].[Estado]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  Table [dbo].[Locales]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  Table [dbo].[Rol]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  Table [dbo].[Usuario]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_ArqueoDelete]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_ArqueoInsert]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_ArqueoSelectAll]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_ArqueoSelectById]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_ArqueoUpdate]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_ArrendatarioDelete]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_ArrendatarioInsert]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_ArrendatarioSelectAll]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_ArrendatarioSelectById]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_ArrendatarioUpdate]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_AsigFechaUltimoPagoUpdate]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_AsignacionLocalDelete]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_AsignacionLocalInsert]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_AsignacionLocalSelectAll]    Script Date: 08/11/2023 18:39:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  -------------*****SELECTALL
  CREATE PROCEDURE [dbo].[sp_AsignacionLocalSelectAll]
 AS
    SELECT * FROM AsignacionLocal;
GO
/****** Object:  StoredProcedure [dbo].[sp_AsignacionLocalSelectById]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_AsignacionLocalUpdate]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_CategoriaDelete]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_CategoriaInsert]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_CategoriaSelectAll]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_CategoriaSelectById]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_CategoriaUpdate]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_CobroDelete]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_CobroInsert]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_CobroSelecAll]    Script Date: 08/11/2023 18:39:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_CobroSelecAll]
AS
	SELECT CobroId,EmpleadoId,LocalId,FechaCobro FROM Cobro; 
	exec sp_CobroSelecAll
GO
/****** Object:  StoredProcedure [dbo].[sp_CobroSelectById]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_CobroUpdate]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_EdificioDelete]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_EdificioInsert]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_EdificioSelectAll]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_EdificioSelectById]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_EdificioUpdate]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_EmpleadoDelete]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_EmpleadoInsert]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_EmpleadoSelectAll]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_EmpleadoSelectById]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_EmpleadoUpdate]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_EstadoDelete]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_EstadoInsert]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_EstadoSelectAll]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_EstadoSelectById]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_EstadoUpdate]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_LocalesDelete]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_LocalesInsert]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_LocalesSelectAll]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_LocalesSelectById]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_LocalesUpdate]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_LocalesUpdateStates]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_RolDelete]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_RolInsert]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_RolSelectAll]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_RolSelectById]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_RolUpdate]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_UsuarioDelete]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_UsuarioInsert]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_UsuarioSelectAll]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_UsuarioSelectById]    Script Date: 08/11/2023 18:39:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_UsuarioUpdate]    Script Date: 08/11/2023 18:39:20 ******/
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
CREATE PROCEDURE [dbo].[sp_Login]
	@NombreUser varchar(50),
	@Clave varchar (50)
AS
BEGIN
	Select * from Usuario where usuario.clave = @clave and usuario.NombreUser = @NombreUser
END
GO
