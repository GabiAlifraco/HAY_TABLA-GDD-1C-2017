USE [GD1C2017]
GO

BEGIN TRAN

/*******************************************
***** ELIMINAR TABLAS ***************** 
********************************************/


DROP TABLE [HAY_TABLA].USUARIO_POR_ROL
DROP TABLE [HAY_TABLA].Rendicion
DROP TABLE [HAY_TABLA].Factura
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
DROP TABLE [HAY_TABLA].Detalle_Viaje_Rendicion
DROP TABLE [HAY_TABLA].Detalle_Viaje_Facturacion

DROP PROCEDURE [HAY_TABLA].[bajaLogica]
DROP PROCEDURE [HAY_TABLA].bajaLogicaRolDelUsuario
DROP PROCEDURE [HAY_TABLA].[altaLogica]
DROP PROCEDURE [HAY_TABLA].altaLogicaRolDelUsuario
DROP PROCEDURE [HAY_TABLA].bajaLogicaAutomovil
DROP PROCEDURE [HAY_TABLA].altaLogicaAutomovil
DROP PROCEDURE [HAY_TABLA].bajaLogicaRol
DROP PROCEDURE [HAY_TABLA].altaLogicaRol
--DROP TRIGGER [HAY_TABLA].crearUsuarioAlCliente
--DROP TRIGGER [HAY_TABLA].crearUsuarioAlChofer

/*******************************************
***** ELIMINAR ESQUEMA ***************** 
********************************************/

DROP SCHEMA [HAY_TABLA]

COMMIT TRAN