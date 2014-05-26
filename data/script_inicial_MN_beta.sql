USE [GD1C2014]

IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'MERCADONEGRO')
DROP SCHEMA [MERCADONEGRO]
GO

CREATE SCHEMA MERCADONEGRO AUTHORIZATION gd
GO

---------------------------------------------Tablas iniciales-------------------------------------------

CREATE TABLE MERCADONEGRO.Rubros 
(
	ID_Rubro	NUMERIC(18,0) IDENTITY,
	Descripcion NVARCHAR(255) NOT NULL,
	
	UNIQUE		(Descripcion),
	PRIMARY KEY (ID_Rubro)
)

CREATE TABLE MERCADONEGRO.Funcionalidades
(
	ID_Funcionalidad NUMERIC(18,0) IDENTITY,
	Nombre			 NVARCHAR(255) NOT NULL,
	
	UNIQUE		(Nombre),
	PRIMARY KEY (ID_Funcionalidad)
)

CREATE TABLE MERCADONEGRO.Preguntas
(
	ID_Pregunta		NUMERIC(18,0) IDENTITY,
	Pregunta		NVARCHAR(255) NOT NULL,
	Respuesta		NVARCHAR(255) NULL,
	Fecha_Respuesta DATETIME	  NULL,
	
	PRIMARY KEY ( ID_Pregunta )
)

CREATE TABLE MERCADONEGRO.Calificaciones
(
	Cod_Calificacion	NUMERIC(18,0) IDENTITY,  
	Puntaje				NUMERIC(18,0)	   NULL,
	Descripcion			NVARCHAR(255) NULL,
	Fecha_Calificacion	DATETIME NULL,
	
	PRIMARY KEY ( Cod_Calificacion )
)

CREATE TABLE MERCADONEGRO.Visibilidades
(
	Cod_Visibilidad   NUMERIC(18,0) IDENTITY (0,1),
	Descripcion		  NVARCHAR(255) NOT NULL,
	Costo_Publicacion NUMERIC(18,2) NOT NULL,
	Porcentaje_Venta  NUMERIC(18,2) NOT NULL,
	
	UNIQUE		(Descripcion),
	PRIMARY KEY ( Cod_Visibilidad )
)

CREATE TABLE MERCADONEGRO.Publicaciones
(
	Cod_Publicacion    NUMERIC(18,0) IDENTITY,
	Cod_Visibilidad    NUMERIC(18,0) NOT NULL, 
	ID_Vendedor		   NUMERIC(18,0) NOT NULL,
	Descripcion		   NVARCHAR(255) NOT NULL,
	Stock			   NUMERIC(18,0) NOT NULL,
	Fecha_Vencimiento  DATETIME		 NOT NULL,
	Fecha_Inicial	   DATETIME		 NOT NULL,
	Precio			   NUMERIC(18,2) NOT NULL,
	Estado_Publicacion TINYINT		 NOT NULL,
	Tipo_Publicacion   TINYINT		 NOT NULL,
	Permisos_Preguntas BIT			 NOT NULL,
	Stock_Inicial	   NUMERIC(18,0) NOT NULL,
	
	PRIMARY KEY (Cod_Publicacion),
	FOREIGN KEY (Cod_Visibilidad) REFERENCES MERCADONEGRO.Visibilidades(Cod_Visibilidad)
)

CREATE TABLE MERCADONEGRO.Facturaciones
(
	Nro_Factura		  NUMERIC(18,0) IDENTITY,
	Cod_Publicacion	  NUMERIC(18,0) NOT NULL,
	Forma_Pago		  NVARCHAR(255) NOT NULL,
	Total_Facturacion NUMERIC(18,2) NOT NULL,
	Factura_Fecha	  DATETIME,
	
	PRIMARY KEY (Nro_Factura),
	FOREIGN KEY (Cod_Publicacion) REFERENCES MERCADONEGRO.Publicaciones(Cod_Publicacion),
)


CREATE TABLE MERCADONEGRO.Items
(
	ID_Item			 NUMERIC(18,0) IDENTITY, 
	Nro_Factura		 NUMERIC(18,0) NOT NULL,
	Cantidad_Vendida NUMERIC(18,0) NOT NULL,
	Descripcion		 NVARCHAR(255) NOT NULL,
	Precio_Item		 NUMERIC(18,2) NOT NULL,
	
	PRIMARY KEY (ID_Item),
	FOREIGN KEY(Nro_Factura) REFERENCES MERCADONEGRO.Facturaciones(Nro_Factura)
)

CREATE TABLE MERCADONEGRO.Pregunta_Publicacion
(
	Cod_Publicacion NUMERIC(18,0),
	ID_Pregunta		NUMERIC(18,0),
	
	PRIMARY KEY (Cod_Publicacion,ID_Pregunta),
	FOREIGN KEY (Cod_Publicacion) REFERENCES MERCADONEGRO.Publicaciones(Cod_Publicacion),
	FOREIGN KEY (ID_Pregunta)     REFERENCES MERCADONEGRO.Preguntas(ID_Pregunta)
)

CREATE TABLE MERCADONEGRO.Rubro_Publicacion
(
	Cod_Publicacion NUMERIC(18,0),
	ID_Rubro		NUMERIC(18,0),
	
	PRIMARY KEY (Cod_Publicacion, ID_Rubro),
	FOREIGN KEY (Cod_Publicacion) REFERENCES MERCADONEGRO.Publicaciones(Cod_Publicacion),
	FOREIGN KEY (ID_Rubro)		  REFERENCES MERCADONEGRO.Rubros(ID_Rubro)
)

