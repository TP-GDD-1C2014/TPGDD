CREATE PROCEDURE MERCADONEGRO.obtenerCompras @ID_User NUMERIC(18,0)
AS
SELECT ID_Operacion, ID_Vendedor, Cod_Publicacion, Cod_Calificacion, Fecha_Operacion FROM MERCADONEGRO.Operaciones WHERE ID_Comprador = @ID_User AND Tipo_Operacion = 0
GO

CREATE PROCEDURE MERCADONEGRO.obtenerOfertas @ID_User NUMERIC(18,0)
AS
SELECT ID_Subasta, ID_Vendedor, Cod_Publicacion, Fecha_Oferta, Tipo_Operacion FROM MERCADONEGRO.Subastas WHERE ID_Comprador = @ID_User
GO