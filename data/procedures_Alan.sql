CREATE PROCEDURE MERCADONEGRO.obtenerCompras
	@ID_User NUMERIC(18,0)
AS
	SELECT ID_Vendedor, Cod_Publicacion, Cod_Calificacion, Fecha_Operacion FROM MERCADONEGRO.Operaciones WHERE ID_Comprador = @ID_User AND Tipo_Operacion = 'Compra Inmediata'
GO

CREATE PROCEDURE MERCADONEGRO.obtenerOfertasGanadas
	@ID_User NUMERIC(18,0)
AS
	SELECT ID_Vendedor, Cod_Publicacion, Cod_Calificacion, Fecha_Operacion FROM MERCADONEGRO.Operaciones WHERE ID_Comprador = @ID_User AND Tipo_Operacion = 'Subasta'
GO

CREATE PROCEDURE MERCADONEGRO.obtenerOfertas
	@ID_User NUMERIC(18,0)
AS
	SELECT ID_Vendedor, Cod_Publicacion, Fecha_Oferta, Monto FROM MERCADONEGRO.Subastas WHERE ID_Comprador = @ID_User
GO

CREATE PROCEDURE MERCADONEGRO.eliminarRubro
	@ID_Rubro NUMERIC(18,0)
AS
	UPDATE MERCADONEGRO.Rubro_Publicacion SET ID_Rubro = 1 WHERE ID_Rubro = @ID_Rubro
	DELETE FROM MERCADONEGRO.Rubros WHERE ID_Rubro = @ID_Rubro
GO