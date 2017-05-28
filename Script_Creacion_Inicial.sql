USE [GD1C2017]
GO

/* CREACION DEL ESQUEMA */

CREATE SCHEMA [HAY_TABLA] AUTHORIZATION [gd]
GO

/* CREACION DE TABLAS MAESTRAS (ABM) */

CREATE TABLE [HAY_TABLA].[Usuarios](
	Usu_Id int NOT NULL IDENTITY(1,1),
	Usu_Username VARCHAR(30) NOT NULL,
	Usu_Password VARBINARY(8000) NOT NULL,
	Usu_IntentosFallidos TINYINT NOT NULL DEFAULT 0
	CONSTRAINT PK_Usuarios PRIMARY KEY (Usu_Id)
);

INSERT INTO [HAY_TABLA].[Usuarios] (Usu_Username,Usu_Password)
VALUES ('admin', HASHBYTES('SHA2_256', 'w23e'))

/*EJECUTAR DE ACA PARA ABAJO*/

/*CHOFER************************************************/
--DROP TABLE [HAY_TABLA].Chofer
CREATE TABLE [HAY_TABLA].Chofer (
    Cho_Id int NOT NULL IDENTITY(1,1),
	Cho_IdUsuario int, /*** FK **/
    Cho_Nombre VARCHAR(30) NOT NULL,
    Cho_Apellido varchar(255),
	Cho_DNI numeric(18, 0),
	Cho_Mail varchar(50),
	Cho_Telefono numeric(18, 0),
	Cho_Direccion varchar(255),
	Cho_FechaNacimiento datetime,
	CONSTRAINT PK_Chofer PRIMARY KEY (Cho_ID),
	FOREIGN KEY (Cho_IdUsuario) REFERENCES [HAY_TABLA].Usuarios(Usu_Id)
);
INSERT INTO [HAY_TABLA].Chofer (Cho_Nombre,Cho_Apellido,Cho_DNI,Cho_Mail,Cho_Telefono,Cho_Direccion,Cho_FechaNacimiento)
SELECT DISTINCT   
	   Chofer_Nombre
      ,Chofer_Apellido
      ,Chofer_Dni
      ,Chofer_Mail
      ,Chofer_Telefono
	  ,Chofer_Direccion
      ,Chofer_Fecha_Nac
FROM gd_esquema.Maestra
ORDER BY 
	   Chofer_Nombre
      ,Chofer_Apellido
      ,Chofer_Dni
      ,Chofer_Direccion
      ,Chofer_Telefono
      ,Chofer_Mail
      ,Chofer_Fecha_Nac

/*CLIENTE************************************************/
--DROP TABLE [HAY_TABLA].Cliente
CREATE TABLE [HAY_TABLA].Cliente(
	Cli_Id int NOT NULL IDENTITY(1,1),
	Cli_IdUsuario int, /** FK **/
	Cli_Nombre varchar(255),
	Cli_Apellido varchar(255),
	Cli_DNI numeric(18, 0),
	Cli_Mail varchar(255),
	Cli_Telefono numeric(18, 0),
	Cli_Direccion varchar(255),
	Cli_CodigoPostal numeric(10, 0),
	Cli_FechaNacimiento datetime
	CONSTRAINT PK_Cliente PRIMARY KEY (Cli_Id),
	FOREIGN KEY (Cli_IdUsuario) REFERENCES [HAY_TABLA].Usuarios(Usu_Id)
);
INSERT INTO [HAY_TABLA].Cliente (Cli_Nombre, Cli_Apellido, Cli_DNI, Cli_Telefono, Cli_Direccion, Cli_Mail, Cli_FechaNacimiento)
SELECT  
	   Cliente_Nombre
      ,Cliente_Apellido
      ,Cliente_Dni
	  ,Cliente_Telefono
	  ,Cliente_Direccion
	  ,Cliente_Mail
	  ,Cliente_Fecha_Nac
      FROM gd_esquema.Maestra
GROUP BY
	   Cliente_Nombre
      ,Cliente_Apellido
      ,Cliente_Dni
	  ,Cliente_Telefono
	  ,Cliente_Direccion
	  ,Cliente_Mail
	  ,Cliente_Fecha_Nac

/*AUTOMOVIL************************************************/
--DROP TABLE [HAY_TABLA].Automovil
CREATE TABLE [HAY_TABLA].Automovil(
	Auto_Id int NOT NULL IDENTITY(1,1),
	Auto_Patente varchar(10),
	Auto_Marca varchar(255),
	Auto_Modelo varchar(255),
	Auto_Licencia varchar(26),
	Auto_Rodado varchar(10),
	CONSTRAINT PK_Automovil PRIMARY KEY (Auto_Id)
);

INSERT INTO [HAY_TABLA].Automovil (Auto_Marca
      ,Auto_Modelo
      ,Auto_Patente
      ,Auto_Licencia
      ,Auto_Rodado)
SELECT Auto_Marca
      ,Auto_Modelo
      ,Auto_Patente
      ,Auto_Licencia
      ,Auto_Rodado
  FROM gd_esquema.Maestra
  GROUP BY [Auto_Marca]
      ,[Auto_Modelo]
      ,[Auto_Patente]
      ,[Auto_Licencia]
      ,[Auto_Rodado]

