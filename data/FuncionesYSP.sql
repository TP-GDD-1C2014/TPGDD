USE [GD1C2014]

IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'MERCADONEGRO')
DROP SCHEMA [MERCADONEGRO]
GO

CREATE SCHEMA MERCADONEGRO AUTHORIZATION gd
GO

-----------------------------------------------Funciones Y Stored Procedures------------------------------------------------

/* FUNCION AGREGAR FUNCIONALIDAD X ROL*/

CREATE PROCEDURE MERCADONEGRO.AgregarFuncionalidad(@rol nvarchar(255), @func nvarchar(255)) AS
BEGIN
	INSERT INTO MERCADONEGRO.Funcionalidad_Rol (ID_Rol, ID_Funcionalidad)
		VALUES ((SELECT ID_Rol FROM MERCADONEGRO.Roles WHERE Nombre = @rol),
		        (SELECT ID_Funcionalidad FROM MERCADONEGRO.Funcionalidades WHERE Nombre = @func))
END
GO