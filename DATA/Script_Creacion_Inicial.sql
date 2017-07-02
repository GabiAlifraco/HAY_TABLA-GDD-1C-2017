USE [GD1C2017]
GO

/* ################################# CREACION DEL ESQUEMA ################################# */

CREATE SCHEMA [HAY_TABLA] AUTHORIZATION [gd]
GO

/* ############################## CREACION DE TABLAS MAESTRAS ############################## */

CREATE TABLE [HAY_TABLA].[Usuarios](
	Usu_Id 							INT NOT NULL IDENTITY(1,1),
	Usu_Username 					VARCHAR(30) NOT NULL,
	Usu_Password 					VARBINARY(8000) NOT NULL,
	Usu_IntentosFallidos 			TINYINT NOT NULL DEFAULT 0,
	CONSTRAINT PK_Usuarios 			PRIMARY KEY (Usu_Username)
);

CREATE TABLE [HAY_TABLA].Chofer (
    Cho_Id 							INT NOT NULL IDENTITY(1,1),
	Cho_Usuario 					VARCHAR(30), /*** FK **/
    Cho_Nombre 						VARCHAR(30) NOT NULL,
    Cho_Apellido 					VARCHAR(255),
	Cho_DNI 						NUMERIC(18, 0),
	Cho_Mail 						VARCHAR(50),
	Cho_Telefono 					NUMERIC(18, 0) UNIQUE,
	Cho_Direccion 					VARCHAR(255),
	Cho_FechaNacimiento 			DATETIME,
	CONSTRAINT PK_Chofer 			PRIMARY KEY (Cho_ID),
	FOREIGN KEY (Cho_Usuario) 		REFERENCES [HAY_TABLA].Usuarios(Usu_Username) ON UPDATE CASCADE
);

CREATE TABLE [HAY_TABLA].Cliente(
	Cli_Id 							INT NOT NULL IDENTITY(1,1),
	Cli_Usuario 					VARCHAR(30), /** FK **/
	Cli_Nombre 						VARCHAR(255),
	Cli_Apellido 					VARCHAR(255),
	Cli_DNI 						NUMERIC(18, 0),
	Cli_Mail 						VARCHAR(255),
	Cli_Telefono 					NUMERIC(18, 0) UNIQUE,
	Cli_Direccion 					VARCHAR(255),
	Cli_CodigoPostal				NUMERIC(10, 0),
	Cli_FechaNacimiento 			DATETIME,
	CONSTRAINT PK_Cliente 			PRIMARY KEY (Cli_Id),
	FOREIGN KEY (Cli_Usuario) 		REFERENCES [HAY_TABLA].Usuarios(Usu_Username) ON UPDATE CASCADE
);

CREATE TABLE [HAY_TABLA].Automovil(
	Auto_Id 						INT NOT NULL IDENTITY(1,1),
	Auto_Patente 					VARCHAR(10),
	Auto_Marca 						VARCHAR(20),
	Auto_Modelo 					VARCHAR(255),
	Auto_Licencia 					VARCHAR(26),
	Auto_Rodado 					VARCHAR(10),
	Auto_Habilitado				 	BIT DEFAULT '1',
	CONSTRAINT PK_Automovil 		PRIMARY KEY (Auto_Id),
	CONSTRAINT AK_AutoPatente 		UNIQUE(Auto_Patente)   
);

CREATE TABLE [HAY_TABLA].[Turno](
	Turno_Id 						INT NOT NULL IDENTITY(1,1),
	Turno_HoraInicio 				NUMERIC(18, 0),
	Turno_HoraFin 					NUMERIC(18, 0),
	Turno_Descripcion 				VARCHAR(255),
	Turno_ValorKM 					NUMERIC(18, 2),
	Turno_PrecioBase 				NUMERIC(18, 2),
	Turno_Habilitado 				BIT DEFAULT '1',
	CONSTRAINT PK_Turno 			PRIMARY KEY (Turno_Id)
);