CREATE TABLE MERCADONEGRO.Usuarios
(
	ID_User				 NUMERIC(18,0) IDENTITY(1,1),
	Username			 NVARCHAR(255)	   NOT NULL,
	Password			 NVARCHAR(255)	   NOT NULL,
	Intentos_Login		 TINYINT DEFAULT 0 NOT NULL, 
	Habilitado			 BIT DEFAULT 1	   NOT NULL,
	Primera_Vez			 BIT DEFAULT 1     NOT NULL,
	Cant_Publi_Gratuitas TINYINT		   NULL,
	Reputacion			 FLOAT			   NULL, /*Solo vendedores*/
	Ventas_Sin_Rendir	 TINYINT		   NULL, /*Solo vendedores*/
	
	UNIQUE (Username),
	PRIMARY KEY(ID_User)
)


CREATE TABLE MERCADONEGRO.Empresas
(
	ID_User		    NUMERIC(18,0),
	Razon_Social	NVARCHAR(255) NOT NULL,
	CUIT			NVARCHAR(50)  NOT NULL,
	Telefono		NUMERIC(18,0) NULL, 
	Direccion		NVARCHAR(255) NOT NULL,
	Codigo_Postal	NVARCHAR(50)  NOT NULL,
	Ciudad			NVARCHAR(50)  NULL,
	Mail			NVARCHAR(50)  NOT NULL,
	Nombre_Contacto NVARCHAR(50)  NULL,
	Fecha_Creacion  DATETIME	  NOT NULL,

	UNIQUE		(Razon_Social), /* aca separé la razon y el cuit porque no pueden repetirse en ningun momento */
	UNIQUE		(CUIT),
	PRIMARY KEY (ID_User),
	FOREIGN KEY (ID_User) REFERENCES MERCADONEGRO.Usuarios(ID_User)
)

CREATE TABLE MERCADONEGRO.Clientes
(
	ID_User			 NUMERIC(18,0),
	Tipo_Doc		 NVARCHAR(50)  NOT NULL,
	Num_Doc			 NUMERIC(18,0) NOT NULL,
	Nombre			 NVARCHAR(255) NOT NULL,
	Apellido		 NVARCHAR(255) NOT NULL,
	Mail			 NVARCHAR(255) NOT NULL,
	Telefono		 NUMERIC(18,0) NULL,
	Direccion		 NVARCHAR(255) NOT NULL,
	Codigo_Postal	 NVARCHAR(50)  NOT NULL,
	Fecha_Nacimiento DATETIME	   NOT NULL,
	--CUIL			 NVARCHAR(50)  NULL,
	
	--UNIQUE (Telefono),
	UNIQUE (Tipo_Doc,Num_Doc),
	
	PRIMARY KEY (ID_User),
	FOREIGN KEY (ID_User) REFERENCES MERCADONEGRO.Usuarios(ID_User)
)

CREATE UNIQUE NONCLUSTERED INDEX idx_telefono_notnull
ON MERCADONEGRO.Clientes(Telefono)
WHERE Telefono IS NOT NULL;

CREATE TABLE MERCADONEGRO.Roles
(
	ID_Rol	   NUMERIC(18,0) IDENTITY(0,1),
	Nombre	   NVARCHAR(255) NOT NULL,
	Habilitado BIT			 NOT NULL
	
	UNIQUE		(Nombre),
	PRIMARY KEY (ID_Rol)
)

CREATE TABLE MERCADONEGRO.Funcionalidad_Rol 
( 
	ID_Funcionalidad NUMERIC(18,0) NOT NULL, 
	ID_Rol			 NUMERIC(18,0) NOT NULL, 
	
	PRIMARY KEY (ID_Funcionalidad, ID_Rol), 
	FOREIGN KEY (ID_Funcionalidad) REFERENCES MERCADONEGRO.Funcionalidades(ID_Funcionalidad), 
	FOREIGN KEY (ID_Rol)		   REFERENCES MERCADONEGRO.Roles(ID_Rol)
) 
	
	
CREATE TABLE MERCADONEGRO.Roles_Usuarios 
( 
	ID_User NUMERIC(18,0) NOT NULL,
	ID_Rol  NUMERIC(18,0) NOT NULL,
	
	PRIMARY KEY (ID_User, ID_Rol), 
	FOREIGN KEY (ID_User) REFERENCES MERCADONEGRO.Usuarios(ID_User), 
	FOREIGN KEY (ID_Rol)  REFERENCES MERCADONEGRO.Roles(ID_Rol) 
	
)


