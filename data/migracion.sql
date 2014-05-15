------------------------MIGRACION-----------------------------

/* MIGRANDO TABLA DE CALIFICACIONES */

PRINT 'MIGRANDO TABLA DE CALIFICACIONES';

SET IDENTITY_INSERT MERCADONEGRO.Calificaciones ON

INSERT INTO MERCADONEGRO.Calificaciones (Cod_Calificacion,Puntaje,Descripcion)
	SELECT 
			Calificacion_Codigo,
			Calificacion_Cant_Estrellas,
			Calificacion_Descripcion
	FROM gd_esquema.Maestra
	WHERE Calificacion_Codigo IS NOT NULL
	
SET IDENTITY_INSERT MERCADONEGRO.Calificaciones OFF



/* MIGRANDO TABLA DE VISIBILIDADES */

 

PRINT 'MIGRANDO TABLA DE VISIBILIDADES';

INSERT INTO MERCADONEGRO.Visibilidades(Descripcion, Costo_Publicacion, Porcentaje_Venta) 
/* NO PUSE EL CODIGO DE LA VISIBILIDAD DE LA TABLA MAESTRA */

	SELECT  DISTINCT 
					 Publicacion_Visibilidad_Desc,
					 Publicacion_Visibilidad_Precio,
					 Publicacion_Visibilidad_Porcentaje			
					 
	FROM gd_esquema.Maestra
	WHERE Publicacion_Visibilidad_Cod IS NOT NULL
	ORDER BY Publicacion_Visibilidad_Precio DESC
	


--------------------------Vistas-----------------------------


CREATE TABLE #UsuariosTemp
(
	iduser NUMERIC(18,0) IDENTITY(1,1),
	username NVARCHAR(255) NOT NULL,
	pass NVARCHAR(255) NOT NULL,
	rol int
	PRIMARY KEY (iduser)
	
)

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
	
	

SET IDENTITY_INSERT MERCADONEGRO.Usuarios ON

INSERT INTO MERCADONEGRO.Usuarios(ID_User,Username,Password,Cant_Publi_Gratuitas,Reputacion,Ventas_Sin_Rendir)
	SELECT iduser,username,pass,0,0,0
	FROM #UsuariosTemp
	
SET IDENTITY_INSERT MERCADONEGRO.Usuarios OFF
--select * from MERCADONEGRO.Usuarios order by ID_User	






/* MIGRANDO Roles_Usuario*/	

PRINT 'MIGRANDO TABLA ROLES_USUARIOS'

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
	
/* MIGRANDO TABLA CLIENTES */
--select * from MERCADONEGRO.Clientes
PRINT 'MIGRANDO TABLA CLIENTES'


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
GO
/* MIGRANDO TABLA PUBLICACIONES */

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


/* OPERACIONES */
GO
CREATE VIEW MERCADONEGRO.OperacionesVentas AS
	SELECT DISTINCT gd_esquema.Maestra.Calificacion_Codigo AS codcalific,
					MERCADONEGRO.Usuarios.ID_User AS comprador,
					MERCADONEGRO.Publicaciones.ID_Vendedor AS vendedor,
					gd_esquema.Maestra.Publicacion_Cod AS codpublic,
					gd_esquema.Maestra.Publicacion_Tipo AS tipo,
					gd_esquema.Maestra.Compra_Fecha AS fechaCompra
					
	FROM gd_esquema.Maestra, MERCADONEGRO.Usuarios, MERCADONEGRO.Publicaciones
	WHERE gd_esquema.Maestra.Publicacion_Cod = MERCADONEGRO.Publicaciones.Cod_Publicacion 
	AND MERCADONEGRO.Usuarios.Password = convert(nvarchar(255),Cli_Dni) 
	AND (Publ_Cli_Dni IS NOT NULL OR Publ_Empresa_Cuit IS NOT NULL)
	AND gd_esquema.Maestra.Calificacion_Codigo IS NOT NULL
	
--select * from MERCADONEGRO.OperacionesVentas
--drop view MERCADONEGRO.OperacionesVentas

GO
CREATE VIEW MERCADONEGRO.OperacionesOfertas AS
	SELECT DISTINCT gd_esquema.Maestra.Calificacion_Codigo AS codcalific,
					MERCADONEGRO.Usuarios.ID_User AS ofertador,
					MERCADONEGRO.Publicaciones.ID_Vendedor AS vendedor,
					gd_esquema.Maestra.Publicacion_Cod AS codpublic,
					gd_esquema.Maestra.Publicacion_Tipo AS tipo,
					gd_esquema.Maestra.Oferta_Fecha AS fechaOferta
	FROM gd_esquema.Maestra, MERCADONEGRO.Usuarios, MERCADONEGRO.Publicaciones
	WHERE gd_esquema.Maestra.Publicacion_Cod = MERCADONEGRO.Publicaciones.Cod_Publicacion
	AND MERCADONEGRO.Usuarios.Password = convert(nvarchar(255),Cli_Dni)  
	AND (Publ_Cli_Dni IS NOT NULL OR Publ_Empresa_Cuit IS NOT NULL)
	AND gd_esquema.Maestra.Calificacion_Codigo IS NULL
	AND MERCADONEGRO.Publicaciones.Tipo_Publicacion = 0
	AND gd_esquema.Maestra.Oferta_Fecha IS NOT NULL
	
	
--select * from MERCADONEGRO.OperacionesOfertas
--drop view MERCADONEGRO.OperacionesOfertas
--DROP VIEW MERCADONEGRO.OperacionesOfertas
--select * from MERCADONEGRO.Usuarios
--select Publicacion_Cod, Compra_Fecha, Compra_Cantidad,Publicacion_Precio, Calificacion_Codigo, Item_Factura_Monto, Item_Factura_Cantidad from gd_esquema.Maestra WHERE Publicacion_Cod IS NOT NULL ORDER BY Publicacion_Cod
--select Publicacion_Cod, SUM() from gd_esquema.Maestra group by Publicacion_Cod


CREATE VIEW MERCADONEGRO.ItemsView AS
	SELECT DISTINCT gd_esquema.Maestra.Item_Factura_Cantidad AS cant,
					MERCADONEGRO.Publicaciones.Descripcion   AS descripcion,
					(gd_esquema.Maestra.Publicacion_Precio * gd_esquema.Maestra.Publicacion_Visibilidad_Porcentaje)  AS precioUnitario
	FROM gd_esquema.Maestra, MERCADONEGRO.Publicaciones
	WHERE (gd_esquema.Maestra.Publicacion_Cod = MERCADONEGRO.Publicaciones.Cod_Publicacion
	AND gd_esquema.Maestra.Item_Factura_Cantidad IS NOT NULL) 
	OR (gd_esquema.Maestra.Publicacion_Cod = MERCADONEGRO.Publicaciones.Cod_Publicacion
	AND gd_esquema.Maestra.Publicacion_Visibilidad_Cod = MERCADONEGRO.Publicaciones.Cod_Visibilidad)
	
	--select * from MERCADONEGRO.ItemsView
	--drop view MERCADONEGRO.ItemsView
					
					

--CREATE VIEW MERCADONEGRO.FacturacionesView AS
--	SELECT DISTINCT MERCADONEGRO.Publicaciones.Cod_Publicacion AS codpublic,
					




GO
-----------------------------DROPS-----------------------------
DROP TABLE #UsuariosTemp

DROP VIEW MERCADONEGRO.Vista_Publicaciones
