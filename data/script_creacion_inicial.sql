USE [GD1C2014]

IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'MERCADONEGRO')
DROP SCHEMA [MERCADONEGRO]
GO

CREATE SCHEMA MERCADONEGRO AUTHORIZATION gd
GO

---------------------------------------------Tablas iniciales-------------------------------------------

CREATE TABLE MERCADONEGRO.Usuarios
(
	ID_User				 NUMERIC(18,0) IDENTITY(1,1),
	Username			 NVARCHAR(255)	   NOT NULL,
	Password			 NVARCHAR(255)	   NOT NULL,
	Intentos_Login		 TINYINT DEFAULT 0 NOT NULL, 
	Habilitado			 BIT DEFAULT 1	   NOT NULL,
	Primera_Vez			 TINYINT DEFAULT 2 NOT NULL,
	Cant_Publi_Gratuitas TINYINT		   NULL,
	Reputacion			 FLOAT			   NULL, 
	Ventas_Sin_Rendir	 TINYINT		   NULL, 
	Habilitado_Compra	 BIT DEFAULT 1	   NOT NULL,
	
	UNIQUE (Username),
	PRIMARY KEY(ID_User)
)

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
	ID_User			NUMERIC(18,0) NOT NULL,
	Pregunta		NVARCHAR(255) NOT NULL,
	Respuesta		NVARCHAR(255) NULL,
	Fecha_Respuesta DATETIME	  NULL,
	
	PRIMARY KEY ( ID_Pregunta )
)

CREATE TABLE MERCADONEGRO.Calificaciones
(
	Cod_Calificacion	NUMERIC(18,0)	IDENTITY,  
	Puntaje				NUMERIC(18,0)	NULL,
	Descripcion			NVARCHAR(255)	NULL,
	Fecha_Calificacion	DATETIME		NULL,
	
	PRIMARY KEY ( Cod_Calificacion )
)

CREATE TABLE MERCADONEGRO.Visibilidades
(
	Cod_Visibilidad   NUMERIC(18,0) IDENTITY (0,1),
	Descripcion		  NVARCHAR(255) NOT NULL,
	Costo_Publicacion NUMERIC(18,2) NOT NULL,
	Porcentaje_Venta  NUMERIC(18,2) NOT NULL,
	Habilitada		  BIT DEFAULT 1 NOT NULL,
	Jerarquia		  NUMERIC(18,0) 
	
	UNIQUE		(Descripcion),
	PRIMARY KEY ( Cod_Visibilidad )
)

CREATE TABLE MERCADONEGRO.Estados_Publicacion
(
	Cod_EstadoPublicacion NUMERIC(18,0) IDENTITY(0,1),
	Descripcion			  NVARCHAR(255) NOT NULL,
	
	PRIMARY KEY (Cod_EstadoPublicacion),
	UNIQUE		(Descripcion)
)

CREATE TABLE MERCADONEGRO.Tipos_Publicacion
(
	Cod_TipoPublicacion	NUMERIC(18,0) IDENTITY(0,1),
	Descripcion			NVARCHAR(255) NOT NULL
	
	PRIMARY KEY (Cod_TipoPublicacion),
	UNIQUE		(Descripcion)
)

CREATE TABLE MERCADONEGRO.Publicaciones
(
	Cod_Publicacion			NUMERIC(18,0) IDENTITY,
	Cod_Visibilidad			NUMERIC(18,0) NOT NULL,
	Cod_EstadoPublicacion	NUMERIC(18,0) NOT NULL,
	Cod_TipoPublicacion		NUMERIC(18,0) NOT NULL, 
	ID_Vendedor				NUMERIC(18,0) NOT NULL,
	Descripcion				NVARCHAR(255) NOT NULL,
	Stock					NUMERIC(18,0) NOT NULL,
	Fecha_Vencimiento		DATETIME	  NOT NULL,
	Fecha_Inicial			DATETIME	  NOT NULL,
	Precio					NUMERIC(18,2) NOT NULL,
	Permisos_Preguntas		BIT			  NOT NULL,
	Stock_Inicial			NUMERIC(18,0) NOT NULL,
	
	PRIMARY KEY (Cod_Publicacion),
	FOREIGN KEY (Cod_Visibilidad) REFERENCES MERCADONEGRO.Visibilidades(Cod_Visibilidad),
	FOREIGN KEY	(Cod_EstadoPublicacion) REFERENCES MERCADONEGRO.Estados_Publicacion(Cod_EstadoPublicacion),
	FOREIGN KEY (Cod_TipoPublicacion) REFERENCES MERCADONEGRO.Tipos_Publicacion(Cod_TipoPublicacion),
	FOREIGN KEY	(ID_Vendedor) REFERENCES MERCADONEGRO.Usuarios(ID_User),
)

CREATE TABLE MERCADONEGRO.Facturaciones
(
	Nro_Factura		  NUMERIC(18,0) IDENTITY,
	Forma_Pago		  NVARCHAR(255) NOT NULL,
	Total_Facturacion NUMERIC(18,2) NOT NULL,
	Factura_Fecha	  DATETIME,
	
	PRIMARY KEY (Nro_Factura)
)

CREATE TABLE MERCADONEGRO.Factura_Publicacion
(
	Cod_Publicacion	NUMERIC(18,0) NOT NULL,
	Nro_Factura		NUMERIC(18,0) NOT NULL
	
	PRIMARY KEY(Cod_Publicacion, Nro_Factura),
	FOREIGN KEY(Cod_Publicacion) REFERENCES MERCADONEGRO.Publicaciones(Cod_Publicacion),
	FOREIGN KEY(Nro_Factura)	 REFERENCES MERCADONEGRO.Facturaciones(Nro_Factura)
)