CREATE TABLE MERCADONEGRO.Operaciones
(
	ID_Operacion		NUMERIC(18,0) IDENTITY,
	ID_Vendedor			NUMERIC(18,0) NOT NULL,
	ID_Comprador		NUMERIC(18,0) NOT NULL,
	Cod_Publicacion		NUMERIC(18,0) NOT NULL,
	Tipo_Operacion		NVARCHAR(255) NOT NULL,
	Cod_Calificacion	NUMERIC(18,0) NULL,
	Fecha_Operacion		DATETIME	  NOT NULL,
	Operacion_Facturada BIT DEFAULT 0 NOT NULL, 
	
	PRIMARY KEY (ID_Operacion),
	FOREIGN KEY (ID_Vendedor)	  REFERENCES MERCADONEGRO.Usuarios(ID_User),
	FOREIGN KEY (ID_Comprador)	  REFERENCES MERCADONEGRO.Usuarios(ID_User),
	FOREIGN KEY (Cod_Publicacion) REFERENCES MERCADONEGRO.Publicaciones(Cod_Publicacion),
	FOREIGN KEY (Cod_Calificacion) REFERENCES MERCADONEGRO.Calificaciones(Cod_Calificacion)
)
GO

CREATE TABLE MERCADONEGRO.Subastas
(
	ID_Subasta			NUMERIC(18,0) IDENTITY,
	ID_Vendedor			NUMERIC(18,0) NOT NULL,
	ID_Comprador		NUMERIC(18,0) NOT NULL,
	Cod_Publicacion		NUMERIC(18,0) NOT NULL,
	Tipo_Operacion		NVARCHAR(255) NOT NULL,
	Fecha_Oferta		DATETIME	  NOT NULL, 
	
	PRIMARY KEY (ID_Subasta),
	FOREIGN KEY (ID_Vendedor)	  REFERENCES MERCADONEGRO.Usuarios(ID_User),
	FOREIGN KEY (ID_Comprador)	  REFERENCES MERCADONEGRO.Usuarios(ID_User)



)
GO
-----------------------------------------------Funciones, Stored Procedures y Triggers------------------------------------------------

/* SP Agregar FUNCIONALIDAD al ROL */
CREATE PROCEDURE MERCADONEGRO.AgregarFuncionalidad(@rol nvarchar(255), @func nvarchar(255)) AS
BEGIN
	INSERT INTO MERCADONEGRO.Funcionalidad_Rol (ID_Rol, ID_Funcionalidad)
		VALUES ((SELECT ID_Rol FROM MERCADONEGRO.Roles WHERE Nombre = @rol),
		        (SELECT ID_Funcionalidad FROM MERCADONEGRO.Funcionalidades WHERE Nombre = @func))
END
GO

/* SP Quitar FUNCIONALIDAD al ROL */
CREATE PROCEDURE MERCADONEGRO.QuitarFuncionalidad(@rol nvarchar(255), @func nvarchar(255)) AS
BEGIN
	DELETE FROM MERCADONEGRO.Funcionalidad_Rol
		WHERE 
			(SELECT ID_Rol FROM MERCADONEGRO.Roles WHERE Nombre = @rol)
			= MERCADONEGRO.Funcionalidad_Rol.ID_Rol
			AND
			(SELECT ID_Funcionalidad FROM MERCADONEGRO.Funcionalidades WHERE Nombre = @func )
			 = MERCADONEGRO.Funcionalidad_Rol.ID_Funcionalidad
			 
END
GO


/* SP agregar ROL a la base */

CREATE PROCEDURE MERCADONEGRO.agregarRolNuevo(@nombreRol nvarchar(255), @ret numeric (18,0) output)
AS BEGIN
	INSERT INTO MERCADONEGRO.Roles (Nombre, Habilitado) VALUES (@nombreRol, 1)
	SET @ret = SCOPE_IDENTITY()
END
GO

/* SP agregar ROL al USUARIO */
CREATE PROCEDURE MERCADONEGRO.AgregarRol(@iduser numeric(18,0), @idrol numeric(18,0)) AS
BEGIN
	INSERT INTO MERCADONEGRO.Roles_Usuarios (ID_User,ID_Rol)
		VALUES ((SELECT ID_User FROM MERCADONEGRO.Usuarios WHERE ID_User = @iduser),
				(SELECT ID_Rol FROM MERCADONEGRO.Roles WHERE ID_Rol = @idrol))
END 
GO

/* SP Agregar Usuario NUEVO */

CREATE PROCEDURE MERCADONEGRO.AgregarUsuario(@username nvarchar(255), @password nvarchar(255),@primeraVez bit, @ret numeric (18,0) output)
AS BEGIN
		INSERT INTO MERCADONEGRO.Usuarios(Username, Password, Intentos_Login, Habilitado,
											Primera_Vez, Cant_Publi_Gratuitas, Reputacion, Ventas_Sin_Rendir)
			VALUES(@username, @password, 0, 1, @primeraVez, 0, 0, 0)
			SET @ret = SCOPE_IDENTITY()
END
GO

/* SP Agregar PUBLICACION NUEVA */
											 
CREATE PROCEDURE MERCADONEGRO.AgregarPublicacion(@codVisibilidad numeric(18,0), @idVendedor numeric(18,0),
												 @descripcion nvarchar(255), @stock numeric(18,0),
												 @fechaInic datetime, @fechaVenc datetime,
												 @precio numeric(18,2), @estadoPubl tinyint, @tipoPubl tinyint,
												 @permisosPreg bit,
												 @ret numeric (18,0) output)
AS BEGIN
		INSERT INTO MERCADONEGRO.Publicaciones(Cod_Visibilidad, ID_Vendedor, Descripcion, Stock, Fecha_Inicial,
												Fecha_Vencimiento, Precio, Estado_Publicacion, Permisos_Preguntas,
												Tipo_Publicacion, Stock_Inicial)
			VALUES(@codVisibilidad, @idVendedor, @descripcion, @stock, @fechaInic, @fechaVenc, @precio, @estadoPubl,
				   @permisosPreg, @tipoPubl, @stock)
				   SET @ret = SCOPE_IDENTITY()