/*TURNO************************************************/
--DROP TABLE [HAY_TABLA].Turno
CREATE TABLE [HAY_TABLA].[Turno](
	Turno_Id int NOT NULL IDENTITY(1,1),
	Turno_HoraInicio numeric(18, 0),
	Turno_HoraFin numeric(18, 0),
	Turno_Descripcion varchar(255),
	Turno_ValorKM numeric(18, 2),
	Turno_PrecioBase numeric(18, 2),
	Turno_Habilitado BIT DEFAULT '1',
	CONSTRAINT PK_Turno PRIMARY KEY (Turno_Id)
)

INSERT INTO [HAY_TABLA].Turno (Turno_HoraInicio, Turno_HoraFin, Turno_Descripcion, Turno_ValorKM, Turno_PrecioBase)
SELECT DISTINCT 
      Turno_Hora_Inicio,
	  Turno_Hora_Fin,
	  Turno_Descripcion,
	  Turno_Valor_Kilometro,
	  Turno_Precio_Base
FROM gd_esquema.Maestra;

/*ASIGNACION DE TURNOS************************************************/
--DROP TABLE [HAY_TABLA].AsignacionDeTurnos
CREATE TABLE [HAY_TABLA].AsignacionDeTurnos(
	Turno_Id int NOT NULL,
	Cho_Id int NOT NULL,
	Auto_Id int NOT NULL,
PRIMARY KEY CLUSTERED 
(
	Turno_Id ASC,
	Cho_Id ASC
))

CREATE TABLE [HAY_TABLA].[ROL] (
	[Id_Rol]						INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nombre]					VARCHAR(50) NOT NULL,
	[Habilitado]				BIT DEFAULT 1
)
GO

INSERT INTO [HAY_TABLA].[ROL] (Nombre)
	VALUES ('Administrador'), ('Cliente'), ('Chofer')

CREATE TABLE [HAY_TABLA].[USUARIO_POR_ROL] (
	[Id_Rol]					INT NOT NULL REFERENCES [HAY_TABLA].[ROL](Id_Rol),
	[Usu_Id]					INT NOT NULL REFERENCES [HAY_TABLA].[Usuarios](Usu_Id),
	[Habilitado]				BIT DEFAULT 1
)
GO

INSERT INTO [HAY_TABLA].[USUARIO_POR_ROL] (Id_Rol, Usu_Id)
	VALUES (1, 1), (2, 1), (3, 1)

CREATE TABLE [HAY_TABLA].[FUNCIONALIDAD] (
	[Id_Funcionalidad]			INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Descripcion]				VARCHAR(255) NOT NULL	
)
GO

INSERT INTO [HAY_TABLA].[FUNCIONALIDAD] (Descripcion)
	VALUES ('ABM de Rol'), ('Registro de Usuario'), ('ABM de Cliente'), ('ABM de Automóvil'),
		('ABM de Chofer'), ('Registro de Viajes'), ('Rendición de cuenta del chofer'), ('Facturación a Cliente'), ('Listado Estadístico')

CREATE TABLE [HAY_TABLA].[FUNCIONALIDAD_POR_ROL] (
	[Id_Funcionalidad]			INT NOT NULL REFERENCES [HAY_TABLA].[FUNCIONALIDAD](Id_Funcionalidad),
	[Id_Rol]					INT NOT NULL REFERENCES [HAY_TABLA].[ROL](Id_Rol)
)
GO

INSERT INTO [HAY_TABLA].[FUNCIONALIDAD_POR_ROL] (Id_Funcionalidad, Id_Rol)
	VALUES (1, 1),(2, 1),(3,1), (4,1),(5,1),(6,1),(7,1),(8,1),(9,1)
		   --,(1, 2), (5, 2), (9, 2),
		   --(9, 3), (11, 3), (12, 3)

/*
INSERT INTO [HAY_TABLA].AsignacionDeTurnos(Turno_Id,Cho_Id, Auto_Id)
SELECT [HAY_TABLA].[Turno].[Turno_Id], [HAY_TABLA].[Chofer].[Cho_Id], [HAY_TABLA].[Automovil].[Auto_Id]
FROM [HAY_TABLA].[Chofer]
INNER JOIN gd_esquema.Maestra ON HAY_TABLA.Chofer.Cho_DNI = gd_esquema.Maestra.Chofer_Dni
INNER JOIN Turno ON [HAY_TABLA].[Turno].[Turno_Descripcion] = gd_esquema.Maestra.Turno_Descripcion
INNER JOIN Automovil ON [HAY_TABLA].[Automovil].[Auto_Patente] = gd_esquema.Maestra.Auto_Patente
GROUP BY   gd_esquema.Maestra.Chofer_Dni,  gd_esquema.Maestra.Auto_Patente, gd_esquema.Maestra.Turno_Descripcion, [HAY_TABLA].[Turno].[Turno_Id], [HAY_TABLA].[Chofer].[Cho_Id], [HAY_TABLA].[Automovil].[Auto_Id]
*/