CREATE TABLE [HAY_TABLA].AsignacionDeTurnos(
	Asignacion_Id 					INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Turno_Id 						INT NOT NULL,
	Cho_Id 							INT NOT NULL,
	Auto_Id 						INT NOT NULL,
	FOREIGN KEY (Turno_Id) 			REFERENCES [HAY_TABLA].Turno(Turno_Id),
	FOREIGN KEY (Cho_Id)   			REFERENCES [HAY_TABLA].Chofer(Cho_Id)
 );

CREATE TABLE [HAY_TABLA].[ROL] (
	[Id_Rol]						INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nombre]						VARCHAR(50) NOT NULL,
	[Habilitado]					BIT DEFAULT 1
);

CREATE TABLE [HAY_TABLA].[USUARIO_POR_ROL] (
	[Id_Rol]						INT NOT NULL REFERENCES [HAY_TABLA].[ROL](Id_Rol),
	[Nombre_Usuario]				VARCHAR(30) NOT NULL REFERENCES [HAY_TABLA].[Usuarios](Usu_Username),
	[Habilitado]					BIT DEFAULT 1,
	PRIMARY KEY (Id_Rol, Nombre_Usuario),
	FOREIGN KEY (Nombre_Usuario)  	REFERENCES [HAY_TABLA].Usuarios(Usu_Username) ON UPDATE CASCADE,
	FOREIGN KEY (Id_Rol)  			REFERENCES [HAY_TABLA].ROL(Id_Rol)
);

CREATE TABLE [HAY_TABLA].[FUNCIONALIDAD] (
	[Id_Funcionalidad]				INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Descripcion]					VARCHAR(255) NOT NULL	
);

CREATE TABLE [HAY_TABLA].[FUNCIONALIDAD_POR_ROL] (
	[Id_Funcionalidad]				INT NOT NULL,
	[Id_Rol]						INT NOT NULL,
	FOREIGN KEY (Id_Funcionalidad)  REFERENCES [HAY_TABLA].FUNCIONALIDAD(Id_Funcionalidad),
	FOREIGN KEY (Id_Rol)  			REFERENCES [HAY_TABLA].ROL(Id_Rol)
);

CREATE TABLE [HAY_TABLA].Viaje(
	Id_Viaje 						INT NOT NULL IDENTITY(1,1),
	Vi_IdChofer 					INT,
	Vi_IdCliente 					INT,
	Vi_AutoPatente 					VARCHAR(10),
	Vi_IdTurno 						INT, 
	Vi_CantKilometros 				NUMERIC(18, 0),
	Vi_Inicio 						DATETIME,
	Vi_Fin 							DATETIME,
	Rendicion_Nro 					NUMERIC(18,0),
	Factura_Nro 					NUMERIC(18,0),
	Vi_ImporteTotal 				NUMERIC(18, 2),
	CONSTRAINT PKViaje 				PRIMARY KEY (Id_Viaje),
	FOREIGN KEY (Vi_IdChofer) 		REFERENCES [HAY_TABLA].Chofer(Cho_Id),
	FOREIGN KEY (Vi_IdCliente)		REFERENCES [HAY_TABLA].Cliente(Cli_Id),
	FOREIGN KEY (Vi_AutoPatente) 	REFERENCES [HAY_TABLA].Automovil(Auto_Patente) ON UPDATE CASCADE,
	FOREIGN KEY (Vi_IdTurno) 		REFERENCES [HAY_TABLA].Turno(Turno_Id)
);

CREATE TABLE [HAY_TABLA].Rendicion(
	Rendicion_Nro 					NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
	Cho_Id 							INT NOT NULL,
	Turno_Id 						INT NOT NULL,
	Rendicion_Fecha 				DATETIME DEFAULT GETDATE() NOT NULL,
	Rendicion_Total 				NUMERIC(18,2) NOT NULL,
	PorcentajeDePago 				NUMERIC(4,2) NOT NULL,
	CONSTRAINT PKRendicion			PRIMARY KEY (Rendicion_Nro),
	FOREIGN KEY (Turno_Id) 			REFERENCES [HAY_TABLA].Turno(Turno_Id),
	FOREIGN KEY (Cho_Id)   			REFERENCES [HAY_TABLA].Chofer(Cho_Id)
);