CREATE TABLE MERCADONEGRO.Items
(
	ID_Item			 NUMERIC(18,0) IDENTITY, 
	Nro_Factura		 NUMERIC(18,0) NOT NULL,
	Cod_Publicacion  NUMERIC(18,0) NOT NULL,
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

	UNIQUE		(Razon_Social), 
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
	
	UNIQUE (Tipo_Doc,Num_Doc),
	
	PRIMARY KEY (ID_User),
	FOREIGN KEY (ID_User) REFERENCES MERCADONEGRO.Usuarios(ID_User)
)

--Indice para permitir NULL insetados en migracion
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

CREATE TABLE MERCADONEGRO.Tipos_Operacion
(
	Cod_TipoOperacion	NUMERIC(18,0) IDENTITY(0,1),
	Descripcion			NVARCHAR(255) NOT NULL
	
	PRIMARY KEY (Cod_TipoOperacion),
	UNIQUE		(Descripcion)
)


CREATE TABLE MERCADONEGRO.Compras
(
	ID_Compra		NUMERIC(18,0) IDENTITY,
	ID_Vendedor			NUMERIC(18,0) NOT NULL,
	ID_Comprador		NUMERIC(18,0) NOT NULL,
	Cod_Publicacion		NUMERIC(18,0) NOT NULL,
	Cod_TipoOperacion	NUMERIC(18,0) NOT NULL,
	Cod_Calificacion	NUMERIC(18,0) NULL,
	Fecha_Operacion		DATETIME	  NOT NULL,
	Monto_Compra		NUMERIC(18,2) NOT NULL,
	Operacion_Facturada BIT DEFAULT 0 NOT NULL, 
	
	PRIMARY KEY (ID_Compra),
	FOREIGN KEY (ID_Vendedor)	  REFERENCES MERCADONEGRO.Usuarios(ID_User),
	FOREIGN KEY (ID_Comprador)	  REFERENCES MERCADONEGRO.Usuarios(ID_User),
	FOREIGN KEY (Cod_Publicacion) REFERENCES MERCADONEGRO.Publicaciones(Cod_Publicacion),
	FOREIGN KEY (Cod_Calificacion) REFERENCES MERCADONEGRO.Calificaciones(Cod_Calificacion),
	FOREIGN KEY (Cod_TipoOperacion) REFERENCES MERCADONEGRO.Tipos_Operacion(Cod_TipoOperacion)
)
GO

CREATE TABLE MERCADONEGRO.Subastas
(
	ID_Subasta			NUMERIC(18,0) IDENTITY,
	ID_Vendedor			NUMERIC(18,0) NOT NULL,
	ID_Comprador		NUMERIC(18,0) NOT NULL,
	Cod_Publicacion		NUMERIC(18,0) NOT NULL,
	Tipo_Operacion		BIT DEFAULT 1 NOT NULL,
	Fecha_Oferta		DATETIME	  NOT NULL,
	Monto_Oferta		NUMERIC(18,2) NOT NULL, 
	
	PRIMARY KEY (ID_Subasta),
	FOREIGN KEY (ID_Vendedor)	  REFERENCES MERCADONEGRO.Usuarios(ID_User),
	FOREIGN KEY (ID_Comprador)	  REFERENCES MERCADONEGRO.Usuarios(ID_User)



)
GO