END
GO

/*
CREATE PROCEDURE MERCADONEGRO.InsertarCliente(@tipoDoc nvarchar(50),
											  @numDoc numeric(18,0), @nombre nvarchar(255),
											  @apellido nvarchar(255), @mail nvarchar(255),
											  @telefono numeric(18,0), @direccion nvarchar(255),
											  @codPostal nvarchar(50), @fechaNacimiento datetime)
BEGIN
	INSERT INTO MERCADONEGRO.Clientes(ID_User, Tipo_Doc, Num_Doc, Nombre, Apellido, Mail, Telefono, Direccion,
									 Codigo_Postal, Fecha_Nacimiento) 
			VALUES((SELECT ID_User FROM MERCADONEGRO.Usuarios WHERE  = @numDoc),
					(SELECT
*/

/*
CREATE TRIGGER Trigger_InsertarFactura
	ON MERCADONEGRO.Publicaciones
	AFTER INSERT AS
	SET NOCOUNT ON
	
	INSERT INTO MERCADONEGRO.Facturaciones
	SELECT DISTINCT Factura_Nro, 
					Cod_Publicacion, 
					Forma_Pago_Desc, 
					Factura_Total
				
	FROM gd_esquema.Maestra, MERCADONEGRO.Publicaciones
		WHERE gd_esquema.Maestra.Factura_Nro IS NOT NULL AND gd_esquema.Maestra.Publicacion_Cod = MERCADONEGRO.Publicaciones.Cod_Publicacion
GO
*/

		/*			
				
CREATE TRIGGER Trigger_InsertarItemAFactura
	ON MERCADONEGRO.Facturaciones AFTER INSERT AS
	SET NOCOUNT ON
	
	INSERT INTO MERCADONEGRO.Items(Nro_Factura, Cantidad_Vendida, Descripcion, Precio_Item)
		SELECT Nro_Factura, 
			   Item_Factura_Cantidad, 
			   Publicacion_Descripcion,
			   Item_Factura_Monto
			   
		 
		 FROM MERCADONEGRO.Facturaciones, gd_esquema.Maestra
			WHERE MERCADONEGRO.Facturaciones.Nro_Factura = gd_esquema.Maestra.Factura_Nro
GO		
		*/					
----------------------------------------------------Datos Iniciales-----------------------------------------------

PRINT 'Creando valores por defecto...'

-- ///// Agregar las que sean necesarias /////
/* FUNCIONALIDADES */
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

/* ROLES */
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
SET IDENTITY_INSERT MERCADONEGRO.Usuarios ON
INSERT INTO MERCADONEGRO.Usuarios(ID_User,Username,Password,Intentos_Login,Habilitado,Primera_Vez,Cant_Publi_Gratuitas,Reputacion,Ventas_Sin_Rendir) 
	VALUES (0,'admin','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',0,1,0,0,0,0);--TODO ver si ultimas tres columnas podrian ir NULL
SET IDENTITY_INSERT MERCADONEGRO.Usuarios OFF

EXEC MERCADONEGRO.AgregarRol
	@iduser = 0, @idrol = 0;

GO
------------------------MIGRACION-----------------------------


-------------------MIGRANDO TABLA DE RUBROS---------------------
PRINT 'MIGRANDO TABLA DE RUBROS'

INSERT INTO MERCADONEGRO.Rubros(Descripcion)
	SELECT DISTINCT gd_esquema.Maestra.Publicacion_Rubro_Descripcion
		FROM gd_esquema.Maestra
			WHERE gd_esquema.Maestra.Publicacion_Cod IS NOT NULL


-----------------MIGRANDO TABLA DE CALIFICACIONES -------------------

PRINT 'MIGRANDO TABLA DE CALIFICACIONES';

SET IDENTITY_INSERT MERCADONEGRO.Calificaciones ON

INSERT INTO MERCADONEGRO.Calificaciones (Cod_Calificacion,Puntaje,Descripcion, Fecha_Calificacion)
	SELECT 
			Calificacion_Codigo,
			Calificacion_Cant_Estrellas,
			Calificacion_Descripcion,
			Compra_Fecha
	FROM gd_esquema.Maestra
	WHERE Calificacion_Codigo IS NOT NULL
	
SET IDENTITY_INSERT MERCADONEGRO.Calificaciones OFF


-------------------------MIGRANDO TABLA DE VISIBILIDADES---------------------------

 

PRINT 'MIGRANDO TABLA DE VISIBILIDADES';
GO
INSERT INTO MERCADONEGRO.Visibilidades(Descripcion, Costo_Publicacion, Porcentaje_Venta) 

	SELECT  DISTINCT 
					 Publicacion_Visibilidad_Desc,
					 Publicacion_Visibilidad_Precio,
					 Publicacion_Visibilidad_Porcentaje			
					 
	FROM gd_esquema.Maestra
	WHERE Publicacion_Visibilidad_Cod IS NOT NULL
	ORDER BY Publicacion_Visibilidad_Precio DESC
GO	


--------------------------Vistas Y Tablas Temporales-----------------------------