CREATE TABLE [HAY_TABLA].Factura(
	Factura_Nro 					NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
	Factura_Fecha_Inicio 			DATETIME NOT NULL,
	Factura_Fecha_Fin 				DATETIME NOT NULL,
	Cli_Id 							INT NOT NULL,
	Factura_Total 					NUMERIC(18,2) NOT NULL,
	FOREIGN KEY (Cli_Id)   			REFERENCES [HAY_TABLA].Cliente(Cli_Id)
);

/* ############################## INSERTS A TABLAS MAESTRAS ############################## */

/* INSERTS A USUARIOS */

INSERT INTO [HAY_TABLA].[Usuarios] (Usu_Username,Usu_Password)
VALUES ('admin', HASHBYTES('SHA2_256', 'w23e'))

INSERT INTO [HAY_TABLA].[Usuarios] (Usu_Username,Usu_Password)
SELECT DISTINCT [Chofer_Dni],HASHBYTES('SHA2_256',CAST(Chofer_Dni AS VARCHAR(30) ))
FROM [gd_esquema].[Maestra] 
UNION
SELECT DISTINCT [Cliente_Dni],HASHBYTES('SHA2_256',CAST(Cliente_Dni AS VARCHAR(30) ))
FROM [gd_esquema].[Maestra] 
WHERE Chofer_Dni IS NOT NULL AND Cliente_Dni IS NOT NULL
ORDER BY 1

/* INSERTS A CHOFERES */

INSERT INTO [HAY_TABLA].Chofer (Cho_Usuario,Cho_Nombre,Cho_Apellido,Cho_DNI,Cho_Mail,Cho_Telefono,Cho_Direccion,Cho_FechaNacimiento)
SELECT DISTINCT
	   CAST(Chofer_Dni AS VARCHAR(30))
	  ,Chofer_Nombre
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
      ,Chofer_Direccion
      ,Chofer_Telefono
      ,Chofer_Mail
      ,Chofer_Fecha_Nac

/* INSERTS A CLIENTES */	  

INSERT INTO [HAY_TABLA].Cliente (Cli_Usuario,Cli_Nombre, Cli_Apellido, Cli_DNI, Cli_Telefono, Cli_Direccion, Cli_Mail, Cli_FechaNacimiento)
SELECT DISTINCT 
	   CAST(Cliente_Dni AS VARCHAR(30))
	  ,Cliente_Nombre
      ,Cliente_Apellido
      ,Cliente_Dni
	  ,Cliente_Telefono
	  ,Cliente_Direccion
	  ,Cliente_Mail
	  ,Cliente_Fecha_Nac
      FROM gd_esquema.Maestra
ORDER BY
	   Cliente_Nombre
      ,Cliente_Apellido
	  ,Cliente_Telefono
	  ,Cliente_Direccion
	  ,Cliente_Mail
	  ,Cliente_Fecha_Nac

/* INSERTS A AUTOMOVILES */	

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

/* INSERTS A TURNOS */	

INSERT INTO [HAY_TABLA].Turno (Turno_HoraInicio, Turno_HoraFin, Turno_Descripcion, Turno_ValorKM, Turno_PrecioBase)
SELECT DISTINCT 
      Turno_Hora_Inicio * 100,
	  Turno_Hora_Fin * 100,
	  Turno_Descripcion,
	  Turno_Valor_Kilometro,
	  Turno_Precio_Base
FROM gd_esquema.Maestra;

/* INSERTS A ROL */	

INSERT INTO [HAY_TABLA].[ROL] (Nombre)
VALUES ('Administrador'), ('Cliente'), ('Chofer')

/* INSERTS A USUARIO POR ROL */	

INSERT INTO [HAY_TABLA].[USUARIO_POR_ROL] (Id_Rol, Nombre_Usuario)
VALUES (1, 'admin'), (2, 'admin'), (3, 'admin')

INSERT INTO [HAY_TABLA].[USUARIO_POR_ROL]
        ([Id_Rol]
        ,[Nombre_Usuario])
SELECT  2, Cli.Cli_Usuario FROM [HAY_TABLA].[Cliente] AS Cli

INSERT INTO [HAY_TABLA].[USUARIO_POR_ROL]
        ([Id_Rol]
        ,[Nombre_Usuario])
