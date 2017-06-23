USE [GD1C2017]
GO

BEGIN TRAN

/*******************************************
***** ELIMINAR TABLAS ***************** 
********************************************/


DROP TABLE [HAY_TABLA].USUARIO_POR_ROL
DROP TABLE [HAY_TABLA].FUNCIONALIDAD_POR_ROL
DROP TABLE [HAY_TABLA].ROL
DROP TABLE [HAY_TABLA].FUNCIONALIDAD
DROP TABLE [HAY_TABLA].Viaje
DROP TABLE [HAY_TABLA].AsignacionDeTurnos
DROP TABLE [HAY_TABLA].Automovil
DROP TABLE [HAY_TABLA].Chofer
DROP TABLE [HAY_TABLA].Cliente
DROP TABLE [HAY_TABLA].Turno
DROP TABLE [HAY_TABLA].Usuarios
/*******************************************
***** ELIMINAR ESQUEMA ***************** 
********************************************/

DROP SCHEMA [HAY_TABLA]

COMMIT TRAN