CREATE TABLE #UsuariosTemp
(
	iduser NUMERIC(18,0) IDENTITY(1,1),
	username NVARCHAR(255) NOT NULL,
	pass NVARCHAR(255) NOT NULL,
	rol int
	PRIMARY KEY (iduser)
	
)
GO
--select * from #UsuariosTemp


INSERT INTO  #UsuariosTemp 
	SELECT DISTINCT	
	
		Publ_Cli_Apeliido+Publ_Cli_Nombre    AS username,
		CONVERT(nvarchar(255), Publ_Cli_Dni) AS pass,
		1									 AS rol
		
	FROM gd_esquema.Maestra
	WHERE Publ_Cli_Dni IS NOT NULL
	
	UNION 
	
	SELECT DISTINCT 
	
		'RazonSocialNro'+ SUBSTRING(Publ_Empresa_Razon_Social,17,2) AS username,
		CONVERT(nvarchar(255), Publ_Empresa_Cuit)				    AS pass,
		2															AS rol
		
	FROM gd_esquema.Maestra
	WHERE Publ_Empresa_Cuit IS NOT NULL
GO	
	
-----------------VISTAS LISTADO ESTADISTICO TOP 5-----------------------------

-----VENDEDORES CON MAYOR FACTURACION------
CREATE VIEW  MERCADONEGRO.MayorFacturacionView		 AS
	SELECT  Usuarios.Username						 AS Vendedor,
			SUM(Facturaciones.Total_Facturacion)	 AS Facturacion_Total, 
			MONTH(Facturaciones.Factura_Fecha)		 AS Mes,									
			YEAR(Facturaciones.Factura_Fecha)		 AS Año
			 
	
		FROM  MERCADONEGRO.Usuarios AS Usuarios
			INNER JOIN MERCADONEGRO.Publicaciones AS Publicaciones
					ON Usuarios.ID_User = Publicaciones.ID_Vendedor
			INNER JOIN MERCADONEGRO.Facturaciones AS Facturaciones 
					ON Publicaciones.Cod_Publicacion = Facturaciones.Cod_Publicacion
	      WHERE Facturaciones.Total_Facturacion != 0
			GROUP BY Usuarios.Username, MONTH(Facturaciones.Factura_Fecha), YEAR(Facturaciones.Factura_Fecha)
	      			
GO	
--DROP VIEW MERCADONEGRO.MayorFacturacionView
--SELECT * FROM MERCADONEGRO.MayorFacturacionView

------VENDEDORES CON MAYOR REPUTACION---------
CREATE VIEW MERCADONEGRO.MayorReputacionView AS
	
	SELECT Usuarios.Username							AS Vendedor,
		   Calificaciones.Puntaje						AS Puntaje,
		   MONTH(Calificaciones.Fecha_Calificacion)		AS Mes,
		   YEAR(Calificaciones.Fecha_Calificacion)		AS Año	   
			
		FROM MERCADONEGRO.Usuarios					AS Usuarios
		JOIN MERCADONEGRO.Operaciones				AS Operaciones
			ON Operaciones.ID_Vendedor = Usuarios.ID_User
		JOIN MERCADONEGRO.Calificaciones			AS Calificaciones
			ON Calificaciones.Cod_Calificacion = Operaciones.Cod_Calificacion
GO
--DROP VIEW MERCADONEGRO.MayorReputacionView
--SELECT * FROM MERCADONEGRO.MayorReputacionView ORDER BY Vendedor, MES, AÑO

---------CLIENTES CON MAYOR CANTIDAD DE PUBLICACIONES SIN CALIFICAR--------


---------------------------USUARIOS------------------------------
PRINT 'MIGRANDO TABLAS USUARIOS'

SET IDENTITY_INSERT MERCADONEGRO.Usuarios ON

INSERT INTO MERCADONEGRO.Usuarios(ID_User,Username,Password,Cant_Publi_Gratuitas,Reputacion,Ventas_Sin_Rendir)
	SELECT iduser,username,pass,0,0,0
	FROM #UsuariosTemp
	
SET IDENTITY_INSERT MERCADONEGRO.Usuarios OFF
--select * from MERCADONEGRO.Usuarios order by ID_User	
GO


CREATE VIEW MERCADONEGRO.CalificacionView
	AS SELECT 
			MERCADONEGRO.Usuarios.ID_User			AS iduser,
			AVG(Calificacion_Cant_Estrellas)		AS promedio
			
	FROM gd_esquema.Maestra, MERCADONEGRO.Usuarios
	WHERE Calificacion_Codigo IS NOT NULL
		AND (MERCADONEGRO.Usuarios.Password = CONVERT(nvarchar(255), gd_esquema.Maestra.Publ_Cli_Dni)
		OR MERCADONEGRO.Usuarios.Password = gd_esquema.Maestra.Publ_Empresa_Cuit)
	
	GROUP BY MERCADONEGRO.Usuarios.ID_User
GO
--select * from MERCADONEGRO.CalificacionView
/*
UPDATE MERCADONEGRO.Usuarios
	SET Reputacion = (
		SELECT  TOP 1MERCADONEGRO.CalificacionView.promedio 
		FROM MERCADONEGRO.CalificacionView
			JOIN MERCADONEGRO.Usuarios on MERCADONEGRO.Usuarios.ID_User = MERCADONEGRO.CalificacionView.iduser
						)
	FROM MERCADONEGRO.Usuarios,MERCADONEGRO.CalificacionView
	WHERE MERCADONEGRO.Usuarios.ID_User = MERCADONEGRO.CalificacionView.iduser
GO*/

