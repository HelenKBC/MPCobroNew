Create database MegaPlazaCobrosBD
go
use MegaPlazaCobrosBD
go
-- Tabla Edificio
CREATE TABLE Edificio (
    EdificioId INT not null PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(255) not null,
    CantidadLocales INT not null,
);
go
-- Tabla Categoria
CREATE TABLE Categoria (
    CategoriaId INT not null PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(255)not null,
    Descripcion VARCHAR(255)
);
GO
CREATE TABLE Estado(
    EstadoId INT not null PRIMARY KEY IDENTITY(1,1),
	Nombre VARCHAR(50) NOT NULL
);
go
-- Tabla Local
CREATE TABLE Locales (
    LocalesId INT not null PRIMARY KEY IDENTITY(1,1),
    EdificioId INT not null,
    CategoriaId INT not null,
    EstadoId INT not null,
    Nombre VARCHAR(255) not null,
    CodigoDeBarras VARCHAR(255) not null,
    FOREIGN KEY (EdificioId) REFERENCES Edificio(EdificioId),
    FOREIGN KEY (CategoriaId) REFERENCES Categoria(CategoriaId),
    FOREIGN KEY (EstadoId) REFERENCES Estado(EstadoId)
);
go
-- Tabla Arrendatario
CREATE TABLE Arrendatario (
    ArrendatarioId INT not null PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(255) not null,
    Apellido VARCHAR(255) not null,
    Telefono VARCHAR(15) not null,
    Dui VARCHAR (10) not null,
    CorreoElectronico VARCHAR(255)
);
go
-- Tabla Alquiler
CREATE TABLE AsignacionLocal (
    AsignacionLocalId INT not null PRIMARY KEY IDENTITY(1,1),
    LocalId INT not null,
    ArrendatarioId INT not null,
	FechaInicio DATETIME NOT NULL,
	FechaUltimoPago DATETIME NOT NULL,
    Monto MONEY not null,
    FOREIGN KEY (LocalId) REFERENCES Locales(LocalesId),
    FOREIGN KEY (ArrendatarioId) REFERENCES Arrendatario(ArrendatarioId)
);
GO
CREATE TABLE Rol(
    RolId INT not null PRIMARY KEY IDENTITY(1,1),
	Nombre VARCHAR(50) NOT NULL
);
GO
CREATE TABLE Empleado(
    EmpleadoId INT not null PRIMARY KEY IDENTITY(1,1),
    RolId INT not null,
    EstadoId INT not null,
	Nombre VARCHAR(60)NOT NULL,
	Apellido VARCHAR(60)NOT NULL,
	Telefono VARCHAR(15) not null,
    DUI VARCHAR(10) not null,
    CorreoElectronico VARCHAR(255),
    FOREIGN KEY (RolId) REFERENCES Rol(RolId),
    FOREIGN KEY (EstadoId) REFERENCES Estado(EstadoId)
);
GO
CREATE TABLE Usuario(
    UsuarioId INT not null PRIMARY KEY IDENTITY(1,1),
    EmpleadoId INT not null,
	NombreUser VARCHAR(50) NOT NULL,
	Clave VARCHAR(50)NOT NULL
    FOREIGN KEY (EmpleadoId) REFERENCES Empleado(EmpleadoId)
);
GO
CREATE TABLE Arqueo(
    ArqueoId INT not null PRIMARY KEY IDENTITY(1,1),
    UsuarioId INT not null,
    CantidadDe1 INT not null,
    CantidadDe5 INT not null,
    CantidadDe10 INT not null,
    CantidadDe20 INT not null,
	CierreCaja MONEY NOT NULL,
	TotalApertura MONEY NOT NULL,
	FinalDia MONEY NOT NULL,
	TotalVentaDelDia MONEY NOT NULL,
	TotalSobrante MONEY NOT NULL,
	TotalFaltante MONEY NOT NULL,
	FechaArqueo DATETIME NOT NULL,
    FOREIGN KEY (UsuarioId) REFERENCES Usuario(UsuarioId)
);
GO
CREATE TABLE Cobro(
    CobroId INT not null PRIMARY KEY IDENTITY(1,1),
    EmpleadoId INT not null,
    LocalId INT not null,
	FechaCobro DATETIME NOT NULL,
    FOREIGN KEY (LocalId) REFERENCES Locales(LocalesId),
    FOREIGN KEY (EmpleadoId) REFERENCES Empleado(EmpleadoId)
);

