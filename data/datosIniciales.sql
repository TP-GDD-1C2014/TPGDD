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


INSERT INTO MERCADONEGRO.Roles (Nombre, Habilitado) VALUES ('Administrador General', 1);
INSERT INTO MERCADONEGRO.Roles (Nombre, Habilitado) VALUES ('Cliente', 1);
INSERT INTO MERCADONEGRO.Roles (Nombre, Habilitado) VALUES ('Empresa', 1);


PRINT 'Agregando func ADMIN'
-------------------/* Asignacion de Funcionalidades */-------------------
/* ADMIN */ 
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Administrador General', @func = 'AdministrarRoles';
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Administrador General', @func = 'AdministrarClientes';
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Administrador General', @func = 'AdministrarEmpresas';	
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Administrador General', @func = 'AdministrarRubros';
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Administrador General', @func = 'AdministrarVisibilidades';
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Administrador General', @func = 'GenerarPublicacion';
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Administrador General', @func = 'EditarPublicacion';		
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Administrador General', @func = 'GestionarPreguntas';
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Administrador General', @func = 'ComprarOfertar';
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Administrador General', @func = 'Calificar';
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Administrador General', @func = 'HistorialOperaciones';	
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Administrador General', @func = 'Facturar';		
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Administrador General', @func = 'ListadoEstadistico';				
		
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
		

----------------- /*AGREGANDO USUARIOS INICIALES*/ ------------------------

INSERT INTO MERCADONEGRO.Usuarios(Username,Password,Intentos_Login,Habilitado,Primera_Vez,Cant_Publi_Gratuitas,Reputacion,Ventas_Sin_Rendir) 
	VALUES ('admin','w23e',0,1,0,0,0,0);

/*EXEC MERCADONEGRO.AgregarRol
	@iduser = 0, @idrol = 0;
*/			
