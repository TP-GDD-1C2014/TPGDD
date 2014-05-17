-----------------------------------------------Funciones, Stored Procedures y Triggers------------------------------------------------
/* FUNCION AGREGAR FUNCIONALIDAD X ROL*/

CREATE PROCEDURE MERCADONEGRO.AgregarFuncionalidad(@rol nvarchar(255), @func nvarchar(255)) AS
BEGIN
	INSERT INTO MERCADONEGRO.Funcionalidad_Rol (ID_Rol, ID_Funcionalidad)
		VALUES ((SELECT ID_Rol FROM MERCADONEGRO.Roles WHERE Nombre = @rol),
		        (SELECT ID_Funcionalidad FROM MERCADONEGRO.Funcionalidades WHERE Nombre = @func))
END
GO

CREATE PROCEDURE MERCADONEGRO.AgregarRol(@iduser numeric(18,0), @idrol numeric(18,0)) AS
BEGIN
	INSERT INTO MERCADONEGRO.Roles_Usuarios (ID_User,ID_Rol)
		VALUES ((SELECT ID_User FROM MERCADONEGRO.Usuarios WHERE ID_User = @iduser),
				(SELECT ID_Rol FROM MERCADONEGRO.Roles WHERE ID_Rol = @idrol))
END 
GO
/*
CREATE PROCEDURE MERCADONEGRO.InsertarCliente(@tipoDoc nvarchar(50),
											  @numDoc numeric(18,0), @nombre nvarchar(255),
											  @apellido nvarchar(255), @mail nvarchar(255),
											  @direccion nvarchar(255), @codPostal nvarchar(50),
											  @fechaNacimiento datetime)
BEGIN
	INSERT INTO MERCADONEGRO.Cliente(ID_User, Tipo_Doc, Num_Doc, Nombre, Apellido, Mail, Direccion,
									 Codigo_Postal, Fecha_Nacimiento) 
			VALUES((SELECT ID_User FROM MERCADONEGRO.usuarios WHERE Num_Doc = @numDoc),
					(SELECT */
	
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
							