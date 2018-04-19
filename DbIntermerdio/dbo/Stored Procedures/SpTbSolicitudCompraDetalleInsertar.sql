CREATE PROCEDURE [dbo].[SpTbSolicitudCompraDetalleInsertar]
@idSolicitudCompraDetalle AS INT OUT,
@idSolicitudCompra AS INT,
@nroLinea AS INT,
@codigo AS VARCHAR(20),
@descripcion AS VARCHAR(100),
@cantidad AS DECIMAL(19,6),
@codAlmacen AS VARCHAR(10),
@codCentroCosto AS VARCHAR(10),
@codProveedor AS VARCHAR(20)
AS
BEGIN
	INSERT INTO TbSolicitudCompraDetalle (idSolicitudCompra,nroLinea,codigo,descripcion,cantidad,codAlmacen,codCentroCosto,codProveedor)
	VALUES (@idSolicitudCompra,@nroLinea,@codigo,@descripcion,@cantidad,@codAlmacen,@codCentroCosto,@codProveedor)
	SET @IdSolicitudCompraDetalle = @@IDENTITY
END