SELECT  3,Ch.Cho_Usuario FROM [HAY_TABLA].[Chofer] AS Ch

/* INSERTS A FUNCIONALIDAD */	

INSERT INTO [HAY_TABLA].[FUNCIONALIDAD] (Descripcion)
VALUES  ('ABM de Rol'), ('ABM de Cliente'), ('ABM de Automóvil'),
		('ABM de Chofer'), ('Registro de Viajes'), ('Rendición de cuenta del chofer'),
		('Facturación a Cliente'), ('Listado Estadístico'), ('Ver Viajes'),
		('Ver Redenciones'), ('Ver Facturación'), ('Abm Turno') 
		
/* INSERTS A FUNCIONALIDAD POR ROL */	
		
INSERT INTO [HAY_TABLA].[FUNCIONALIDAD_POR_ROL] (Id_Funcionalidad, Id_Rol)
VALUES (1,1),(2,1),(3,1),(4,1),(5,1),(6,1),(7,1),(8,1),(9,2),(9,3),(10,3),(11,2),(12,1)

/* INSERTS A ASIGNACION DE TURNOS */	

INSERT INTO [HAY_TABLA].AsignacionDeTurnos(Turno_Id,Cho_Id, Auto_Id)
SELECT Turno.Turno_Id turno_id, Chofer.[Cho_Id] chofer_id, Automovil.[Auto_Id] auto_id
FROM [HAY_TABLA].[Chofer] chofer
INNER JOIN gd_esquema.Maestra maestra ON chofer.Cho_DNI = maestra.Chofer_Dni
INNER JOIN [HAY_TABLA].[Turno] turno ON turno.[Turno_Descripcion] = maestra.Turno_Descripcion
INNER JOIN [HAY_TABLA].[Automovil] automovil ON automovil.[Auto_Patente] = maestra.Auto_Patente
GROUP BY   maestra.Chofer_Dni,  maestra.Auto_Patente, maestra.Turno_Descripcion, turno.[Turno_Id], chofer.[Cho_Id], automovil.[Auto_Id]

/* INSERTS A VIAJES */	

INSERT INTO [HAY_TABLA].Viaje (Vi_IdChofer, Vi_IdCliente,Vi_AutoPatente, Vi_IdTurno,Vi_CantKilometros,Vi_Inicio,Vi_Fin,Rendicion_Nro,Factura_Nro,Vi_ImporteTotal)
  SELECT 
	Chofer.Cho_Id,
	Cliente.Cli_Id,
	m1.Auto_Patente,
	Turno.Turno_Id,
	m1.Viaje_Cant_Kilometros,
	m1.Viaje_Fecha as Inicio,/*INICIO*/
	m1.Viaje_Fecha as Fin,
	Rendicion_Nro,
	Factura_Nro = (SELECT TOP 1 Factura_Nro FROM gd_esquema.Maestra g2 WHERE m1.Cliente_Dni = g2.Cliente_Dni AND Factura_Nro IS NOT NULL AND m1.Viaje_Fecha = g2.Viaje_Fecha),
	(m1.Turno_Precio_Base + m1.Turno_Valor_Kilometro * m1.Viaje_Cant_Kilometros) AS IMPORTE
FROM [gd_esquema].[Maestra] m1
INNER JOIN Hay_TABLA.Chofer ON Chofer.Cho_DNI = m1.Chofer_Dni
INNER JOIN Hay_TABLA.Cliente ON Cliente.Cli_DNI = m1.Cliente_Dni
INNER JOIN Hay_TABLA.Turno ON Turno.Turno_Descripcion = m1.Turno_Descripcion
WHERE Rendicion_Nro IS NOT NULL
GROUP BY 
	Chofer.Cho_Id,
	Cliente.Cli_Id,
	m1.Cliente_Dni,
	m1.Chofer_Dni,
	m1.Auto_Patente,
	m1.Viaje_Cant_Kilometros,
	m1.Viaje_Fecha,
	m1.Turno_Precio_Base,
	m1.Turno_Valor_Kilometro,
	Turno.Turno_Id,
	Rendicion_Nro
	
