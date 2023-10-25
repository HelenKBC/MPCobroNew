----------------------------ESTADO------------------------------------
CREATE PROCEDURE sp_EstadoInsert
	@Nombre varchar (50)
AS 
	BEGIN
		INSERT INTO ESTADO(Nombre) VALUES (@Nombre);
	 END;	 
GO

CREATE PROCEDURE sp_EstadoSelectAll
AS
	BEGIN
	SELECT  * FROM Estado; 
	END
GO

CREATE PROCEDURE sp_EstadoUpdate
	@Nombre varchar (50),
	@EstadoId int
AS 
	BEGIN
	UPDATE Estado SET Nombre=@Nombre WHERE EstadoId=@EstadoId;
	END
GO

CREATE PROCEDURE sp_EstadoDelete
	@EstadoId int
AS 
BEGIN
	DELETE FROM Estado WHERE EstadoId=@EstadoId
	END
GO

CREATE PROCEDURE sp_EstadoSelectById
	@EstadoId int
AS
	BEGIN 
		SELECT EstadoId,Nombre FROM Estado WHERE EstadoId=@EstadoId;
	END;
GO

-------------------------ROL---------------------------------
CREATE PROCEDURE sp_RolInsert
	@Nombre varchar (50)
AS 
	BEGIN
		INSERT INTO Rol(Nombre) VALUES (@Nombre);
	 END; 
GO

CREATE PROCEDURE sp_RolSelectAll
AS
BEGIN
	SELECT * FROM Rol; 
	END

GO

CREATE PROCEDURE sp_RolUpdate
	@Nombre varchar (50),
	@RolId int
AS 
BEGIN
	UPDATE Rol SET Nombre=@Nombre WHERE RolId=@RolId;
	END
GO

CREATE PROCEDURE sp_RolDelete
	@RolId int
AS 
BEGIN
	DELETE FROM Rol WHERE RolId=@RolId
	END
GO

CREATE PROCEDURE sp_RolSelectById
	@RolId int
AS
	BEGIN 
		SELECT @RolId,Nombre FROM Rol WHERE RolId=@RolId;
	END;
GO

----------------------------COBRO-----------------------------
CREATE PROCEDURE sp_CobroInsert
	@CobroId int,
	@EmpleadoId int,
	@LocalId int,
	@FechaCobro datetime
AS 
	BEGIN
		INSERT INTO Cobro(CobroId, EmpleadoId, LocalId, FechaCobro) VALUES (@CobroId,@EmpleadoId,@LocalId,@FechaCobro);
	 END; 
GO

CREATE PROCEDURE sp_CobroSelectAll
AS
BEGIN
	SELECT CobroId,EmpleadoId,LocalId,FechaCobro FROM Cobro; 
	END
GO

CREATE PROCEDURE sp_CobroUpdate
	@CobroId int,
	@EmpleadoId int,
	@LocalId int,
	@FechaCobro datetime
AS 
BEGIN
	UPDATE Cobro SET EmpleadoId=@EmpleadoId, LocalId=@LocalId, FechaCobro=@FechaCobro 
	WHERE CobroId=@CobroId;
	END
GO

CREATE PROCEDURE sp_CobroDelete
	@CobroId int
AS 
BEGIN
	DELETE FROM Cobro WHERE CobroId=@CobroId
	END
GO

CREATE PROCEDURE sp_CobroSelectById
	@CobroId int
AS
	BEGIN 
		SELECT @CobroId,EmpleadoId,LocalId,FechaCobro FROM Cobro WHERE CobroId=@CobroId;
	END;
GO

------------ARRENDATARIO--------------------------------------------
CREATE PROCEDURE sp_ArrendatarioInsert
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

CREATE PROCEDURE sp_ArrendatarioSelectAll
AS
BEGIN
	SELECT ArrendatarioId,Nombre,Apellido,Telefono,Dui,CorreoElectronico FROM Arrendatario; 

	END
GO

CREATE PROCEDURE sp_ArrendatarioUpdate
	@ArrendatarioId int,
	@Nombre varchar (255),
	@Apellido varchar (255),
	@Telefono varchar (15),
	@Dui varchar (10),
	@CorreoElectronico varchar (255)
AS 
BEGIN
	UPDATE Arrendatario SET Nombre=@Nombre,Apellido=@Apellido,Telefono=@Telefono,Dui=@Dui,CorreoElectronico=@CorreoElectronico
	WHERE ArrendatarioId=@ArrendatarioId;
	END
GO

CREATE PROCEDURE sp_ArrendatarioDelete
	@ArrendatarioId int
AS 
BEGIN
	DELETE FROM Arrendatario WHERE ArrendatarioId=@ArrendatarioId

	END
GO

CREATE PROCEDURE sp_ArrendatarioSelectById
	@Arrendatario int
AS
	BEGIN 
		SELECT ArrendatarioId,Nombre,Apellido,Telefono,Dui,CorreoElectronico
		FROM Arrendatario WHERE ArrendatarioId=@Arrendatario;
	END;
GO