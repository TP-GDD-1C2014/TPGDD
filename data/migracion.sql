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

/*MIGRANDO TABLA USUARIOS */

PRINT 'MIGRANDO TABLA DE USUARIOS'

INSERT INTO MERCADONEGRO.Usuarios(Username,Password,Intentos_Login,Habilitado,Primera_Vez,Cant_Publi_Gratuitas,Reputacion,Ventas_Sin_Rendir)

	SELECT DISTINCT
					/*De esta manera podra generar un username y password acorde para tanto clientes como empresas*/
					CASE WHEN Publ_Empresa_Cuit IS NULL 
						 
						 THEN CASE WHEN Cli_Dni IS NULL
								   THEN (Publ_Cli_Apeliido+Publ_Cli_Nombre)
							       WHEN Cli_Dni IS NOT NULL
							       THEN Cli_Apeliido+Cli_Nombre
						      END
						  
						 WHEN Publ_Empresa_Cuit IS NOT NULL  
						 THEN Publ_Empresa_Razon_Social
					END,
					CASE WHEN Publ_Empresa_Cuit IS NULL 
						 THEN CASE WHEN Cli_Dni IS NULL
								   THEN convert(nvarchar(100), Publ_Cli_Dni)
								   WHEN Cli_Dni IS NOT NULL
								   THEN convert(nvarchar(100), Cli_Dni)
							  END
						 WHEN Publ_Empresa_Cuit IS NOT NULL 
						 THEN convert(nvarchar(100), Publ_Empresa_Cuit)
					END,
					0,
					1,
					1,
					0,
					0,
					0
					
FROM gd_esquema.Maestra

/*TODO UPDATE para la reputacion*/	

/* MIGRANDO Roles_Usuario*/	

PRINT 'MIGRANDO TABLA ROLES_USUARIOS'


	
INSERT INTO MERCADONEGRO.Roles_Usuarios (ID_User,ID_Rol)

	SELECT ID_User,
		   CASE WHEN Username LIKE'admin'
				THEN (0)
				WHEN Username LIKE'Razon%'
				THEN (2)
				WHEN Username NOT LIKE 'Razon%'
				THEN (1)
		   END
	FROM MERCADONEGRO.Usuarios	
	
	
/* MIGRANDO TABLA CLIENTES */

PRINT 'MIGRANDO TABLA CLIENTES'

INSERT INTO MERCADONEGRO.Clientes (ID_User,
								   Num_Doc,
								   Nombre,
								   Apellido,
								   Mail,
								   Direccion,
								   Codigo_Postal,
								   Fecha_Nacimiento)

	SELECT DISTINCT MERCADONEGRO.Usuarios.ID_User, 
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
					
	FROM MERCADONEGRO.Usuarios
	INNER JOIN gd_esquema.Maestra
	ON gd_esquema.Maestra.Publ_Cli_Dni IS NOT NULL
	 


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