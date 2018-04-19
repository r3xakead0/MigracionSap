CREATE PROCEDURE [dbo].[SpTbSolicitudCompraDetalleListar]
@idSolicitudCompra AS INT
AS
BEGIN
SELECT idSolicitudCompraDetalle,
idSolicitudCompra,
nroLinea,
codigo,
descripcion,
cantidad,
codAlmacen,
codCentroCosto,
codProveedor
FROM TbSolicitudCompraDetalle
WHERE idSolicitudCompra = @idSolicitudCompra
END