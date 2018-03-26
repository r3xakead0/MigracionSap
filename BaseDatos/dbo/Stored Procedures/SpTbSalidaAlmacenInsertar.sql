CREATE PROCEDURE SpTbSalidaAlmacenInsertar
@idSalidaAlmacen AS INT OUT,
@serie AS VARCHAR(10),
@fechaContable AS DATETIME,
@comentario AS VARCHAR(255),
@fechaCreacion AS DATETIME,
@total AS DECIMAL(19,6),
@usuario AS VARCHAR(20),
@codSap AS INT
AS
BEGIN
	INSERT INTO TbSalidaAlmacen (serie,fechaContable,comentario,fechaCreacion,total,usuario,codSap)
	VALUES (@serie,@fechaContable,@comentario,@fechaCreacion,@total,@usuario,@codSap)
	SET @IdSalidaAlmacen = @@IDENTITY
END