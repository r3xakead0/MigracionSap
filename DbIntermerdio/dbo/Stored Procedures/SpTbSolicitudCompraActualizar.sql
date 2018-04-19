CREATE PROCEDURE [dbo].[SpTbSolicitudCompraActualizar]
@idSolicitudCompra AS INT,
@idEmpresa AS INT,
@idTipoDocumento AS INT,
@serie AS VARCHAR(10),
@tipo AS CHAR(1),
@fechaContable AS DATETIME,
@fechaNecesita AS DATETIME,
@fechaCreacion AS DATETIME,
@comentario AS VARCHAR(255),
@total AS DECIMAL(19,6),
@usuario AS VARCHAR(20),
@codSap AS VARCHAR(10)
AS
BEGIN
	UPDATE	TbSolicitudCompra 
	SET		idEmpresa = @idEmpresa,
			idTipoDocumento = @idTipoDocumento,
			serie = @serie,
			tipo = @tipo,
			fechaContable = @fechaContable,
			fechaNecesita = @fechaNecesita,
			fechaCreacion = @fechaCreacion,
			comentario = @comentario,
			total = @total,
			usuario = @usuario,
			codSap = @codSap
	WHERE	IdSolicitudCompra = @IdSolicitudCompra
END