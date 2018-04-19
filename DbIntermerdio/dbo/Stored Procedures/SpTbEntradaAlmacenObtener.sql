CREATE PROCEDURE [dbo].[SpTbEntradaAlmacenObtener]
@idEntradaAlmacen AS INT 
AS
BEGIN
	SELECT	TOP 1 
			T0.idEntradaAlmacen, 
			T0.idEmpresa, 
			T0.idTipoDocumento, 
			T0.serie, 
			T0.fechaContable, 
			T0.comentario, 
			T0.fechaCreacion, 
			T0.total, 
			T0.usuario,
			T0.codSap, 
			T0.refSap
	FROM	TbEntradaAlmacen T0
	WHERE	T0.idEntradaAlmacen = @IdEntradaAlmacen
END