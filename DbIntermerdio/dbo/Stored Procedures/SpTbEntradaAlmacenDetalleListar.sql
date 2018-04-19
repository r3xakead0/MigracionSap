CREATE PROCEDURE [dbo].[SpTbEntradaAlmacenDetalleListar]
@idEntradaAlmacen AS INT
AS
BEGIN
	SELECT	T0.IdEntradaAlmacenDetalle, 
			T0.idEntradaAlmacen, 
			T0.nroLinea, 
			T0.codArticulo, 
			T0.dscArticulo,
			T0.cantidad,
			T0.codAlmacen,
			T0.codImpuesto,
			T0.codCuentaContable,
			T0.codProyecto,
			T0.codCentroCosto,
			T0.refLineaSap
	FROM	TbEntradaAlmacenDetalle T0
	WHERE	T0.idEntradaAlmacen = @idEntradaAlmacen 
END