--select * from MERCADONEGRO.Usuarios
/*UPDATE MERCADONEGRO.Usuarios
	SET Reputacion = (
		SELECT ALL MERCADONEGRO.CalificacionView.promedio 
		FROM MERCADONEGRO.CalificacionView 
			JOIN MERCADONEGRO.Usuarios on MERCADONEGRO.Usuarios.ID_User = MERCADONEGRO.CalificacionView.iduser
						)
	FROM MERCADONEGRO.Usuarios,MERCADONEGRO.CalificacionView
	WHERE MERCADONEGRO.Usuarios.ID_User = MERCADONEGRO.CalificacionView.iduser
	*/

-----------------

-- Declare the variables to store the values returned by FETCH.
DECLARE @Iduser numeric(18,0), @Promedio float;

DECLARE contact_cursor CURSOR FOR
SELECT iduser,promedio FROM MERCADONEGRO.CalificacionView
ORDER BY iduser;

OPEN contact_cursor;

-- Perform the first fetch.
FETCH NEXT FROM contact_cursor
INTO @Iduser, @Promedio;

-- Check @@FETCH_STATUS to see if there are any more rows to fetch.
WHILE @@FETCH_STATUS = 0
BEGIN
   -- This is executed as long as the previous fetch succeeds.
   UPDATE MERCADONEGRO.Usuarios
   SET Reputacion = @Promedio
		WHERE MERCADONEGRO.Usuarios.ID_User = @Iduser	
   FETCH NEXT FROM contact_cursor
	INTO @Iduser, @Promedio;
END

CLOSE contact_cursor;
DEALLOCATE contact_cursor;
GO
-----------------------------
/*UPDATE BC
	SET cant_consultas = (
		SELECT COUNT(*)
		FROM mario_killers.Turno t1
			JOIN mario_killers.Atencion on t1.id = Atencion.id
		WHERE t1.persona = t2.persona
			AND t2.horario >= t1.horario
			--AND EXISTS (SELECT * FROM mario_killers.Atencion WHERE Atencion.id = t1.id)
	)
	FROM mario_killers.Bono_Consulta BC
		JOIN mario_killers.Atencion a ON a.bono_consulta = BC.id
		JOIN mario_killers.Turno t2 ON t2.id = a.id

*/

----------------------MIGRANDO Roles_Usuario------------------------

PRINT 'MIGRANDO TABLA ROLES_USUARIOS'
GO

INSERT INTO MERCADONEGRO.Roles_Usuarios (ID_User,ID_Rol)

	SELECT #UsuariosTemp.iduser,
		   CASE WHEN #UsuariosTemp.rol = 0 --Admin
				THEN (0)
				WHEN #UsuariosTemp.rol = 1 --Cliente
				THEN (1)
				WHEN #UsuariosTemp.rol = 2 -- Empresa
				THEN (2)
		   END
	FROM #UsuariosTemp
--SELECT * FROM MERCADONEGRO.Roles_Usuarios
	
-----------------------MIGRANDO TABLA CLIENTES-------------------------
--select * from MERCADONEGRO.Clientes


PRINT 'MIGRANDO TABLA CLIENTES'
GO

