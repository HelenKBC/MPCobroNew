--sp de las tablas AsignacionLocal, Locales, Edificios,Categoria

use MegaPlazaCobrosBD
go

-- SP ASIGNACIONLOCAL   **INSERT

CREATE PROCEDURE sp_AsignacionLocalInsert
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

  -------------*****SELECTALL
  CREATE PROCEDURE sp_AsignacionLocalSelectAll
 AS
    SELECT * FROM AsignacionLocal;
GO

-----*** UPDATE

CREATE PROCEDURE sp_AsignacionLocalUpdate
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

--****DELETE
CREATE PROCEDURE sp_AsignacionLocalDelete
   @AsignacionLocalId INT
 AS
  BEGIN
     DELETE FROM AsignacionLocal WHERE AsignacionLocalId = @AsignacionLocalId;
 END;
GO

---***SELECTBYID
CREATE PROCEDURE sp_AsignacionLocalSelectById
   @AsignacionLocalId INT
AS
   BEGIN
   SELECT AsignacionLocalId, LocalId, ArrendatarioId, FechaInicio, FechaUltimoPago, Monto
   FROM AsignacionLocal WHERE AsignacionLocalId = @AsignacionLocalId;
END;
GO

--- SP PARA LOCALES 

-- **INSERT 

CREATE PROCEDURE sp_LocalesInsert
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
GO
--------------------

--       ****SELECTALL
CREATE PROCEDURE sp_LocalesSelectAll
AS
  SELECT * FROM Locales;
GO

--********* UPDATE

CREATE PROCEDURE sp_LocalesUpdate
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

--*******DELETE

CREATE PROCEDURE sp_LocalesDelete
  @LocalesId INT
  AS 
    BEGIN 
	   DELETE FROM Locales WHERE LocalesId =@LocalesId;
   END;
GO

--****SELECTBYID

CREATE PROCEDURE sp_LocalesSelectById
  @LocalesId INT
AS
  BEGIN
    SELECT LocalesId, EdificioId, CategoriaId,EstadoId, Nombre, CodigoDeBarras
	FROM Locales WHERE LocalesId= @LocalesId;
	END;
GO

--**** SP PARA EDIFICIO

--   ** INSERT **
CREATE PROCEDURE sp_EdificioInsert
@Nombre VARCHAR(255),
@CantidadLocales INT

AS
  BEGIN 
    INSERT INTO Edificio( Nombre, CantidadLocales)
    VALUES (@Nombre, @CantidadLocales);
 END;
GO
----------------------

--** SELECTALL
CREATE PROCEDURE sp_EdificioSelectAll
AS
   SELECT * FROM Edificio;
GO

---------------

--**UPDATE

CREATE PROCEDURE sp_EdificioUpdate
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

-----------
--** DELETE**

CREATE PROCEDURE sp_EdificioDelete
  @EdificioId INT
AS
  BEGIN 
     DELETE FROM Edificio WHERE EdificioId = @EdificioId;
  END;
GO
------------------

--** SELECTBYID

CREATE PROCEDURE sp_EdificioSelectById
 @EdificioId INT
AS
   BEGIN
     SELECT EdificioId, Nombre, CantidadLocales
     FROM Edificio WHERE EdificioId = @EdificioId;
  END;
GO
---------------------

--  SP PARA CATEGORIA ***

-- **INSERT**
CREATE PROCEDURE sp_CategoriaInsert
  @Nombre VARCHAR (255),
  @Descripcion VARCHAR(255)
AS
  BEGIN 
  INSERT INTO Categoria( Nombre,Descripcion)
  VALUES(@Nombre,@Descripcion);
  END;
GO
----------------------------------------

--**SELECTALL

CREATE PROCEDURE sp_CategoriaSelectAll
 AS
  SELECT * FROM Categoria;
 GO
-------------------------------------

--**UPDATE
CREATE PROCEDURE sp_CategoriaUpdate
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
------------------

--*** DELETE**

CREATE PROCEDURE sp_CategoriaDelete
 @CategoriaId INT
AS
  BEGIN
     DELETE FROM Categoria WHERE CategoriaId = @CategoriaId;
	 END;
GO
-----------------

--** SELECTBYID

CREATE PROCEDURE  sp_CategoriaSelectById
  @CategoriaId INT
AS
   BEGIN
     SELECT CategoriaId, Nombre, Descripcion
     FROM Categoria WHERE CategoriaId= @CategoriaId;
   END;
GO














