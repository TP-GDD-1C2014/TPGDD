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
	Cod_Calificacion NUMERIC(18,0) IDENTITY,  
	Puntaje			 TINYINT	   NULL,
	Descripcion		 NVARCHAR(255) NULL,
	
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

CREATE TABLE MERCADONEGRO.Items
(
	ID_Item			 NUMERIC(18,0) IDENTITY, 
	Cantidad_Vendida NUMERIC(18,0) NOT NULL,
	Descripcion		 NVARCHAR(255) NOT NULL, /* UNIQUE???. PARA MI NO (NAZA) */
	Precio_Unitario  NUMERIC(18,2) NOT NULL,
	
	UNIQUE		(Descripcion),
	PRIMARY KEY (ID_Item)
)

CREATE TABLE MERCADONEGRO.Facturaciones
(
	ID_Facturacion    NUMERIC(18,0) IDENTITY,
	Cod_Publicacion	  NUMERIC(18,0) NOT NULL,
	ID_Item			  NUMERIC(18,0) NOT NULL,
	Forma_Pago		  NVARCHAR(255) NOT NULL,
	Total_Facturacion NUMERIC(18,2) NOT NULL,
	
	PRIMARY KEY (ID_Facturacion),
	FOREIGN KEY (Cod_Publicacion) REFERENCES MERCADONEGRO.Publicaciones(Cod_Publicacion),
	FOREIGN KEY (ID_Item)		  REFERENCES MERCADONEGRO.Items(ID_Item),
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
	ID_User				 NUMERIC(18,0)	   IDENTITY(0,1),
	Username			 NVARCHAR(100)	   NOT NULL,
	Password			 NVARCHAR(100)	   NOT NULL,
	Intentos_Login		 TINYINT DEFAULT 0 NOT NULL, 
	Habilitado			 BIT DEFAULT 1	   NOT NULL,
	Primera_Vez			 BIT DEFAULT 1     NOT NULL,
	Cant_Publi_Gratuitas TINYINT		   NULL,
	Reputacion			 FLOAT			   NULL, /*Solo vendedores*/
	Ventas_Sin_Rendir	 TINYINT		   NULL, /*Solo vendedores*/
	
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
	Tipo_Doc		 NVARCHAR(50)  DEFAULT 'DU' NOT NULL,
	Num_Doc			 NUMERIC(18,0) NOT NULL,
	Nombre			 NVARCHAR(255) NOT NULL,
	Apellido		 NVARCHAR(255) NOT NULL,
	Mail			 NVARCHAR(255) NOT NULL,
	Telefono		 NUMERIC(18,0) NULL,
	Direccion		 NVARCHAR(255) NOT NULL,
	Codigo_Postal	 NVARCHAR(50) NOT NULL,
	Fecha_Nacimiento DATETIME	   NOT NULL,
	CUIL			 NVARCHAR(50)  NULL,
	
	UNIQUE		(Telefono),
	UNIQUE		(Tipo_Doc, Num_Doc),
	PRIMARY KEY (ID_User),
	FOREIGN KEY (ID_User) REFERENCES MERCADONEGRO.Usuarios(ID_User)
)


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

CREATE TABLE MERCADONEGRO.Apto_Calificar
(
	Tipo_Operacion NVARCHAR(255),
	
	PRIMARY KEY (Tipo_Operacion)

)

CREATE TABLE MERCADONEGRO.Operaciones
(
	ID_Operacion		NUMERIC(18,0) IDENTITY,
	ID_Vendedor			NUMERIC(18,0) NOT NULL,
	ID_Comprador		NUMERIC(18,0) NOT NULL,
	Cod_Publicacion		NUMERIC(18,0) NOT NULL,
	Tipo_Operacion		NVARCHAR(255) NOT NULL,
	Fecha_Operacion		DATETIME	  NOT NULL,
	Operacion_Facturada BIT DEFAULT 0 NOT NULL, 
	
	PRIMARY KEY (ID_Operacion),
	FOREIGN KEY (ID_Vendedor)	  REFERENCES MERCADONEGRO.Usuarios(ID_User),
	FOREIGN KEY (ID_Comprador)	  REFERENCES MERCADONEGRO.Usuarios(ID_User),
	FOREIGN KEY (Cod_Publicacion) REFERENCES MERCADONEGRO.Publicaciones(Cod_Publicacion),
	FOREIGN KEY (Tipo_Operacion)  REFERENCES MERCADONEGRO.Apto_Calificar(Tipo_Operacion)
)

