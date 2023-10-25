
------SP DE LAS TABLAS ARQUEO, EMPLEADO Y USUARIO ASIGNADAS A HELEN
------SP PARA ARQUEO
CREATE PROCEDURE sp_ArqueoInsert
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
----------------------------------
CREATE PROCEDURE sp_ArqueoSelectAll
AS
	SELECT *
	FROM Arqueo; 
GO
------------------------------------
CREATE PROCEDURE sp_ArqueoUpdate
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
----------------------------------------
CREATE PROCEDURE sp_ArqueoDelete
	@ArqueoId INT
AS 
	BEGIN
		DELETE FROM Arqueo WHERE ArqueoId = @ArqueoId;
	 END; 
GO
-------------------------------------
CREATE PROCEDURE sp_ArqueoSelectById
	@ArqueoId INT
AS
	BEGIN 
		SELECT ArqueoId, UsuarioId, CantidadDe1, CantidadDe5, CantidadDe10, CantidadDe20, CierreCaja, TotalApertura, FinalDia, TotalVentaDelDia, TotalSobrante, TotalFaltante, FechaArqueo
		FROM Arqueo WHERE ArqueoId = @ArqueoId;
	END;
GO
------SP PARA EMPLEADO

CREATE PROCEDURE sp_EmpleadoInsert
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
---------------------------------------

CREATE PROCEDURE sp_EmpleadoSelectAll
AS
	SELECT *
	FROM Empleado; 
GO
---------------------------------
CREATE PROCEDURE sp_EmpleadoUpdate
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
-----------------------------------
CREATE PROCEDURE sp_EmpleadoDelete
	@EmpleadoId INT
AS 
	BEGIN
		DELETE FROM Empleado WHERE EmpleadoId = @EmpleadoId;
	 END; 
GO
----------------------------------
CREATE PROCEDURE sp_EmpleadoSelectById
	@EmpleadoId INT
AS
	BEGIN 
		SELECT EmpleadoId, RolId, EstadoId, Nombre, Apellido, Telefono, DUI, CorreoElectronico
		FROM Empleado WHERE EmpleadoId = @EmpleadoId;
	END;
GO
------SP PARA USUARIO
CREATE PROCEDURE sp_UsuarioInsert
	@EmpleadoId INT,
	@NombreUser VARCHAR(50),
	@Clave VARCHAR(50)
AS 
	BEGIN
		INSERT INTO Usuario (EmpleadoId, NombreUser, Clave)
		VALUES (@EmpleadoId, @NombreUser, @Clave);
	 END; 
GO
------------------------------
CREATE PROCEDURE sp_UsuarioSelectAll
AS
	SELECT *
	FROM Usuario; 
GO
------------------------------
CREATE PROCEDURE sp_UsuarioUpdate
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
-------------------------------
CREATE PROCEDURE sp_UsuarioDelete
	@UsuarioId INT
AS 
	BEGIN
		DELETE FROM Usuario WHERE UsuarioId = @UsuarioId;
	 END; 
GO
--------------------------------
CREATE PROCEDURE sp_UsuarioSelectById
	@UsuarioId INT
AS
	BEGIN 
		SELECT UsuarioId, EmpleadoId, NombreUser
		FROM Usuario WHERE UsuarioId = @UsuarioId;
	END;
GO
