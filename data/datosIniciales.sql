USE [GD1C2014]

IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'MERCADONEGRO')
DROP SCHEMA [MERCADONEGRO]
GO

CREATE SCHEMA MERCADONEGRO AUTHORIZATION gd
GO


----------------------------------------------------Datos Iniciales-----------------------------------------------

PRINT 'Creando valores por defecto...'

-- ///// Agregar las que sean necesarias /////

INSERT INTO MERCADONEGRO.Funcionalidades (Nombre) VALUES ('AdministrarClientes');
INSERT INTO MERCADONEGRO.Funcionalidades (Nombre) VALUES ('AdministrarEmpresas');
INSERT INTO MERCADONEGRO.Funcionalidades (Nombre) VALUES ('AdministrarRoles');
INSERT INTO MERCADONEGRO.Funcionalidades (Nombre) VALUES ('AdministrarRubros');
INSERT INTO MERCADONEGRO.Funcionalidades (Nombre) VALUES ('AdministrarVisibilidades');
INSERT INTO MERCADONEGRO.Funcionalidades (Nombre) VALUES ('GenerarPublicacion');
INSERT INTO MERCADONEGRO.Funcionalidades (Nombre) VALUES ('EditarPublicacion');
INSERT INTO MERCADONEGRO.Funcionalidades (Nombre) VALUES ('GestionarPreguntas');
INSERT INTO MERCADONEGRO.Funcionalidades (Nombre) VALUES ('ComprarOfertar');
INSERT INTO MERCADONEGRO.Funcionalidades (Nombre) VALUES ('Calificar');
INSERT INTO MERCADONEGRO.Funcionalidades (Nombre) VALUES ('HistorialOperaciones');
INSERT INTO MERCADONEGRO.Funcionalidades (Nombre) VALUES ('Facturar');
INSERT INTO MERCADONEGRO.Funcionalidades (Nombre) VALUES ('ListadoEstadistico');


INSERT INTO MERCADONEGRO.Roles (Nombre, Habilitado) VALUES ('Administrador', 1);
INSERT INTO MERCADONEGRO.Roles (Nombre, Habilitado) VALUES ('Cliente', 1);
INSERT INTO MERCADONEGRO.Roles (Nombre, Habilitado) VALUES ('Empresa', 1);


PRINT 'Agregando func ADMIN'
-------------------/* Asignacion de Funcionalidades */-------------------
/* ADMIN */ 
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Administrador', @func = 'AdministrarRoles';
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Administrador', @func = 'AdministrarClientes';
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Administrador', @func = 'AdministrarEmpresas';	
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Administrador', @func = 'AdministrarRubros';
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Administrador', @func = 'AdministrarVisibilidades';
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Administrador', @func = 'GenerarPublicacion';
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Administrador', @func = 'EditarPublicacion';		
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Administrador', @func = 'GestionarPreguntas';
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Administrador', @func = 'ComprarOfertar';
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Administrador', @func = 'Calificar';
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Administrador', @func = 'HistorialOperaciones';	
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Administrador', @func = 'Facturar';		
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Administrador', @func = 'ListadoEstadistico';				
		
/* Cliente */
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Cliente', @func = 'GenerarPublicacion';		
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Cliente', @func = 'EditarPublicacion';		
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Cliente', @func = 'ComprarOfertar';		
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Cliente', @func = 'Calificar';
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Cliente', @func = 'HistorialOperaciones';
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Cliente', @func = 'Facturar';
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Cliente', @func = 'ListadoEstadistico';
		
/* Empresas */
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Empresa', @func = 'GenerarPublicacion';		
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Empresa', @func = 'EditarPublicacion';		
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Empresa', @func = 'ComprarOfertar';		
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Empresa', @func = 'Calificar';
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Empresa', @func = 'HistorialOperaciones';
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Empresa', @func = 'Facturar';
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Empresa', @func = 'ListadoEstadistico';
		