/* INSERTS A RENDICION */	
	
SET IDENTITY_INSERT HAY_TABLA.Rendicion ON
INSERT INTO HAY_TABLA.Rendicion(Rendicion_Nro, Cho_Id, Turno_Id, Rendicion_Fecha, Rendicion_Total,PorcentajeDePago)
SELECT DISTINCT(Rendicion_Nro), Cho_Id, Turno_Id, Rendicion_Fecha,SUM(Rendicion_Importe),30 
FROM gd_esquema.Maestra
INNER JOIN [HAY_TABLA].[Chofer] chofer ON chofer.Cho_DNI = maestra.Chofer_Dni
INNER JOIN [HAY_TABLA].[Turno] turno ON turno.Turno_Descripcion = maestra.Turno_Descripcion
WHERE Rendicion_Nro IS NOT NULL
GROUP BY Rendicion_Nro, Cho_Id, Turno_Id, Rendicion_Fecha
order by 1
SET IDENTITY_INSERT HAY_TABLA.Rendicion OFF

/* INSERTS A FACTURA */	

SET IDENTITY_INSERT [HAY_TABLA].Factura ON
INSERT INTO [HAY_TABLA].Factura (Factura_Nro, Factura_Fecha_Inicio, Factura_Fecha_Fin, Cli_Id, Factura_Total)
SELECT DISTINCT(Factura_Nro), Factura_Fecha_Inicio, Factura_Fecha_Fin, c.Cli_Id, 
factura_total = CONVERT(numeric(18,2),
(SELECT SUM(Turno_Precio_Base + (Turno_Valor_Kilometro*Viaje_Cant_Kilometros)) FROM gd_esquema.Maestra 
WHERE Cliente_Dni = CONVERT(nvarchar(30), g.Cliente_Dni) AND Rendicion_Nro IS NOT NULL
AND Viaje_Fecha BETWEEN g.Factura_Fecha_Inicio AND DATEADD(Hour, 23, g.Factura_Fecha_Fin)))
FROM gd_esquema.Maestra g
INNER JOIN [HAY_TABLA].[Cliente] c ON c.Cli_DNI = g.Cliente_Dni
WHERE Factura_Nro IS NOT NULL
GROUP BY Factura_Nro, Factura_Fecha_Inicio, Factura_Fecha_Fin, c.Cli_Id, Cliente_Dni
ORDER BY Factura_Nro
SET IDENTITY_INSERT [HAY_TABLA].Factura OFF
GO

/* ############################## PROCEDURES ############################## */	

CREATE PROCEDURE [HAY_TABLA].bajaLogica @table varchar(20), @id int AS
BEGIN
	IF(@table =  'ROL' ) BEGIN 
		UPDATE [HAY_TABLA].[ROL] SET Habilitado = 0 WHERE Id_Rol = @id 
	END 
	IF(@table =  'TURNO') BEGIN
		UPDATE [HAY_TABLA].[TURNO] SET Turno_Habilitado = 0 WHERE Turno_Id = @id
	END
	IF( @table =  'Automovil') BEGIN
		UPDATE [HAY_TABLA].[Automovil] SET Auto_Habilitado = 0 WHERE Auto_Id = @id
	END
END

GO

CREATE PROCEDURE [HAY_TABLA].altaLogica @table varchar(20), @id int AS
BEGIN
	IF(@table =  'ROL' ) BEGIN 
		UPDATE [HAY_TABLA].[ROL] SET Habilitado = 1 WHERE Id_Rol = @id 
	END 
	IF(@table =  'TURNO') BEGIN
		UPDATE [HAY_TABLA].[TURNO] SET Turno_Habilitado = 1 WHERE Turno_Id = @id
	END
	IF( @table =  'Automovil') BEGIN
		UPDATE [HAY_TABLA].[Automovil] SET Auto_Habilitado = 1 WHERE Auto_Id = @id
	END
END
GO

CREATE PROCEDURE [HAY_TABLA].bajaLogicaRolDelUsuario @Id_Rol int, @nombre_usuario VARCHAR(30) AS
BEGIN
	UPDATE [HAY_TABLA].[USUARIO_POR_ROL] SET Habilitado = 0 WHERE Id_Rol = @Id_Rol AND Nombre_Usuario = @nombre_usuario
