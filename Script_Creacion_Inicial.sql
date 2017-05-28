CREATE TABLE Usuarios(
	Usu_Id int NOT NULL IDENTITY(1,1),
	Usu_Username varchar(50),
	Usu_Password varchar(50), /**VER TIPO DE DATO**/
	Usu_IntentosFallidos tinyint,
	CONSTRAINT PK_Usuarios PRIMARY KEY (Usu_Id)

);

/*EJECUTAR DE ACA PARA ABAJO*/

/*CHOFER************************************************/
DROP TABLE Chofer
CREATE TABLE Chofer (
    Cho_Id int NOT NULL IDENTITY(1,1),
	Cho_IdUsuario int, /*** FK **/
    Cho_Nombre varchar(255),
    Cho_Apellido varchar(255),
	Cho_DNI numeric(18, 0),
	Cho_Mail varchar(50),
	Cho_Telefono numeric(18, 0),
	Cho_Direccion varchar(255),
	Cho_FechaNacimiento datetime,
	CONSTRAINT PK_Chofer PRIMARY KEY (Cho_ID),
	FOREIGN KEY (Cho_IdUsuario) REFERENCES Usuarios(Usu_Id)
);
INSERT INTO Chofer (Cho_Nombre,Cho_Apellido,Cho_DNI,Cho_Mail,Cho_Telefono,Cho_Direccion,Cho_FechaNacimiento)
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
DROP TABLE Cliente
CREATE TABLE Cliente(
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
	FOREIGN KEY (Cli_IdUsuario) REFERENCES Usuarios(Usu_Id)
);
INSERT INTO Cliente (Cli_Nombre, Cli_Apellido, Cli_DNI, Cli_Telefono, Cli_Direccion, Cli_Mail, Cli_FechaNacimiento)
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
DROP TABLE Automovil
CREATE TABLE Automovil(
	Auto_Id int NOT NULL IDENTITY(1,1),
	Auto_Patente varchar(10),
	Auto_Marca varchar(255),
	Auto_Modelo varchar(255),
	Auto_Licencia varchar(26),
	Auto_Rodado varchar(10),
	CONSTRAINT PK_Automovil PRIMARY KEY (Auto_Id)
);

INSERT INTO Automovil (Auto_Marca
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
DROP TABLE Turno
CREATE TABLE Turno(
	Turno_Id int NOT NULL IDENTITY(1,1),
	Turno_HoraInicio numeric(18, 0),
	Turno_HoraFin numeric(18, 0),
	Turno_Descripcion varchar(255),
	Turno_ValorKM numeric(18, 2),
	Turno_PrecioBase numeric(18, 2),
	Turno_Habilitado BIT DEFAULT '1',
	CONSTRAINT PK_Turno PRIMARY KEY (Turno_Id)
)

INSERT INTO Turno (Turno_HoraInicio, Turno_HoraFin, Turno_Descripcion, Turno_ValorKM, Turno_PrecioBase)
SELECT DISTINCT 
      Turno_Hora_Inicio,
	  Turno_Hora_Fin,
	  Turno_Descripcion,
	  Turno_Valor_Kilometro,
	  Turno_Precio_Base
FROM gd_esquema.Maestra;

/*ASIGNACION DE TURNOS************************************************/
DROP TABLE AsignacionDeTurnos
CREATE TABLE AsignacionDeTurnos(
	Turno_Id int NOT NULL,
	Cho_Id int NOT NULL,
	Auto_Id int NOT NULL,
PRIMARY KEY CLUSTERED 
(
	Turno_Id ASC,
	Cho_Id ASC
))

INSERT INTO AsignacionDeTurnos (Turno_Id,Cho_Id, Auto_Id)
SELECT Turno.Turno_Id, Chofer.Cho_Id, Automovil.Auto_Id
FROM Chofer
INNER JOIN gd_esquema.Maestra ON Chofer.Cho_DNI = gd_esquema.Maestra.Chofer_Dni
INNER JOIN Turno ON Turno.Turno_Descripcion = gd_esquema.Maestra.Turno_Descripcion
INNER JOIN Automovil ON Automovil.Auto_Patente = gd_esquema.Maestra.Auto_Patente
GROUP BY   gd_esquema.Maestra.Chofer_Dni,  gd_esquema.Maestra.Auto_Patente, gd_esquema.Maestra.Turno_Descripcion, Turno.Turno_Id, Chofer.Cho_Id, Automovil.Auto_Id

