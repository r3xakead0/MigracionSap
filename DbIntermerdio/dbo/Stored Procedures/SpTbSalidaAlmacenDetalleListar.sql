CREATE PROCEDURE [dbo].[SpTbSalidaAlmacenDetalleListar]
@idSalidaAlmacen AS INT
AS
BEGIN
SELECT idSalidaAlmacenDetalle,
idSalidaAlmacen,
nroLinea,
codArticulo,
dscArticulo,
cantidad,
codAlmacen,
codImpuesto,
codCuentaContable,
codProyecto,
codCentroCosto
FROM TbSalidaAlmacenDetalle
WHERE idSalidaAlmacen = @idSalidaAlmacen
END