END
GO

CREATE PROCEDURE [HAY_TABLA].altaLogicaRolDelUsuario @Id_Rol int, @nombre_usuario VARCHAR(30) AS
BEGIN
	UPDATE [HAY_TABLA].[USUARIO_POR_ROL] SET Habilitado = 1 WHERE Id_Rol = @Id_Rol AND Nombre_Usuario = @nombre_usuario
END	
GO

CREATE PROCEDURE [HAY_TABLA].bajaLogicaAutomovil @Id_Automovil int AS
BEGIN
	UPDATE [HAY_TABLA].[Automovil] SET Auto_Habilitado = 0 WHERE Auto_Id = @Id_Automovil
END
GO

CREATE PROCEDURE [HAY_TABLA].altaLogicaAutomovil @Id_Automovil int AS
BEGIN
	UPDATE [HAY_TABLA].[Automovil] SET Auto_Habilitado = 1 WHERE Auto_Id = @Id_Automovil
END
GO

CREATE PROCEDURE [HAY_TABLA].bajaLogicaRol @Id_Rol int AS
BEGIN
	UPDATE [HAY_TABLA].[ROL] SET Habilitado = 0 WHERE Id_Rol = @Id_Rol
END
GO

CREATE PROCEDURE [HAY_TABLA].altaLogicaRol @Id_Rol int AS
BEGIN
	UPDATE [HAY_TABLA].[ROL] SET Habilitado = 1 WHERE Id_Rol = @Id_Rol
END
GO

/* ############################## TRIGGERS ############################## */	

CREATE TRIGGER crearUsuarioAlCliente ON [HAY_TABLA].Cliente FOR INSERT AS
BEGIN
	DECLARE @username numeric(18,0)
	DECLARE @password varbinary(8000)

	DECLARE insert_cursor CURSOR FOR SELECT Cli_DNI FROM inserted
	OPEN insert_cursor

	FETCH NEXT FROM insert_cursor INTO @username
	WHILE @@FETCH_STATUS = 0 BEGIN
		INSERT INTO [HAY_TABLA].Usuarios (Usu_Username, Usu_Password) VALUES(CAST(@username AS VARCHAR(30)), HASHBYTES('SHA2_256',CAST(@username AS VARCHAR(30))))
		INSERT INTO [HAY_TABLA].USUARIO_POR_ROL (Nombre_Usuario, Id_Rol) VALUES(CAST(@username AS VARCHAR(30)), 2)
		UPDATE [HAY_TABLA].Cliente SET Cli_Usuario = CAST(@username AS VARCHAR(30)) WHERE Cli_DNI = @username
		FETCH NEXT FROM insert_cursor INTO @username
	END

	CLOSE insert_cursor
	DEALLOCATE insert_cursor

END
GO

CREATE TRIGGER crearUsuarioAlChofer ON [HAY_TABLA].Chofer FOR INSERT AS
BEGIN
	DECLARE @username numeric(18,0)
	DECLARE @password varbinary(8000)

	DECLARE insert_cursor CURSOR FOR SELECT Cho_DNI FROM inserted
	OPEN insert_cursor

	FETCH NEXT FROM insert_cursor INTO @username
	WHILE @@FETCH_STATUS = 0 BEGIN
		INSERT INTO [HAY_TABLA].Usuarios (Usu_Username, Usu_Password) VALUES(CAST(@username AS VARCHAR(30)), HASHBYTES('SHA2_256',CAST(@username AS VARCHAR(30))))
		INSERT INTO [HAY_TABLA].USUARIO_POR_ROL (Nombre_Usuario, Id_Rol) VALUES(CAST(@username AS VARCHAR(30)), 3)
		UPDATE [HAY_TABLA].Chofer SET Cho_Usuario = CAST(@username AS VARCHAR(30)) WHERE Cho_DNI = @username
		FETCH NEXT FROM insert_cursor INTO @username
	END

	CLOSE insert_cursor
	DEALLOCATE insert_cursor

END
GO
