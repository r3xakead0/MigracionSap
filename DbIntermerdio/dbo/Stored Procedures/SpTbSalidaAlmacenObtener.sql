CREATE PROCEDURE [dbo].[SpTbSalidaAlmacenObtener]
@IdSalidaAlmacen AS INT
AS
BEGIN
	SELECT	TOP 1 
			idSalidaAlmacen,
			idEmpresa,
			idTipoDocumento,
			serie,
			fechaContable,
			comentario,
			fechaCreacion,
			total,
			usuario,
			codSap
	FROM	TbSalidaAlmacen
	WHERE	IdSalidaAlmacen = @IdSalidaAlmacen
END