CREATE PROCEDURE MERCADONEGRO.pObtenerCompras
	@pagina INT,
	@ID_User NUMERIC(18,0)
AS
	SELECT * FROM (
		SELECT ID_Vendedor, Cod_Publicacion, Cod_Calificacion, Fecha_Operacion, ROW_NUMBER() OVER(ORDER BY Fecha_Operacion ASC) AS ROW_NUMBER
		FROM MERCADONEGRO.Operaciones
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
		FROM MERCADONEGRO.Operaciones
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