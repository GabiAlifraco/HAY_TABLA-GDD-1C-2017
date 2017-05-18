/*HAY_TABLA-GDD-1C-2017*/
CREATE TABLE Usuarios(
	Usu_Id int NOT NULL IDENTITY(1,1),
	Usu_Username varchar(50),
	Usu_Password varchar(50), /**VER TIPO DE DATO**/
	Usu_IntentosFallidos tinyint,
	CONSTRAINT PK_Usuarios PRIMARY KEY (Usu_Id)

);

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

CREATE TABLE Automovil(
	Auto_Id int NOT NULL IDENTITY(1,1),
	Auto_Patente varchar(10),
	Auto_Marca varchar(255),
	Auto_Modelo varchar(255),
	Auto_Licencia varchar(26),
	Auto_Rodado varchar(10),
	CONSTRAINT PK_Automovil PRIMARY KEY (Auto_Id)
);

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