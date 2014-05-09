USE [GD1C2014]

IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'MERCADONEGRO')
DROP SCHEMA [MERCADONEGRO]
GO

CREATE SCHEMA MERCADONEGRO AUTHORIZATION gd
GO

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

 

PRINT 'MIGRANDO TABLA DE CALIFICACIONES';

INSERT INTO MERCADONEGRO.Visibilidades(Descripcion, Costo_Publicacion, Porcentaje_Venta) /* NO PUSE EL CODIGO DE LA VISIBILIDAD DE LA TABLA MAESTRA */

	SELECT  DISTINCT Publicacion_Visibilidad_Desc,
					 Publicacion_Visibilidad_Precio,
					 Publicacion_Visibilidad_Porcentaje			
					 
	FROM gd_esquema.Maestra
	WHERE Publicacion_Visibilidad_Cod IS NOT NULL
	ORDER BY Publicacion_Visibilidad_Precio DESC


			

/* MIGRANDO TABLA PUBLICACIONES */

PRINT 'MIGRANDO TABLA PUBLICACIONES'

-------------DE LOS CLIENTES------------

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
										
	SELECT DISTINCT Publicacion_Cod, 
					Publicacion_Visibilidad_Cod - 10002,
					Publ_Cli_Apeliido + Publ_Cli_Nombre,
					Publicacion_Descripcion,
					Publicacion_Stock,
					Publicacion_Fecha,
					Publicacion_Fecha_Venc,
					Publicacion_Precio, 
					CASE Publicacion_Estado
						WHEN 'Publicada' THEN 0
						END, 
					CASE Publicacion_Tipo
						WHEN 'Compra Inmediata' THEN 0
						WHEN 'Subasta' THEN 1
						END, 
					0, --Permiso de preguntas (cambiar esto si es necesario)
					Publicacion_Stock
	FROM	gd_esquema.Maestra
	WHERE	Publicacion_Cod IS NOT NULL AND Publ_Cli_Dni IS NOT NULL
	
SET IDENTITY_INSERT MERCADONEGRO.Publicaciones OFF

/*----------DE LAS EMPRESAS-------------

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
										
	SELECT DISTINCT Publicacion_Cod, 
					Publicacion_Visibilidad_Cod - 10002,
					Publ_Em
					Publicacion_Descripcion,
					Publicacion_Stock,
					Publicacion_Fecha,
					Publicacion_Fecha_Venc,
					Publicacion_Precio, 
					CASE Publicacion_Estado
						WHEN 'Publicada' THEN 0
						END, 
					CASE Publicacion_Tipo
						WHEN 'Compra Inmediata' THEN 0
						WHEN 'Subasta' THEN 1
						END, 
					0, --Permiso de preguntas (cambiar esto si es necesario)
					Publicacion_Stock
	FROM	gd_esquema.Maestra
	WHERE	Publicacion_Cod IS NOT NULL AND Publ_Cli_Dni IS NOT NULL
	
SET IDENTITY_INSERT MERCADONEGRO.Publicaciones OFF*/