INSERT INTO MERCADONEGRO.Clientes (ID_User,
								   Tipo_Doc,
								   Num_Doc,
								   Nombre,
								   Apellido,
								   Mail,
								   Direccion,
								   Codigo_Postal,
								   Fecha_Nacimiento)

	SELECT DISTINCT	#UsuariosTemp.iduser,
					'DU',
					gd_esquema.Maestra.Publ_Cli_Dni,		
					gd_esquema.Maestra.Publ_Cli_Nombre,	
					gd_esquema.Maestra.Publ_Cli_Apeliido,  
					gd_esquema.Maestra.Publ_Cli_Mail,
					gd_esquema.Maestra.Publ_Cli_Dom_Calle 
									   + ' ' + CONVERT(nvarchar(255),gd_esquema.Maestra.Publ_Cli_Nro_Calle)
									   + ' ' + CONVERT(nvarchar(255),gd_esquema.Maestra.Publ_Cli_Piso)
									   + ' ' + CONVERT(nvarchar(255),gd_esquema.Maestra.Publ_Cli_Depto),
					gd_esquema.Maestra.Publ_Cli_Cod_Postal,
					gd_esquema.Maestra.Publ_Cli_Fecha_Nac 
			
	FROM #UsuariosTemp, gd_esquema.Maestra
	WHERE Publ_Cli_Dni IS NOT NULL AND (#UsuariosTemp.username = gd_esquema.Maestra.Publ_Cli_Apeliido+gd_esquema.Maestra.Publ_Cli_Nombre)

--select * from MERCADONEGRO.Empresas


PRINT 'MIGRANDO TABLA EMPRESAS'
GO

INSERT INTO MERCADONEGRO.Empresas (ID_User,
								   Razon_Social,
								   CUIT,
								   Direccion,
								   Codigo_Postal,
								   Mail,
								   Fecha_Creacion)

	SELECT DISTINCT	#UsuariosTemp.iduser,
					gd_esquema.Maestra.Publ_Empresa_Razon_Social,
					gd_esquema.Maestra.Publ_Empresa_Cuit,
					gd_esquema.Maestra.Publ_Empresa_Dom_Calle 
										   + ' ' + CONVERT(nvarchar(255),gd_esquema.Maestra.Publ_Empresa_Nro_Calle)
									       + ' ' + CONVERT(nvarchar(255),gd_esquema.Maestra.Publ_Empresa_Piso)
										   + ' ' + CONVERT(nvarchar(255),gd_esquema.Maestra.Publ_Empresa_Depto),
					gd_esquema.Maestra.Publ_Empresa_Cod_Postal,
					gd_esquema.Maestra.Publ_Empresa_Mail,
					gd_esquema.Maestra.Publ_Empresa_Fecha_Creacion 
			
	FROM #UsuariosTemp,gd_esquema.Maestra
	WHERE Publ_Empresa_Cuit  IS NOT NULL AND (#UsuariosTemp.username = 'RazonSocialNro'+ RIGHT(Publ_Empresa_Razon_Social,2))



-------------------------------MIGRANDO TABLA PUBLICACIONES---------------------------------------

PRINT 'MIGRANDO TABLA PUBLICACIONES'
GO
--------------------VISTA DE CLIENTES Y EMPRESAS---------------
		
CREATE VIEW MERCADONEGRO.Vista_Publicaciones AS SELECT DISTINCT
		MERCADONEGRO.Usuarios.ID_User AS ID_User, 
		Publicacion_Cod, 
		Publicacion_Visibilidad_Cod - 10002 AS Cod_Visibilidad,
		Publicacion_Descripcion,
		Publicacion_Stock,
		Publicacion_Fecha,
		Publicacion_Fecha_Venc,
		Publicacion_Precio, 
		CASE Publicacion_Estado
			WHEN 'Publicada' 
			THEN 0
		END AS Estado_Publicacion, 
			CASE Publicacion_Tipo
				WHEN 'Compra Inmediata' 
				THEN 1 
				WHEN 'Subasta' 
				THEN 0
		END AS Tipo_Publicacion, 
		1 AS Permisos_Preguntas--Permiso de preguntas (cambiar esto si es necesario)
					
	FROM	gd_esquema.Maestra, MERCADONEGRO.Usuarios
	WHERE	Publ_Cli_Dni IS NOT NULL AND MERCADONEGRO.Usuarios.Password = CONVERT(NVARCHAR(255), gd_esquema.Maestra.Publ_Cli_Dni)
	
	UNION
	
	SELECT DISTINCT
		MERCADONEGRO.Usuarios.ID_User AS ID_User, 
		Publicacion_Cod, 
		Publicacion_Visibilidad_Cod - 10002 AS Cod_Visibilidad,
		Publicacion_Descripcion,
		Publicacion_Stock,
		Publicacion_Fecha,
		Publicacion_Fecha_Venc,
		Publicacion_Precio, 
		CASE Publicacion_Estado
			WHEN 'Publicada' 
			THEN 0
		END AS Estado_Publicacion, 
			CASE Publicacion_Tipo
				WHEN 'Compra Inmediata' 
				THEN 1 
				WHEN 'Subasta' 
				THEN 0
		END AS Tipo_Publicacion, 
		1 AS Permisos_Preguntas--Permiso de preguntas (cambiar esto si es necesario)
					
	FROM	gd_esquema.Maestra, MERCADONEGRO.Usuarios
	WHERE	Publ_Empresa_Cuit IS NOT NULL AND MERCADONEGRO.Usuarios.Password = gd_esquema.Maestra.Publ_Empresa_Cuit
GO

--------------------INSERTANDO EN PUBLICACIONES---------------

SET IDENTITY_INSERT MERCADONEGRO.Publicaciones ON

INSERT INTO MERCADONEGRO.Publicaciones(Cod_Publicacion,
										Cod_Visibilidad,
										ID_Vendedor,
										Descripcion,
										Stock,
										Fecha_Inicial,
										Fecha_Vencimiento,
										Precio,
										Estado_Publicacion,
										Tipo_Publicacion,
										Permisos_Preguntas,
										Stock_Inicial)
										
	SELECT Publicacion_Cod, Cod_Visibilidad, ID_User, Publicacion_Descripcion, Publicacion_Stock, Publicacion_Fecha, Publicacion_Fecha_Venc,
			 Publicacion_Precio, Estado_Publicacion, Tipo_Publicacion, Permisos_Preguntas,Publicacion_Stock
									
	FROM	MERCADONEGRO.Vista_Publicaciones

	
SET IDENTITY_INSERT MERCADONEGRO.Publicaciones OFF

-----------------------MIGRANDO PUBLICACIONES_RUBROS------------------------
PRINT 'MIGRANDO RUBRO_PUBLICACION'

INSERT INTO MERCADONEGRO.Rubro_Publicacion(Cod_Publicacion, ID_Rubro)
	SELECT DISTINCT MERCADONEGRO.Publicaciones.Cod_Publicacion,
					MERCADONEGRO.Rubros.ID_Rubro
					
	FROM MERCADONEGRO.Publicaciones, MERCADONEGRO.Rubros, gd_esquema.Maestra
		WHERE MERCADONEGRO.Publicaciones.Cod_Publicacion = gd_esquema.Maestra.Publicacion_Cod 
			  AND MERCADONEGRO.Rubros.Descripcion = gd_esquema.Maestra.Publicacion_Rubro_Descripcion

------------------------FACTURACIONES-------------------------------
PRINT 'MIGRANDO LA TABLA FACTURACIONES'
GO

SET IDENTITY_INSERT MERCADONEGRO.Facturaciones ON

INSERT INTO MERCADONEGRO.Facturaciones(Nro_Factura, Cod_Publicacion, Forma_Pago, Total_Facturacion, Factura_Fecha)
	SELECT DISTINCT Factura_Nro, 
					MERCADONEGRO.Publicaciones.Cod_Publicacion, 
					Forma_Pago_Desc, 
					Factura_Total,
					Factura_Fecha
				
	FROM gd_esquema.Maestra, MERCADONEGRO.Publicaciones
		WHERE gd_esquema.Maestra.Factura_Nro IS NOT NULL AND gd_esquema.Maestra.Publicacion_Cod = MERCADONEGRO.Publicaciones.Cod_Publicacion
	

SET IDENTITY_INSERT MERCADONEGRO.Facturaciones OFF
GO

-----------------------ITEMS-------------------------------------
PRINT 'MIGRANDO LA TABLA ITEMS'
GO

INSERT INTO MERCADONEGRO.Items(Nro_Factura, Cantidad_Vendida, Descripcion, Precio_Item)
		SELECT Nro_Factura, 
			   Item_Factura_Cantidad, 
			   Publicacion_Descripcion,
			   Item_Factura_Monto
			   
		 
		 FROM MERCADONEGRO.Facturaciones, gd_esquema.Maestra
			WHERE MERCADONEGRO.Facturaciones.Nro_Factura = gd_esquema.Maestra.Factura_Nro
GO

-------------------------OPERACIONES---------------------------------------------------------------
PRINT 'MIGRANDO LAS COMPRAS'
GO

INSERT INTO MERCADONEGRO.Operaciones

	SELECT DISTINCT MERCADONEGRO.Publicaciones.ID_Vendedor,	--AS ID_Vendedor,
					MERCADONEGRO.Usuarios.ID_User,			--AS ID_Comprador,
					Publicacion_Cod,							--AS codpublic, 
					Publicacion_Tipo,						--AS tipo,
					Calificacion_Codigo,						--AS codcalific,
					Compra_Fecha,							--AS fechaCompra,
					1										--AS opFact
					
	FROM gd_esquema.Maestra, MERCADONEGRO.Usuarios, MERCADONEGRO.Publicaciones
	
	WHERE gd_esquema.Maestra.Calificacion_Codigo IS NOT NULL
	AND (Publ_Cli_Dni IS NOT NULL OR Publ_Empresa_Cuit IS NOT NULL)
	AND	gd_esquema.Maestra.Publicacion_Cod = MERCADONEGRO.Publicaciones.Cod_Publicacion 
	AND MERCADONEGRO.Usuarios.Password = convert(nvarchar(255),Cli_Dni) 
		
GO


CREATE VIEW MERCADONEGRO.SubastasView AS

	SELECT DISTINCT MERCADONEGRO.Publicaciones.ID_Vendedor  AS vendedor,
					MERCADONEGRO.Usuarios.ID_User			AS ofertador,
					Publicacion_Cod							AS codpublic,
					Publicacion_Tipo						AS tipo,
					Calificacion_Codigo						AS codcalific,
					Oferta_Fecha							AS fechaOferta,
					0										AS opFact
					
	FROM gd_esquema.Maestra, MERCADONEGRO.Usuarios, MERCADONEGRO.Publicaciones
	
	WHERE gd_esquema.Maestra.Calificacion_Codigo IS NULL
	AND gd_esquema.Maestra.Oferta_Fecha IS NOT NULL
	AND (Publ_Cli_Dni IS NOT NULL OR Publ_Empresa_Cuit IS NOT NULL)
	AND	gd_esquema.Maestra.Publicacion_Cod = MERCADONEGRO.Publicaciones.Cod_Publicacion
	AND MERCADONEGRO.Usuarios.Password = convert(nvarchar(255),Cli_Dni)  	
	AND MERCADONEGRO.Publicaciones.Tipo_Publicacion = 0
GO	
	
--select * from MERCADONEGRO.SubastasView
--DROP VIEW MERCADONEGRO.OperacionesOfertas


---------------MIGRANDO SUBASTAS---------------------------
PRINT 'MIGRANDO LA TABLA SUBASTAS'
GO


INSERT INTO MERCADONEGRO.Subastas(ID_Vendedor,ID_Comprador,Cod_Publicacion,Tipo_Operacion,Fecha_Oferta)
	SELECT vendedor,ofertador, codpublic, tipo, fechaOferta
	FROM MERCADONEGRO.SubastasView
	EXCEPT
	SELECT ID_Vendedor, Id_Comprador, Cod_Publicacion, Tipo_Operacion, Fecha_Operacion
	FROM MERCADONEGRO.Operaciones


GO


-----------------------------DROPS-----------------------------
DROP TABLE #UsuariosTemp
GO
DROP VIEW MERCADONEGRO.Vista_Publicaciones
GO
DROP VIEW MERCADONEGRO.SubastasView
GO
DROP VIEW MERCADONEGRO.CalificacionView
GO