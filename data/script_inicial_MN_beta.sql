
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'MERCADONEGRO')
DROP SCHEMA [MERCADONEGRO]
GO

CREATE SCHEMA MERCADONEGRO AUTHORIZATION gd
GO

CREATE TABLE MERCADONEGRO.Rubros 
(
	ID_Rubro NUMERIC(18,0) IDENTITY,
	Descripcion NVARCHAR(255) UNIQUE NOT NULL,
	
	PRIMARY KEY (ID_Rubro)
)

CREATE TABLE MERCADONEGRO.Funcionalidades
(
	ID_Funcionalidad NUMERIC(18,0) IDENTITY,
	Nombre NVARCHAR(255) UNIQUE NOT NULL,
	
	PRIMARY KEY (ID_Funcionalidad)
)

CREATE TABLE MERCADONEGRO.Preguntas
(
	ID_Pregunta NUMERIC(18,0) IDENTITY,
	Pregunta NVARCHAR(255) NOT NULL,
	Respuesta NVARCHAR(255)NULL,
	Fecha_Respuesta DATETIME NULL,
	
	PRIMARY KEY ( ID_Pregunta )
)

CREATE TABLE MERCADONEGRO.Calificaciones
(
	Cod_Calificacion NUMERIC(18,0) IDENTITY,  /*  chequear identity para los que se inserten despues de la migracion*/
	Puntaje TINYINT NULL,
	Descripcion NVARCHAR(255) NULL,
	
	PRIMARY KEY ( Cod_Calificacion )
)

CREATE TABLE MERCADONEGRO.Visibilidades
(
	Cod_Visibilidad NUMERIC(18,0) IDENTITY (0,1),
	Descripcion NVARCHAR(255) UNIQUE NOT NULL,
	Costo_Publicacion NUMERIC(18,2) NOT NULL,
	Porcentaje_Venta NUMERIC(18,2) NOT NULL,
	
	PRIMARY KEY ( Cod_Visibilidad )
)

CREATE TABLE MERCADONEGRO.Publicaciones
(
	Cod_Publicacion NUMERIC(18,0) IDENTITY,
	Cod_Visibilidad NUMERIC(18,0) NOT NULL, 
	ID_Vendedor NUMERIC(18,0) NOT NULL,
	Descripcion NVARCHAR(255) NOT NULL,
	Stock NUMERIC(18,0) NOT NULL,
	Fecha_Vencimiento DATETIME NOT NULL,
	Fecha_Inicial DATETIME NOT NULL,
	Precio NUMERIC(18,2) NOT NULL,
	Estado_Publicacion TINYINT NOT NULL,
	Tipo_Publicacion TINYINT NOT NULL,
	Permisos_Preguntas BIT NOT NULL,
	Stock_Inicial NUMERIC(18,0) NOT NULL,
	
	PRIMARY KEY (Cod_Publicacion),
	FOREIGN KEY (Cod_Visibilidad) REFERENCES MERCADONEGRO.Visibilidades(Cod_Visibilidad)
)

CREATE TABLE MERCADONEGRO.Facturaciones
(
	ID_Facturacion NUMERIC(18,0) IDENTITY,
	Cod_Publicacion NUMERIC(18,0) NOT NULL,
	Forma_Pago NVARCHAR(255) NOT NULL,
	Total_Facturacion NUMERIC(18,2) NOT NULL,
	
	PRIMARY KEY (ID_Facturacion),
	FOREIGN KEY (Cod_Publicacion) REFERENCES MERCADONEGRO.Publicaciones(Cod_Publicacion)
)

CREATE TABLE MERCADONEGRO.Items
(
	ID_Item NUMERIC(18,0) IDENTITY,
	ID_Facturacion NUMERIC(18,0) NOT NULL, 
	Cantidad_Vendida NUMERIC(18,0) NOT NULL,
	Descripcion NVARCHAR(255) NOT NULL, /* UNIQUE??? */
	Precio_Unitario NUMERIC(18,2) NOT NULL,
	
	PRIMARY KEY (ID_Item),
	FOREIGN KEY (ID_Facturacion) REFERENCES MERCADONEGRO.Facturaciones(ID_Facturacion)
)

CREATE TABLE MERCADONEGRO.Pregunta_Publicacion
(
	Cod_Publicacion NUMERIC(18,0),
	ID_Pregunta NUMERIC(18,0),
	
	PRIMARY KEY (Cod_Publicacion,ID_Pregunta),
	FOREIGN KEY (Cod_Publicacion) REFERENCES MERCADONEGRO.Publicaciones(Cod_Publicacion),
	FOREIGN KEY (ID_Pregunta) REFERENCES MERCADONEGRO.Preguntas(ID_Pregunta)
)

CREATE TABLE MERCADONEGRO.Rubro_Publicacion
(
	Cod_Publicacion NUMERIC(18,0),
	ID_Rubro NUMERIC(18,0),
	
	PRIMARY KEY (Cod_Publicacion, ID_Rubro),
	FOREIGN KEY (Cod_Publicacion) REFERENCES MERCADONEGRO.Publicaciones(Cod_Publicacion),
	FOREIGN KEY (ID_Rubro) REFERENCES MERCADONEGRO.Rubros(ID_Rubro)
)