CREATE PROCEDURE [dbo].[SpTbSalidaAlmacenActualizar]
@idSalidaAlmacen AS INT,
@idEmpresa AS INT,
@idTipoDocumento AS INT,
@serie AS VARCHAR(10),
@fechaContable AS DATETIME,
@comentario AS VARCHAR(255),
@fechaCreacion AS DATETIME,
@total AS DECIMAL(19,6),
@usuario AS VARCHAR(20),
@codSap AS INT
AS
BEGIN
	UPDATE	TbSalidaAlmacen 
	SET		idEmpresa = @idEmpresa,
			idTipoDocumento = @idTipoDocumento,
			serie = @serie,
			fechaContable = @fechaContable,
			comentario = @comentario,
			fechaCreacion = @fechaCreacion,
			total = @total,
			usuario = @usuario,
			codSap = @codSap
	WHERE	IdSalidaAlmacen = @IdSalidaAlmacen
END