CREATE TABLE MERCADONEGRO.Bonificaciones
(
	ID_Bonificacion	NUMERIC(18,0) IDENTITY(0,1), 
	ID_User		    NUMERIC(18,0) NOT NULL,
	Cantidad        NUMERIC(18,0) NOT NULL,
	Visibilidad		NUMERIC(18,0) NOT NULL,
	
	
	PRIMARY KEY (ID_Bonificacion),
	FOREIGN KEY(ID_User) REFERENCES MERCADONEGRO.Usuarios(ID_User)
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

/* SP Insertar Pregunta  */

CREATE PROCEDURE MERCADONEGRO.InsertarPregunta(@pregunta nvarchar(255), @idUser numeric (18,0), @ret numeric (18,0) output)
AS BEGIN
		INSERT INTO MERCADONEGRO.Preguntas(Pregunta, ID_User)
			VALUES(@pregunta, @idUser)
			SET @ret = SCOPE_IDENTITY()
END
GO

/* SP Insertar Pregunta_x_Publicacion  */ 

CREATE PROCEDURE MERCADONEGRO.InsertarPreguntaPorPublicacion(@codPublicacion numeric(18,0),@idPregunta nvarchar(255))
AS BEGIN
		INSERT INTO MERCADONEGRO.Pregunta_Publicacion(Cod_Publicacion, ID_Pregunta)
			VALUES(@codPublicacion,@idPregunta)
END
GO

/* SP Agregar PUBLICACION NUEVA */
											 
CREATE PROCEDURE MERCADONEGRO.AgregarPublicacion(@codVisibilidad numeric(18,0), @idVendedor numeric(18,0),
												 @descripcion nvarchar(255), @stock numeric(18,0),
												 @fechaInic datetime, @fechaVenc datetime,
												 @precio numeric(18,2), @estadoPubl NUMERIC(18,0), @tipoPubl NUMERIC(18,0),
												 @permisosPreg bit,
												 @ret numeric (18,0) output)
AS BEGIN
		INSERT INTO MERCADONEGRO.Publicaciones(Cod_Visibilidad, ID_Vendedor, Descripcion, Stock, Fecha_Inicial,
												Fecha_Vencimiento, Precio, Cod_EstadoPublicacion, Permisos_Preguntas,
												Cod_TipoPublicacion, Stock_Inicial)
			VALUES(@codVisibilidad, @idVendedor, @descripcion, @stock, @fechaInic, @fechaVenc, @precio, @estadoPubl,
				   @permisosPreg, @tipoPubl, @stock)
				   SET @ret = SCOPE_IDENTITY()
END
GO

/* Obtener Vista de las Compras sin facturar order by fecha de operacion */

CREATE PROCEDURE MERCADONEGRO.ObtenerComprasSinFacturar(@username nvarchar(255))
AS BEGIN
		SELECT [Fecha de la Operacion], Venta AS [Venta Nro], Publicacion AS [Publicacion Nro], Descripcion  
			FROM MERCADONEGRO.ComprasSinFacturar
			WHERE @username = Username
			ORDER BY [Fecha de la Operacion]
END
GO

/* Agrega una calificacion para la compra realizada, devuelve el codCalific */

CREATE PROCEDURE MERCADONEGRO.AgregarCalificacion (@codCalificacion numeric(18,0) output )
AS BEGIN
		INSERT INTO MERCADONEGRO.Calificaciones (Puntaje,Descripcion,Fecha_Calificacion)
		VALUES (NULL, NULL, NULL)
		SET @codCalificacion = SCOPE_IDENTITY()
END
GO

/* Update de la calificacion (Calificar Vendedor), ACTIVA TRIGGER */

CREATE PROCEDURE MERCADONEGRO.UpdateCalificacion (@codCalificacion numeric(18,0), @puntaje numeric(18,0),
												  @descripcion nvarchar(255), @fecha datetime)
AS BEGIN
		UPDATE MERCADONEGRO.Calificaciones
		SET Puntaje = @puntaje, Descripcion = @descripcion, Fecha_Calificacion = @fecha
		WHERE Cod_Calificacion = @codCalificacion
END
GO

/* Agregar oferta */

CREATE PROCEDURE MERCADONEGRO.InsertarOFerta ( @idComprador numeric (18,0), @idVendedor numeric (18,0), @codPublicacion numeric (18,0), 
											   @tipoOperacion bit, @fechaOferta datetime, @montoOferta numeric (18,2) )
AS BEGIN
		INSERT INTO MERCADONEGRO.Subastas (ID_Vendedor,ID_Comprador,Cod_Publicacion, Tipo_Operacion, Fecha_Oferta, Monto_Oferta)
		VALUES ( @idVendedor, @idComprador, @codPublicacion,@tipoOperacion,@fechaOferta, @montoOferta )
END
GO

/* Agregar Visibilidad */

CREATE PROCEDURE MERCADONEGRO.AgregarVisibilidad(@descripcion nvarchar(255), @costoPublicacion numeric(18,2), 
												 @porcentajeVenta numeric(18,2), @habilitada bit, @ret numeric(18,0) output)
AS BEGIN
	INSERT INTO MERCADONEGRO.Visibilidades(Descripcion, Costo_Publicacion, Porcentaje_Venta, Habilitada)
	VALUES (@descripcion, @costoPublicacion, @porcentajeVenta, @habilitada)
	SET @ret = SCOPE_IDENTITY();
END
GO

/* SP Editar Visibilidad */

CREATE PROCEDURE MERCADONEGRO.EditarVisibilidad(@descripcion nvarchar(255), @costoPublicacion numeric(18,2), 
												@porcentajeVenta numeric(18,2), @habilitada bit,@descripcionVieja nvarchar(255))
AS BEGIN
	UPDATE MERCADONEGRO.Visibilidades 
		SET Descripcion = @descripcion, Costo_Publicacion = @costoPublicacion, Porcentaje_Venta = @porcentajeVenta,
			Habilitada = @habilitada
			WHERE Descripcion = @descripcionVieja
END
GO

/* SP Editar Jerarquia de la Visibilidad */

CREATE PROCEDURE MERCADONEGRO.EditarJerarquia (@jerarquia numeric(18,0), @descripcionVieja nvarchar(255))
AS BEGIN
	UPDATE MERCADONEGRO.Visibilidades 
		SET Jerarquia = @jerarquia
			WHERE Descripcion = @descripcionVieja
END
GO

/* Trigger para insertar la jerarquia a la visibilidad */

CREATE TRIGGER MERCADONEGRO.Trigger_MigracionVisibilidades
ON MERCADONEGRO.Visibilidades
AFTER INSERT
 AS BEGIN

	DECLARE @idInsertada numeric(18,0);

	DECLARE trigger_cursor CURSOR FOR
	SELECT Cod_visibilidad FROM MERCADONEGRO.Visibilidades
	ORDER BY Cod_Visibilidad;

	OPEN trigger_cursor;
	
	FETCH NEXT FROM trigger_cursor
	INTO @idInsertada

	WHILE @@FETCH_STATUS = 0
	BEGIN
	
	UPDATE MERCADONEGRO.Visibilidades   
		SET Jerarquia = @idInsertada
		WHERE MERCADONEGRO.Visibilidades.Cod_Visibilidad = @idInsertada	
   FETCH NEXT FROM trigger_cursor
	INTO @idInsertada
	END

CLOSE trigger_cursor;
DEALLOCATE trigger_cursor;
END
GO

/* SP Crear Factura */

CREATE PROCEDURE MERCADONEGRO.crearFactura(@formaDePago nvarchar(255), @fechaFactura datetime,
											 @ret numeric(18,0) output)
AS BEGIN
	INSERT INTO MERCADONEGRO.Facturaciones(Forma_Pago, Factura_Fecha, Total_Facturacion)
		VALUES(@formaDePago, @fechaFactura, 0)
		SET @ret = SCOPE_IDENTITY()
END
GO

/* SP para obtener historiales paginados*/

CREATE PROCEDURE MERCADONEGRO.pObtenerCompras
	@pagina INT,
	@ID_User NUMERIC(18,0)
AS
	SELECT * FROM (
		SELECT ID_Vendedor, Cod_Publicacion, Cod_Calificacion, Fecha_Operacion, ROW_NUMBER() OVER(ORDER BY Fecha_Operacion ASC) AS ROW_NUMBER
		FROM MERCADONEGRO.Compras
		WHERE ID_Comprador = @ID_User
		AND Cod_TipoOperacion = 0
	) AS T
	WHERE
		ROW_NUMBER BETWEEN ((@pagina) + (9*(@pagina-1))) AND ((@pagina) + (9*(@pagina-1))) + 9
	ORDER BY Fecha_Operacion
GO

CREATE PROCEDURE MERCADONEGRO.pObtenerOfertasGanadas
	@pagina INT,
	@ID_User NUMERIC(18,0)
AS
	SELECT * FROM (
		SELECT ID_Vendedor, Cod_Publicacion, Cod_Calificacion, Fecha_Operacion, ROW_NUMBER() OVER(ORDER BY Fecha_Operacion ASC) AS ROW_NUMBER
		FROM MERCADONEGRO.Compras
		WHERE ID_Comprador = @ID_User
		AND Cod_TipoOperacion = 1
	) AS T
	WHERE
		ROW_NUMBER BETWEEN ((@pagina) + (9*(@pagina-1))) AND ((@pagina) + (9*(@pagina-1))) + 9
	ORDER BY Fecha_Operacion
GO

CREATE PROCEDURE MERCADONEGRO.pObtenerOfertas
	@pagina INT,
	@ID_User NUMERIC(18,0)
AS
	SELECT * FROM (
		SELECT ID_Vendedor, Cod_Publicacion, Fecha_Oferta, Monto_Oferta, ROW_NUMBER() OVER(ORDER BY Fecha_Oferta ASC) AS ROW_NUMBER
		FROM MERCADONEGRO.Subastas
		WHERE ID_Comprador = @ID_User
	) AS T
	WHERE
		ROW_NUMBER BETWEEN ((@pagina) + (9*(@pagina-1))) AND ((@pagina) + (9*(@pagina-1))) + 9
	ORDER BY Fecha_Oferta
GO

/* SP varios*/

CREATE PROCEDURE MERCADONEGRO.obtenerCompras
	@ID_User NUMERIC(18,0)
AS
	SELECT ID_Vendedor, Cod_Publicacion, Cod_Calificacion, Fecha_Operacion 
	FROM MERCADONEGRO.Compras WHERE ID_Comprador = @ID_User AND Cod_TipoOperacion = 0
GO

CREATE PROCEDURE MERCADONEGRO.obtenerOfertasGanadas
	@ID_User NUMERIC(18,0)
AS
	SELECT ID_Vendedor, Cod_Publicacion, Cod_Calificacion, Fecha_Operacion 
	FROM MERCADONEGRO.Compras WHERE ID_Comprador = @ID_User AND Cod_TipoOperacion = 1
GO

CREATE PROCEDURE MERCADONEGRO.obtenerOfertas
	@ID_User NUMERIC(18,0)
AS
	SELECT ID_Vendedor, Cod_Publicacion, Fecha_Oferta, Monto_Oferta 
	FROM MERCADONEGRO.Subastas WHERE ID_Comprador = @ID_User
GO

CREATE PROCEDURE MERCADONEGRO.eliminarRubro
	@ID_Rubro NUMERIC(18,0)
AS
	UPDATE MERCADONEGRO.Rubro_Publicacion SET ID_Rubro = 1 WHERE ID_Rubro = @ID_Rubro
	DELETE FROM MERCADONEGRO.Rubros WHERE ID_Rubro = @ID_Rubro
GO

CREATE PROCEDURE MERCADONEGRO.obtenerVendedor
	@ID_Vendedor NUMERIC(18,0)
AS
	SELECT Username FROM MERCADONEGRO.Usuarios WHERE ID_User = @ID_Vendedor
GO

CREATE PROCEDURE MERCADONEGRO.obtenerPublicacion
	@Cod_Publicacion NUMERIC(18,0)
AS
	SELECT Descripcion FROM MERCADONEGRO.Publicaciones WHERE Cod_Publicacion = @Cod_Publicacion
GO

CREATE PROCEDURE MERCADONEGRO.obtenerCalificacion
	@Cod_Calificacion NUMERIC(18,0)
AS
	SELECT Puntaje, Descripcion FROM MERCADONEGRO.Calificaciones WHERE Cod_Calificacion = @Cod_Calificacion
GO

/* Insert Item */

CREATE PROCEDURE MERCADONEGRO.InsertarItem (@codPublicacion numeric(18,0), @idFactura numeric(18,0),
											@cantidadVendida numeric(18,0), @descripcion nvarchar(255), 
											@precioItem numeric(18,0))
AS BEGIN
	INSERT INTO MERCADONEGRO.Items(Cod_Publicacion, Nro_Factura, Cantidad_Vendida, Descripcion, Precio_Item)
		VALUES(@codPublicacion, @idFactura, @cantidadVendida, @descripcion, @precioItem)
		
	UPDATE MERCADONEGRO.Facturaciones SET Total_Facturacion = Total_Facturacion + @precioItem
	
END
GO

/* Insert registro bonificacion usuario visibilidad */

CREATE PROCEDURE MERCADONEGRO.InsertarBonificacionUsuarioVisibilidad(@idVendedor numeric(18,0), @visibilidad numeric(18,0), @ret numeric(18,0) output)
AS BEGIN
	INSERT INTO MERCADONEGRO.Bonificaciones(ID_User,Cantidad,Visibilidad)
	VALUES (@idVendedor,0,@visibilidad)
	SET @ret = SCOPE_IDENTITY();
END
GO

/* Sumar 1 a bonificacin (por venta facturada) */

CREATE PROCEDURE MERCADONEGRO.SumarCantidadBonificacion ( @idBonificacion numeric (18,0))
AS BEGIN
		UPDATE  MERCADONEGRO.Bonificaciones 
		SET Cantidad = Cantidad + 1 
		WHERE ID_Bonificacion = @idBonificacion
END
GO

----------------------------------------------------Datos Iniciales-----------------------------------------------

PRINT 'Creando valores por defecto...'


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
INSERT INTO MERCADONEGRO.Funcionalidades (Nombre) VALUES ('HistorialCompras');
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
	@rol = 'Administrador General', @func = 'HistorialCompras';	
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
	@rol = 'Cliente', @func = 'GestionarPreguntas';	
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Cliente', @func = 'ComprarOfertar';		
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Cliente', @func = 'Calificar';
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Cliente', @func = 'HistorialCompras';
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
	@rol = 'Empresa', @func = 'GestionarPreguntas';			
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Empresa', @func = 'ComprarOfertar';		
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Empresa', @func = 'Calificar';
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Empresa', @func = 'HistorialCompras';
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Empresa', @func = 'Facturar';
EXEC MERCADONEGRO.AgregarFuncionalidad
	@rol = 'Empresa', @func = 'ListadoEstadistico';
		

----------------- /*AGREGANDO USUARIOS INICIALES*/ ------------------------

SET IDENTITY_INSERT MERCADONEGRO.Usuarios ON
INSERT INTO MERCADONEGRO.Usuarios(ID_User,Username,Password,Intentos_Login,Habilitado,Primera_Vez,Cant_Publi_Gratuitas,Reputacion,Ventas_Sin_Rendir) 
	VALUES (0,'admin','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',0,1,0,0,0,0);
SET IDENTITY_INSERT MERCADONEGRO.Usuarios OFF

EXEC MERCADONEGRO.AgregarRol
	@iduser = 0, @idrol = 0;

GO
-------------------/*AGREGANDO ESTADOS DE PUBLICACION*/-------------------------

INSERT INTO MERCADONEGRO.Estados_Publicacion VALUES ('Borrador');
INSERT INTO MERCADONEGRO.Estados_Publicacion VALUES ('Publicada');
INSERT INTO MERCADONEGRO.Estados_Publicacion VALUES ('Pausada');
INSERT INTO MERCADONEGRO.Estados_Publicacion VALUES ('Finalizada');

GO

---------------------/*AGREGANDO TIPOS DE PUBLICACION*/--------------------------

INSERT INTO MERCADONEGRO.Tipos_Publicacion VALUES('Subasta');
INSERT INTO MERCADONEGRO.Tipos_Publicacion VALUES('Compra Inmediata');

GO

--------------------/*AGREGANDO TIPOS DE OPERACION*/----------------------------

INSERT INTO MERCADONEGRO.Tipos_Operacion VALUES('Oferta');
INSERT INTO	MERCADONEGRO.Tipos_Operacion VALUES('Compra');

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
GO

-------------------------MIGRANDO TABLA DE VISIBILIDADES---------------------------

PRINT 'MIGRANDO TABLA DE VISIBILIDADES';
GO
INSERT INTO MERCADONEGRO.Visibilidades(Descripcion, Costo_Publicacion, Porcentaje_Venta, Habilitada) 

	SELECT  DISTINCT 
					 Publicacion_Visibilidad_Desc,
					 Publicacion_Visibilidad_Precio,
					 Publicacion_Visibilidad_Porcentaje,
					 1
					 
				
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
			INNER JOIN MERCADONEGRO.Factura_Publicacion AS Asociativa
					ON Publicaciones.Cod_Publicacion = Asociativa.Cod_Publicacion
			INNER JOIN MERCADONEGRO.Facturaciones AS Facturaciones 
					ON Asociativa.Nro_Factura = Facturaciones.Nro_Factura
	      WHERE Facturaciones.Total_Facturacion != 0
			GROUP BY Usuarios.Username, MONTH(Facturaciones.Factura_Fecha), YEAR(Facturaciones.Factura_Fecha)
	      			
GO	

------VENDEDORES CON MAYOR REPUTACION---------

CREATE VIEW MERCADONEGRO.MayorReputacionView AS
	
	SELECT Usuarios.Username							AS Vendedor,
		   Calificaciones.Puntaje						AS Puntaje,
		   MONTH(Calificaciones.Fecha_Calificacion)		AS Mes,
		   YEAR(Calificaciones.Fecha_Calificacion)		AS Año	   
			
		FROM MERCADONEGRO.Usuarios					AS Usuarios
		JOIN MERCADONEGRO.Compras				AS Compras
			ON Compras.ID_Vendedor = Usuarios.ID_User
		JOIN MERCADONEGRO.Calificaciones			AS Calificaciones
			ON Calificaciones.Cod_Calificacion = Compras.Cod_Calificacion
GO

--------CLIENTES CON MAYOR CANTIDAD DE PUBLICACIONES SIN CALIFICAR-------------

CREATE VIEW MERCADONEGRO.MayorPublicacionesSinCalificarView AS
	
	SELECT Usuarios.Username					AS Cliente,
		   COUNT(*)		AS [Publicaciones sin calificar],
		   MONTH(Compras.Fecha_Operacion)   AS Mes,
		   YEAR(Compras.Fecha_Operacion)	AS Año
		   
		FROM MERCADONEGRO.Clientes
		JOIN MERCADONEGRO.Usuarios 
			ON Clientes.ID_User = Usuarios.ID_User
		JOIN MERCADONEGRO.Compras 
			ON Compras.ID_Comprador = Usuarios.ID_User
		JOIN MERCADONEGRO.Calificaciones 
			ON Compras.Cod_Calificacion = Calificaciones.Cod_Calificacion
		WHERE Calificaciones.Puntaje IS NULL
		GROUP BY Usuarios.Username, MONTH(Compras.Fecha_Operacion), YEAR(Compras.Fecha_Operacion)
GO
		   	
---------VENDEDORES CON MAYOR CANTIDAD DE PRODUCTOS NO VENDIDOS----------

CREATE VIEW MERCADONEGRO.MayorCantProductosNoVendidos AS

	SELECT	Usuarios.Username					AS Username,
			Publicaciones.Cod_Publicacion		AS [Codigo Publicacion],
			Visibilidades.Jerarquia				AS Jerarquia,
			Visibilidades.Descripcion			AS Descripcion,
			Publicaciones.Stock					AS Stock,
			MONTH(Publicaciones.Fecha_Inicial)	AS Mes,
			YEAR(Publicaciones.Fecha_Inicial)	AS Año
			
	
			FROM MERCADONEGRO.Usuarios		AS Usuarios
			JOIN MERCADONEGRO.Publicaciones AS Publicaciones
				ON Usuarios.ID_User = Publicaciones.ID_Vendedor
			JOIN MERCADONEGRO.Visibilidades AS Visibilidades
				ON Publicaciones.Cod_Visibilidad = Visibilidades.Cod_Visibilidad
GO	

-------------------------------VISTA DE LAS Compras QUE NO FUERON FACTURADAS------------------------

CREATE VIEW MERCADONEGRO.ComprasSinFacturar AS 
	SELECT  Username						 AS Username,
			ID_Compra					 AS Venta,
			Publicaciones.Cod_Publicacion	 AS Publicacion,
			Descripcion						 AS Descripcion,
			Fecha_Operacion					 AS [Fecha de la Operacion]
			
	FROM MERCADONEGRO.Compras
	JOIN MERCADONEGRO.Publicaciones ON Publicaciones.Cod_Publicacion = Compras.Cod_Publicacion
	JOIN MERCADONEGRO.Usuarios ON Usuarios.ID_User = Compras.ID_Vendedor
	WHERE Compras.Operacion_Facturada = 0
	
GO

-------------------------------VISTA PARA VER LAS RESPUESTA A PRGUNTAS DEL USUARIO-----------------------

CREATE VIEW MERCADONEGRO.VerRespuestasView AS 

	SELECT  u.ID_User						  AS ID_User,
			u.Username						  AS Username,
			pub.Descripcion					  AS Descripcion_Publ,
			pub.Precio						  AS Precio,
			p.Pregunta   					  AS Pregunta,
			p.Respuesta						  AS Respuesta,
			p.Fecha_Respuesta				  AS Fecha_Respuesta
								 
	FROM MERCADONEGRO.Preguntas p
	JOIN MERCADONEGRO.Pregunta_Publicacion pp ON p.ID_Pregunta       = pp.ID_Pregunta
    JOIN MERCADONEGRO.Publicaciones pub       ON pub.Cod_Publicacion = pp.Cod_Publicacion 
    JOIN MERCADONEGRO.Usuarios u		      ON u.ID_User           = p.ID_User
	
	WHERE p.Respuesta IS NOT NULL
	
GO

---------------------------USUARIOS------------------------------

PRINT 'MIGRANDO TABLAS USUARIOS'

SET IDENTITY_INSERT MERCADONEGRO.Usuarios ON

INSERT INTO MERCADONEGRO.Usuarios(ID_User,Username,Password,Cant_Publi_Gratuitas,Reputacion,Ventas_Sin_Rendir)
	SELECT iduser,username,pass,0,0,0
	FROM #UsuariosTemp
	
SET IDENTITY_INSERT MERCADONEGRO.Usuarios OFF

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

-----------------UPDATE DE REPUTACION------------------------------

DECLARE @Iduser numeric(18,0), @Promedio float;

DECLARE contact_cursor CURSOR FOR
SELECT iduser,promedio FROM MERCADONEGRO.CalificacionView
ORDER BY iduser;

OPEN contact_cursor;

FETCH NEXT FROM contact_cursor
INTO @Iduser, @Promedio;

WHILE @@FETCH_STATUS = 0
BEGIN
   
   UPDATE MERCADONEGRO.Usuarios
   SET Reputacion = @Promedio
		WHERE MERCADONEGRO.Usuarios.ID_User = @Iduser	
   FETCH NEXT FROM contact_cursor
	INTO @Iduser, @Promedio;
END

CLOSE contact_cursor;
DEALLOCATE contact_cursor;
GO

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

	
-----------------------MIGRANDO TABLA CLIENTES-------------------------

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
	WHERE Publ_Empresa_Cuit  IS NOT NULL AND (#UsuariosTemp.username = 'RazonSocialNro'+ SUBSTRING(Publ_Empresa_Razon_Social,17,2))
	

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
		3 AS Publicacion_Estado, --Publicacion_estado(Todas estan publicadas => 1)
		CASE Publicacion_Tipo WHEN 'Subasta' THEN 0
							  WHEN 'Compra Inmediata' THEN 1
		END AS Publicacion_Tipo, 
		1 AS Permisos_Preguntas
					
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
		3 AS Publicacion_Estado, --Publicacion_estado(Todas estan publicadas => 1)
		CASE Publicacion_Tipo WHEN 'Subasta' THEN 0
							  WHEN 'Compra Inmediata' THEN 1
		END AS Publicacion_Tipo, 
		1 AS Permisos_Preguntas
					
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
										Cod_EstadoPublicacion, 
										Cod_TipoPublicacion, 
										Permisos_Preguntas,
										Stock_Inicial)
										
	SELECT Publicacion_Cod, Cod_Visibilidad, ID_User, Publicacion_Descripcion, Publicacion_Stock, Publicacion_Fecha, Publicacion_Fecha_Venc,
			 Publicacion_Precio, Publicacion_Estado, Publicacion_Tipo, Permisos_Preguntas,Publicacion_Stock
									
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

INSERT INTO MERCADONEGRO.Facturaciones(Nro_Factura, Forma_Pago, Total_Facturacion, Factura_Fecha)
	SELECT DISTINCT Factura_Nro, 
					Forma_Pago_Desc, 
					Factura_Total,
					Factura_Fecha
				
	FROM gd_esquema.Maestra
		WHERE gd_esquema.Maestra.Factura_Nro IS NOT NULL
	

SET IDENTITY_INSERT MERCADONEGRO.Facturaciones OFF
GO

-----------------------ITEMS-------------------------------------

PRINT 'MIGRANDO LA TABLA ITEMS'
GO

INSERT INTO MERCADONEGRO.Items(Nro_Factura, Cod_Publicacion, Cantidad_Vendida, Descripcion, Precio_Item)
		SELECT Nro_Factura, 
			   Publicacion_Cod,
			   Item_Factura_Cantidad, 
			   Publicacion_Descripcion,
			   Item_Factura_Monto
			   
		 
		 FROM MERCADONEGRO.Facturaciones, gd_esquema.Maestra
			WHERE MERCADONEGRO.Facturaciones.Nro_Factura = gd_esquema.Maestra.Factura_Nro
GO

PRINT 'MIGRANDO LA TABLA Facturacion_Publicacion'
GO

INSERT INTO MERCADONEGRO.Factura_Publicacion(Nro_Factura, Cod_Publicacion)
	 SELECT DISTINCT Nro_Factura, Cod_Publicacion
	  FROM MERCADONEGRO.Items
GO
	

-------------------------Compras-------------------------------------------------

PRINT 'MIGRANDO LAS COMPRAS'
GO

INSERT INTO MERCADONEGRO.Compras

	SELECT DISTINCT MERCADONEGRO.Publicaciones.ID_Vendedor,	
					MERCADONEGRO.Usuarios.ID_User,			
					Publicacion_Cod,						 
					Cod_TipoPublicacion,						
					Calificacion_Codigo,					
					Compra_Fecha,							
					Publicacion_Precio,
					1										
					
	FROM gd_esquema.Maestra, MERCADONEGRO.Usuarios, MERCADONEGRO.Publicaciones
	
	WHERE gd_esquema.Maestra.Calificacion_Codigo IS NOT NULL
	AND gd_esquema.Maestra.Compra_Fecha IS NOT NULL
	AND gd_esquema.Maestra.Publicacion_Tipo = 'Compra Inmediata'
	AND (Publ_Cli_Dni IS NOT NULL OR Publ_Empresa_Cuit IS NOT NULL)
	AND	gd_esquema.Maestra.Publicacion_Cod = MERCADONEGRO.Publicaciones.Cod_Publicacion 
	AND MERCADONEGRO.Usuarios.Password = convert(nvarchar(255),Cli_Dni)
	
GO

CREATE VIEW MERCADONEGRO.SubastasView AS

	SELECT DISTINCT MERCADONEGRO.Publicaciones.ID_Vendedor  AS vendedor,
					MERCADONEGRO.Usuarios.ID_User			AS ofertador,
					Publicacion_Cod							AS codpublic,
					0/*Oferta*/								AS tipo,
					Calificacion_Codigo						AS codcalific,
					Oferta_Fecha							AS fechaOferta,
					Oferta_Monto							AS monto,
					CASE 
					WHEN 
					gd_esquema.Maestra.Compra_Fecha IS NULL
					THEN 0
					WHEN gd_esquema.Maestra.Compra_Fecha IS NOT NULL
					THEN 1
					END									 AS ganoSubasta
					
	FROM gd_esquema.Maestra, MERCADONEGRO.Usuarios, MERCADONEGRO.Publicaciones
	
	WHERE gd_esquema.Maestra.Calificacion_Codigo IS NULL
	AND MERCADONEGRO.Publicaciones.Cod_TipoPublicacion = 0
	AND (Publ_Cli_Dni IS NOT NULL OR Publ_Empresa_Cuit IS NOT NULL)
	AND	gd_esquema.Maestra.Publicacion_Cod = MERCADONEGRO.Publicaciones.Cod_Publicacion
	AND MERCADONEGRO.Usuarios.Password = convert(nvarchar(255),Cli_Dni)  	
	
GO	
	
---------------MIGRANDO SUBASTAS---------------------------

PRINT 'MIGRANDO LA TABLA SUBASTAS'
GO

INSERT INTO MERCADONEGRO.Subastas(ID_Vendedor, ID_Comprador, Cod_Publicacion, Tipo_Operacion,
									Fecha_Oferta, Monto_Oferta)
	SELECT vendedor, ofertador, codpublic, tipo, fechaOferta, monto
		 FROM MERCADONEGRO.SubastasView
		WHERE ganoSubasta = 0

GO

INSERT INTO MERCADONEGRO.Compras(ID_Vendedor, ID_Comprador, Cod_Publicacion, Cod_TipoOperacion,
									Cod_Calificacion, Fecha_Operacion, Monto_Compra, Operacion_Facturada)
	 
	SELECT S1.vendedor, S1.ofertador, S1.codpublic, S1.tipo, Calificacion_Codigo, S1.fechaOferta, MAX(s1.monto), 1
		FROM MERCADONEGRO.SubastasView S1 
		JOIN MERCADONEGRO.SubastasView S2 ON S1.codpublic = S2.codpublic --Mismo codigo de publicacion
		JOIN gd_esquema.Maestra ON S1.codpublic = gd_esquema.Maestra.Publicacion_Cod
		
			WHERE S1.ofertador = S2.ofertador --Mismo Ofertador
			AND S1.ganoSubasta = 0 AND S2.ganoSubasta = 1 --Que ese ofertador haya ganado
			AND gd_esquema.Maestra.Calificacion_Codigo IS NOT NULL --Para la calificacion
		GROUP BY S1.vendedor, S1.ofertador, S1.codpublic, s1.tipo, s1.fechaOferta, Calificacion_Codigo


-----------------------------DROPS-----------------------------

DROP TABLE #UsuariosTemp
GO
DROP VIEW MERCADONEGRO.Vista_Publicaciones
GO
DROP VIEW MERCADONEGRO.SubastasView
GO
DROP VIEW MERCADONEGRO.CalificacionView
GO

---------------------TRIGGERS POST MIGRACION-----------------

/* TRIGGER para las compras: inserta calificacion vacia, recibe su cod_calific, con eso inserta una nueva compra en Compras
con fecha actual, y luego updatea el stock de la publicacion corespondiente */

CREATE TRIGGER Trigger_InsertarCompra
	ON MERCADONEGRO.Compras
	INSTEAD OF INSERT
	AS BEGIN
	
	DECLARE @codCalificacion numeric(18,0)
	exec MERCADONEGRO.AgregarCalificacion @codCalificacion output 
	
	declare @idVendedor numeric(18,0), @idComprador numeric(18,0), @codPublicacion numeric(18,0), @tipoOperacion NUMERIC(18,0),
			@montoCompra numeric(18,2), @operacionFacturada bit, @fechaCompra DATETIME
			
	select @idVendedor = i.ID_Vendedor, @idComprador = i.ID_Comprador, @codPublicacion = i.Cod_Publicacion, 
		   @tipoOperacion = i.Cod_TipoOperacion, @montoCompra = i.Monto_Compra, @operacionFacturada = i.Operacion_Facturada, @fechaCompra = i.Fecha_Operacion
	from inserted i
	
	INSERT INTO MERCADONEGRO.Compras (ID_Vendedor, ID_Comprador, Cod_Publicacion, Cod_TipoOperacion,
											Cod_calificacion, Fecha_Operacion, Monto_Compra, Operacion_Facturada)
	VALUES ( @idVendedor , @idComprador , @codPublicacion , @tipoOperacion , @codCalificacion ,
			 @fechaCompra, @montoCompra , @operacionFacturada )
	
	UPDATE MERCADONEGRO.Publicaciones SET Stock = Stock - 1 WHERE Cod_Publicacion = @codPublicacion
	
	END 
GO

/* Trigger para actualizar reputacion after recibir calificacion*/

CREATE TRIGGER Trigger_UpdateCalificacion
	ON MERCADONEGRO.Calificaciones
	AFTER UPDATE
	AS BEGIN
	
	DECLARE @codCalificacion numeric(18,0), @puntaje numeric(18,0), @descripcion nvarchar(255), @fecha datetime
	SELECT @codCalificacion = Cod_Calificacion, @puntaje = Puntaje, @descripcion = Descripcion , @fecha = Fecha_Calificacion
	FROM inserted
		
	DECLARE @idUser numeric (18,0) = (SELECT ID_Vendedor FROM MERCADONEGRO.Compras WHERE Cod_Calificacion = @codCalificacion)
	
	DECLARE @promedio float = 
	(
	SELECT  	
			AVG(c.Puntaje)		
			
	FROM MERCADONEGRO.Usuarios u     
	JOIN MERCADONEGRO.Compras o    ON o.ID_Vendedor = u.ID_User 
	JOIN MERCADONEGRO.Calificaciones c ON c.Cod_Calificacion = o.Cod_Calificacion
	
	WHERE u.ID_User = @idUser
	GROUP BY u.ID_User 
	)
	
	UPDATE MERCADONEGRO.Usuarios SET Reputacion = @promedio WHERE ID_User = @idUser
			
	END 
GO


-----------------------------FIN SCRIPT INICIAL---------------------------------

--Drops de vistas que SI tienen que estar en el sistema
/*
DROP VIEW MERCADONEGRO.MayorCantProductosNoVendidos
GO
DROP VIEW MERCADONEGRO.MayorFacturacionView
GO
DROP VIEW MERCADONEGRO.MayorReputacionView
GO
DROP VIEW MERCADONEGRO.ComprasSinFacturar
GO
DROP VIEW MERCADONEGRO.MayorPublicacionesSinCalificarView
GO
DROP VIEW MERCADONEGRO.VerRespuestasView
GO
*/

